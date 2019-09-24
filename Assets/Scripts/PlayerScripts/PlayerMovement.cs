using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 100;
    private bool jumping = true;
    private Rigidbody rb;
    private bool isFacingRight = true;

    

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

   
    void FixedUpdate()
    {
        MovimentControll();
    }

    private void MovimentControll()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0));

            if (Input.GetAxis("Horizontal") > 0)
            {
                if (isFacingRight == false)
                {
                    isFacingRight = true;
                    Flip();
                }
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                if (isFacingRight)
                {
                    isFacingRight = false;
                    Flip();
                }
            }


        }

        if (Input.GetAxis("Jump") != 0)
        {
            if (jumping == true)
            {
                rb.AddForce(new Vector3(0, jumpForce, 0));
            }
        }
    }



    void Flip()
    {
        transform.localScale = new Vector3(-1 *  transform.localScale.x,  transform.localScale.y, transform.localScale.z);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumping = true;
           
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumping = false;           
        }
    }
}
