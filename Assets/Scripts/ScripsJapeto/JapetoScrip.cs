using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JapetoScrip : MonoBehaviour
{
    Rigidbody2D Rb2D;
    public Animator animator;
    public float runSpeed = 8f;
    public float jumpSpeed = 30;
    public bool betterJump = false;
    public float fallMultiplier = 10f;
    public float lowJumpMultiplier = 12f;
    public GameObject SkullAPrefab;
    public float LastShoot;



    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            Rb2D.velocity = new Vector2(runSpeed, Rb2D.velocity.y);
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            Rb2D.velocity = new Vector2(-runSpeed, Rb2D.velocity.y);
            transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
            animator.SetBool("Run", true);
        }
        else

        {
            Rb2D.velocity = new Vector2(0, Rb2D.velocity.y);
            animator.SetBool("Run", false);
        }

        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, jumpSpeed);
        }

        /*if (Input.GetKey(KeyCode.E) && Time.time > LastShoot +0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }*/

        if (betterJump)
        {
            if (Rb2D.velocity.y < 0)
            {
                Rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if (Rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                Rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
    /*private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 0.8f) direction = Vector3.right;
        else direction = Vector3.left;
        GameObject SkullA= Instantiate(SkullAPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        SkullA.GetComponent<skullsc>().SetDirection(direction);
    }*/

}