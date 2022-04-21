using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegamanMovement : MonoBehaviour
{
    Animator anim;
    public float velocidad;
    public bool inFloor;
    public float fuerzaDeSalto;
    public bool isRun;
    Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Attack();
        Jump();
        Run();
        Damage();
    }


    void Walk()
    {

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0,0, 0);
            anim.SetBool("isWalk", true);
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180,0) ;
            anim.SetBool("isWalk", true);

            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        }
    }


    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }


    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * fuerzaDeSalto, ForceMode2D.Impulse);
            inFloor = false;
            anim.SetBool("isJumping", true);
        }

        if(inFloor)
        {
            anim.SetBool("isJumping",false);
        }
    }
    void Damage()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("isDamage");

        }
    }
    void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isRun = true;
        }
        else
        {
            isRun = false;
            anim.SetBool("isRuning", false);
        }

        if(isRun )
        {
           

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                anim.SetBool("isRuning", true);
                anim.SetBool("isWalk", false);
                transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                anim.SetBool("isRuning", true);
                anim.SetBool("isWalk", false);

                transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            inFloor = true;
        }
    }
}
