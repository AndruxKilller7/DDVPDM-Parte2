using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementPhisycs : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 move;
    Animator anim;
    public float speed;
    public float fuerzaDeSalto;
    public bool enSuelo;
    public bool enSueloIce;
    public bool isRun;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
       
    }

    void Update()
    {
       
        
    }

    void FixedUpdate()
    {
        Jump();
        JumpIce();
        Walk();
        Run();
      

      

       
    }

    
    void Walk()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isSliding", false);
            anim.SetBool("isWalk", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = Vector2.right * speed * Time.deltaTime;
        }
        else
        {
            anim.SetBool("isWalk", false);
            //anim.SetBool("isSliding", true);


        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isSliding", false);
            anim.SetBool("isWalk", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rb.velocity = Vector2.left * speed * Time.deltaTime;
        }

        if (rb.velocity == Vector2.zero && enSueloIce)
        {
            anim.SetBool("isSliding", true);
        }
    }


    public void Jump()
    {
        if (enSuelo)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                enSuelo = false;
                rb.AddForce(Vector2.up * fuerzaDeSalto, ForceMode2D.Impulse);
            }
        }


        if (enSuelo)
        {
            anim.SetBool("isJump", false);
        }

        if (enSuelo == false)
        {
            anim.SetBool("isJump", true);
        }
    }


    public void JumpIce()
    {
        if (enSueloIce)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                enSueloIce = false;
                rb.AddForce(Vector2.up * fuerzaDeSalto, ForceMode2D.Impulse);
            }
        }


        if (enSueloIce)
        {
            anim.SetBool("isJump", false);
        }

        //if (enSueloIce == false)
        //{
        //    anim.SetBool("isJump", true);
        //}
    }
    public void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRun = true;
            speed = 8;
        }
        else
        {
            isRun = false;
            anim.SetBool("isRun", false);
        }

        if (isRun)
        {


            if (Input.GetKey(KeyCode.D))
            {
                //anim.SetBool("isSliding", false);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                anim.SetBool("isRun", true);
                anim.SetBool("isWalk", false);
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                //anim.SetBool("isSliding", false);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                anim.SetBool("isRun", true);
                anim.SetBool("isWalk", false);

                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("IceFloor") )
        {
            anim.SetBool("isSliding", true);
            enSueloIce = true;
        }

        if (collision.gameObject.CompareTag("Floor"))
        {

            anim.SetBool("isSliding", false);
          
            enSuelo = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadEmpty"))
        {
            SceneManager.LoadScene(4);
        }
    }







}
