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
    private int direction;
    private float posX;
    private float playerScale;
    bool isDashing;
    private PolygonCollider2D playerCollider;

    public GameObject player;

    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        direction = 1;
        posX = transform.position.x;
        playerScale = transform.localScale.x;
        dashTime = startDashTime;
        playerCollider = this.GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        //if (IsGrounded())
        //    //animator.SetBool("isJumping", false);
        //    Debug.Log("Grounded");
        //else
        //    //animator.SetBool("isJumping", true);
        //    Debug.Log("Not Grounded");


        //Move
        var movement = Input.GetAxis("Horizontal");
        
        if (transform.position.x < posX)
        {
            if (direction == 1)
            {
                transform.localScale = new Vector2(-playerScale, transform.localScale.y);
                direction = -1;
            }
        }
        else
        {
            if (direction == -1)
            {
                transform.localScale = new Vector2(playerScale, transform.localScale.y);
                direction = 1;
            }
        }
 
        posX = transform.position.x;
        

        animator.SetFloat("speed", Mathf.Abs(movement * speed));
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        //Jump
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rg.velocity.y) < 0.001f && IsGrounded()){
            rg.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && movement != 0) {
            if (movement < 0)
                rg.AddRelativeForce(Vector2.left * dashSpeed * 100);
            else if (movement > 0)
                rg.AddRelativeForce(Vector2.right * dashSpeed * 100);
        }
    }

    private bool IsGrounded() {
        float extraHeight = .01f;
        RaycastHit2D raycastHit = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + extraHeight);
        return raycastHit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            player.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            player.transform.parent = null;
        }
    }
}
