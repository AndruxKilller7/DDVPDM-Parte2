using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MBoyMovement : MonoBehaviour
{

    Animator animBoy;
    Rigidbody2D rbBoy;
    public GameObject power;
    public Transform pivotP;
    public float fuerzaDeSalto;
    HUDManager controllerBar;
    public bool enSuelo;
    public float velocidad;
    Vector2 rot;
    public bool isRun;
    public InputSystemControls inputs;
    Vector2 move;
    public Joystick joy;



    private void Awake()
    {
        controllerBar = GameObject.Find("Main Camera").GetComponent<HUDManager>();
        InputSystemControls inputs = new InputSystemControls();
        inputs.Enable();
        inputs.Player.Movement.performed += ctx => Walk(ctx.ReadValue<float>());
        inputs.Player.Movement.canceled += ctx => StopMovement(ctx.ReadValue<float>());
        inputs.Player.Power.performed += ctx => ShootPower();
        inputs.Player.Kick.performed += ctx => Attack();
        inputs.Player.Jump.performed += ctx => Jump();
        
    }

    

    void Start()
    {
        animBoy = GetComponent<Animator>();
        rbBoy = GetComponent<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        rot = new Vector2(transform.rotation.x, transform.rotation.y - 180);
       
        //move.x = joy.Horizontal;
        JumpVerify();

        if(move.x==0)
        {
            animBoy.SetBool("isWalk", false);
        }
        if(move.x>0)
        {
            animBoy.SetBool("isWalk", true);
            transform.Translate(Vector3.right * move.x *velocidad * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if(move.x<0)
        {
            animBoy.SetBool("isWalk", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.left * move.x *velocidad* Time.deltaTime);
        }
       
        
        //if (move.x > 0.01f)
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
        //else if (move.x < -0.01f)
        //    transform.rotation = Quaternion.Euler(0, 180, 0);
        //Jump();
        //Dead();
        //Attack();
        //Run();
    }

    public void StopMovement(float value)
    {
        move.x = 0;
    }
    
    public void ShootPower()
    {
        animBoy.SetTrigger("isPower");
        Instantiate(power, pivotP.transform.position,transform.rotation);
    }

    public void Walk(float value)
    {
       
        move.x = value;
       
        //if (Input.GetKey(KeyCode.D))
        //{
        //    animBoy.SetBool("isWalk", true);
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
        //    transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        //}
        //else
        //{
        //    animBoy.SetBool("isWalk", false);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    animBoy.SetBool("isWalk", true);
        //    transform.rotation = Quaternion.Euler(0, 180, 0);
        //    transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        //}


    }

    public void Jump()
    {
        if (enSuelo)
        {



            enSuelo = false;
            rbBoy.AddForce(Vector2.up * fuerzaDeSalto, ForceMode2D.Impulse);

        }




       
    }
    public void JumpVerify()
    {
        if (enSuelo)
        {
            animBoy.SetBool("isJump", false);
        }

        if (enSuelo == false)
        {
            animBoy.SetBool("isJump", true);
        }
    }

    public void Attack()
    {
       
        animBoy.SetTrigger("isAttack");
       
    }

    public void Dead()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    animBoy.SetTrigger("isDead");
        //}
    }

    public void Run()
    {
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    isRun = true;
        //    velocidad = 8;
        //}
        //else
        //{
        //    isRun = false;
        //    animBoy.SetBool("isRun", false);
        //}

        //if (isRun)
        //{


        //    if (Input.GetKey(KeyCode.D))
        //    {
        //        transform.rotation = Quaternion.Euler(0, 0, 0);
        //        animBoy.SetBool("isRun", true);
        //        animBoy.SetBool("isWalk", false);
        //        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        //    }

        //    if (Input.GetKey(KeyCode.A))
        //    {
        //        transform.rotation = Quaternion.Euler(0, 180, 0);
        //        animBoy.SetBool("isRun", true);
        //        animBoy.SetBool("isWalk", false);

        //        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        //    }
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            enSuelo = true;
        }

        //if (collision.gameObject.CompareTag("Enemie1"))
        //{
            
        //}

    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadEmpty"))
        {
            SceneManager.LoadScene(4);
        }

        if (collision.CompareTag("DamageEnemy"))
        {
            Debug.Log("asad");
            controllerBar.DisminuirVida();
        }
    }

}
