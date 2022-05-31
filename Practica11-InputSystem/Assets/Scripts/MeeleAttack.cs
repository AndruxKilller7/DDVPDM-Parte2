using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleAttack : MonoBehaviour
{
   
    public float distanciaDeRayCast;
   
    public float fireRate;
    public float nextFire;
    public bool detectado;
    public LayerMask enemies;
    public bool atacado;
    Animator anim;
    public GameObject point;
    RaycastHit2D rayhit;
    public GameObject efectoHit;
    void Start()
    {
        anim = GetComponent<Animator>();
        InputSystemControls inputs = new InputSystemControls();
        inputs.Enable();
        inputs.Player.Kick.performed += ctx => GiroMortal();
       
    }

  
    void Update()
    {


        DibujarRayCast();
    }

    public void DibujarRayCast()
    {
       
        rayhit = Physics2D.Raycast(point.transform.position,  Vector2.right, distanciaDeRayCast);

        if (rayhit.collider == null)
        {
            detectado = false;
            Debug.DrawRay(point.transform.position, Vector2.right * distanciaDeRayCast, Color.red);
        }
        else if (rayhit.collider.CompareTag("Enemiw"))
        {
            detectado = true;
            Debug.DrawRay(point.transform.position, Vector2.right * distanciaDeRayCast, Color.green);
           
        }

       




    }

    public void GiroMortal()
    {
        if (Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            anim.SetTrigger("Meele");
            if (detectado)
            {
                Collider2D[] enemigosDetectados = Physics2D.OverlapCircleAll(point.transform.position, distanciaDeRayCast, enemies);
                for (int i = 0; i < enemigosDetectados.Length; i++)
                {
                    enemigosDetectados[i].gameObject.GetComponent<EnemieGhost>().vida -= 50;
                    Instantiate(efectoHit, enemigosDetectados[i].gameObject.transform.position, efectoHit.transform.rotation);
                }
                //rayhit.collider.gameObject.GetComponent<EnemieGhost>().vida -= 50;

            }
        }

    }

   
}
