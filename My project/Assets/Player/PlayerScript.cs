using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 4;
    private bool canDoubleJump;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey("d")){
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }else if(Input.GetKey("a")){
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }else{
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Run", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space")){
            if(CheckGround.isGrounded){
                canDoubleJump = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
            else{
                if(Input.GetKeyDown("space") && canDoubleJump){
                    animator.SetBool("DoubleJump", true);
                    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                    canDoubleJump = false;
                }
            }
        }

        if(CheckGround.isGrounded == false){
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if(CheckGround.isGrounded == true){
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Fall", false);
        }

        if(rb.velocity.y < 0){
            animator.SetBool("Fall", true);
        }else if(rb.velocity.y > 0){
            animator.SetBool("Fall", false);
        }
    }
}
