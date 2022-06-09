using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumper : MonoBehaviour
{

    Transform objetivo;
    public float velocidadDeMovimiento;
    public float distanciaDeDeteccion;
    public bool detectarJugador;
    public bool rangoDeDeteccion;
    float contador;
    public float tiempoDeEspera;
    Animator anim;
    Rigidbody2D rbEnemy;
    public int contadorDeColisiones;
    public GameObject efectoHit;
    public PhysicsMaterial2D materialPhysics;
    public bool iniciarContador;
    void Start()
    {
        objetivo = GameObject.Find("MBoy").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        rbEnemy = GetComponent<Rigidbody2D>();
        
        rangoDeDeteccion = true;
    }

   
    void Update()
    {
        DirigirseAlObjetivo();
        RotacionRebotando();




    }


    public void DirigirseAlObjetivo()
    {
        float distance = Vector3.Distance(transform.position, objetivo.position);
        if(rangoDeDeteccion)
        {
            if (distance <= distanciaDeDeteccion)
            {
                detectarJugador = true;

            }
        }
        

        if (detectarJugador)
        {
            anim.SetBool("Giro", true);
            if (objetivo.position.x > transform.position.x)
            {
                rbEnemy.AddForce(new Vector2(0,1) * 0.1f, ForceMode2D.Impulse);
                rbEnemy.AddForce(new Vector2(1,0)* velocidadDeMovimiento, ForceMode2D.Force);
                //transform.Translate(Vector3.right * velocidadDeMovimiento * Time.deltaTime);
            }

            if (objetivo.position.x < transform.position.x)
            {
                rbEnemy.AddForce(new Vector2(0, 1) * 0.1f, ForceMode2D.Impulse);
                rbEnemy.AddForce(new Vector2(-1, 0) * velocidadDeMovimiento, ForceMode2D.Force);
                //transform.Translate(Vector3.left * velocidadDeMovimiento * Time.deltaTime);
            }
        }
    }

    public void RotacionRebotando()
    {
        if(iniciarContador)
        {
            contador += 0.1f * Time.deltaTime;
            if (contador >= tiempoDeEspera)
            {
                rangoDeDeteccion = true;
                iniciarContador = false;
                contador = 0.0f;
            }
        }
       


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            rangoDeDeteccion = false;
            detectarJugador = false;
            anim.SetBool("Giro", false);
            Instantiate(efectoHit, collision.gameObject.GetComponent<MBoyMovement>().pivot.position, collision.transform.rotation);
            iniciarContador = true;
            Debug.Log("sss");
            
            materialPhysics.bounciness = 0;
            transform.Rotate(0, 0, 0);
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            //transform.Rotate(0, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("Paro");
            anim.SetBool("Giro", false);
         
        }


    }

  


}
