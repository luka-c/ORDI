using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed = 1.5f;
    public float force = 1f;
    private Rigidbody2D rg;
    public float dashSpeed = 4;
    private float dashTime;
    public float startDashTime;
    private int direction;
    bool isDashing;
    

    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        
        //Move
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        //Jump
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rg.velocity.y) < 0.001f){
            rg.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && movement != 0) {
            if (movement < 0)
                rg.AddRelativeForce(Vector2.left * dashSpeed * 100);
            else if (movement > 0)
                rg.AddRelativeForce(Vector2.right * dashSpeed * 100);
        }
    }
}
