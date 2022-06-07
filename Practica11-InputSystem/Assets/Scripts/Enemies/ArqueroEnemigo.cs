using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArqueroEnemigo : MonoBehaviour
{
    Transform player;
    public float distanciaDeDeteccion;
    public bool disparar;
    public GameObject arrow;
    public Transform pivtoShoot;
    public float fireRate;
    public float nextFire;
    public Animator anim;
    void Start()
    {
        player = GameObject.Find("MBoy").GetComponent<Transform>();
    }


    void Update()
    {
        DetectarJugador();
        Disparar();
    }

    public void DetectarJugador()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if(distance<=distanciaDeDeteccion)
        {
            disparar = true;
        }
    }

    public void Disparar()
    {
        if(disparar)
        {
            if(Time.time>= nextFire)
            {
                anim.SetTrigger("Shoot");
                nextFire = Time.time + fireRate;
                Instantiate(arrow, pivtoShoot.position, transform.rotation);
            }
        }
    }
}
