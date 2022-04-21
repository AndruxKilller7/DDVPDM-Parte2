using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    Animator anim;
    public float velocidad;
    Rigidbody2D rb;
    public float fuerzaSalto;
    public float fuerzaSalto2;
    public bool enSalto;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Attack();
        Dead();
        Walk();
        Jump();
        Sword();
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
            rb.AddForce(Vector2.up * fuerzaSalto * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    public void Walk()
    {
        if(Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }


        //if (Input.GetKey(KeyCode.A))
        //{
        //    anim.SetBool("isWalking", true);
        //    transform.rotation = Quaternion.Euler(0, 180, 0);
        //    transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        //}

    }

    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            enSalto = true;
           
        }

        if(enSalto)
        {
            anim.SetBool("isJumping", true);
        }
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("IsAttack");
        }
    }

    void Dead()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("isDead");
        }
    } 

    void Sword()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("isSword");
            rb.AddForce(Vector2.up * fuerzaSalto2, ForceMode2D.Impulse);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            enSalto = false;
            anim.SetBool("isJumping", false);
        }
    }
}
