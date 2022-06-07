using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeleport : MonoBehaviour
{
    Transform player;
    public float tiempoDeTeleportacion;
    public float distanciaDeDeteccion;
    public bool inicarTeleport;
    public float distanciaContador;
    public GameObject efectoHit;
    Animator anim;
    void Start()
    {
        player = GameObject.Find("MBoy").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        IniciarTeleport();
        DetectarJugador();
        CaerDelCielo();
    }

    public void IniciarTeleport()
    {
        if(inicarTeleport)
        {
            tiempoDeTeleportacion += 0.1f * Time.deltaTime;
            if (tiempoDeTeleportacion >= 0.2f)
            {
                anim.SetTrigger("Telep");
                transform.position = new Vector2(Random.Range(player.transform.position.x-1f, player.transform.position.x+1f), player.position.y+1f);
                tiempoDeTeleportacion = 0.0f;
            }
        }

        if(player.transform.position.x>transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if(player.position.x<transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
       
      
    }

    public void DetectarJugador()
    {
        distanciaContador = Vector3.Distance(transform.position, player.transform.position);
        if(distanciaContador<=distanciaDeDeteccion)
        {
            inicarTeleport = true;
        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("ClawAttack");
            Instantiate(efectoHit, collision.transform.position, transform.rotation);
            //collision.gameObject.GetComponent<>
        }
    }

    public void CaerDelCielo()
    {
        EnemyController contro = GetComponent<EnemyController>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (contro.vida <= 0.0f)
        {
            rb.isKinematic = false;
        }
    }

}
