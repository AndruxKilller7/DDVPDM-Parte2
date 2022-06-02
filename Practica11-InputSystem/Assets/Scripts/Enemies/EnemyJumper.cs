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
    public float tiempoDeRotacion;
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

        if(contadorDeColisiones>=2)
        {
            anim.SetBool("Giro", true);
        }
       
        
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
                rbEnemy.AddForce(new Vector2(1,1)* velocidadDeMovimiento, ForceMode2D.Force);
                //transform.Translate(Vector3.right * velocidadDeMovimiento * Time.deltaTime);
            }

            if (objetivo.position.x < transform.position.x)
            {
                rbEnemy.AddForce(new Vector2(-1, 1) * velocidadDeMovimiento, ForceMode2D.Force);
                //transform.Translate(Vector3.left * velocidadDeMovimiento * Time.deltaTime);
            }
        }
    }

    public void RotacionRebotando()
    {
        if(iniciarContador)
        {
            contador += 0.1f * Time.deltaTime;
            if (contador >= tiempoDeRotacion)
            {
                rangoDeDeteccion = true;
                contador = 0.0f;
                iniciarContador = false;
            }
        }
       


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           
            Instantiate(efectoHit, collision.gameObject.GetComponent<MBoyMovement>().pivot.position, collision.transform.rotation);
            iniciarContador = true;
            rangoDeDeteccion = false;
            Debug.Log("sss");
            detectarJugador = false;
            anim.SetBool("Giro", false);
            materialPhysics.bounciness = 0;
        }

      
    }


}
