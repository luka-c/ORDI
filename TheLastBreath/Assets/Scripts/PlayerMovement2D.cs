using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 1.5f;
    public float force = 1f;
    private Rigidbody2D rg;
    public float dashSpeed = 4;
    private float dashTime;
    public float startDashTime;
    [Header("Animation")]
    public Animator animator;
    [SerializeField]
    private LayerMask platformMask;
    bool isDashing;
    private PolygonCollider2D playerCollider;
    private bool direction;
    private GameObject[] players;

    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        playerCollider = this.GetComponent<PolygonCollider2D>();
        direction = true;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (IsGrounded()) {
            animator.SetBool("isJumping", false);
        }
            
        else
        {
            animator.SetBool("isJumping", true);
        }


        //Move
        var movement = Input.GetAxis("Horizontal");

        if (movement < 0 && direction)
            flipPlayer();
        else if (movement > 0 && !direction)
            flipPlayer();
        
        animator.SetFloat("speed", Mathf.Abs(movement * speed));
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        //Jump
        if (Input.GetButtonDown("Jump") && IsGrounded()){
            rg.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && movement != 0) {
            if (movement < 0)
                rg.AddRelativeForce(Vector2.left * dashSpeed * 100);
            else if (movement > 0)
                rg.AddRelativeForce(Vector2.right * dashSpeed * 100);
        }
    }

    private bool IsGrounded()
    {
        float extraHeight = .3f;
        RaycastHit2D raycastHit = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + extraHeight, platformMask);
        return raycastHit.collider != null;
    }

    private void FixedUpdate() 
    {
       if (transform.eulerAngles.z > 45 && transform.eulerAngles.z < 180)
    {
        transform.rotation = Quaternion.AngleAxis(-315, new Vector3(0, 0, 45));
    }


    if (transform.eulerAngles.z < 315 && transform.eulerAngles.z > 180)
    {
        transform.rotation = Quaternion.AngleAxis(-315, new Vector3(0, 0, -45));
    }
    }

    private void flipPlayer()
    {
        direction = !direction;
        transform.Rotate(0, 180, 0);
    }

    private void OnLevelLoad(int level)
    {
        transform.position = GameObject.FindGameObjectWithTag("StartPosition").transform.position;

        players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 1)
            Destroy(players[1]);
    }
}
