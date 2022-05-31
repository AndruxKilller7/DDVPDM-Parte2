using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastAttack : MonoBehaviour
{
    public GameObject pivotArrowPoint;
    public GameObject pivotShoot;
    public float distanciaDeRayCast;
    public GameObject arrow;
    public float fireRate;
    public float nextFire;
    public GameObject bowSprite;
    public GameObject arrowSprite;
    public GameObject efectoHit;
    public bool detectado;
    Animator anim;
    RaycastHit2D hit;
    void Start()
    {
        anim = GetComponent<Animator>();
        InputSystemControls inputs = new InputSystemControls();
        inputs.Enable();
        inputs.Player.ShootArrow.performed += ctx => ApuntarConElArco();
        inputs.Player.ShootArrow.canceled += ctx => DispararFlecha();
    }

    // Update is called once per frame
    void Update()
    {
       
       
        DibujarRayCast();
    }

    public void DibujarRayCast()
    {
        hit = Physics2D.Raycast(pivotArrowPoint.transform.position, Vector2.right, distanciaDeRayCast);

        if(hit.collider ==null)
        {
            detectado = false;
            Debug.DrawRay(pivotArrowPoint.transform.position, Vector2.right * distanciaDeRayCast, Color.red);
        }
        else if(hit.collider.CompareTag("Enemiw"))
        {
            detectado = true;
            Debug.DrawRay(pivotArrowPoint.transform.position, Vector2.right * distanciaDeRayCast, Color.green);
        }
       
        //if (hit.collider.CompareTag("Enemiew"))
        //{
        //    Debug.DrawRay(pivotArrowPoint.transform.position, Vector2.right * distanciaDeRayCast, Color.green);
        //}
       
           
       
        
    }

    public void DispararFlecha()
    {
        if (Time.time >= nextFire &&detectado)
        {
            nextFire = Time.time + fireRate;
            anim.SetBool("Arrow", false);
            Instantiate(arrow, hit.collider.transform.position, arrow.transform.rotation);
            Instantiate(efectoHit,new Vector3(hit.collider.transform.position.x-0.5f, hit.collider.transform.position.y, hit.collider.transform.position.z), efectoHit.transform.rotation);
            hit.collider.gameObject.GetComponent<EnemieGhost>().vida -= 50;
            arrowSprite.SetActive(false);
            bowSprite.SetActive(false);
        }
        
    }

    public void ApuntarConElArco()
    {

        anim.SetBool("Arrow", true);
        bowSprite.SetActive(true);
        arrowSprite.SetActive(true);
    }
}
