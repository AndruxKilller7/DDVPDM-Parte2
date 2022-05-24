using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMovement : MonoBehaviour
{
    public float velocidad;
    public GameObject explosionEffect;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        Destroy(this.gameObject, 5f);
    }

    
    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemiw") || collision.CompareTag("Wall"))
        {
           
            anim.SetTrigger("Damage");
            Destroy(this.gameObject);
            Instantiate(explosionEffect,transform.position,transform.rotation);
        }
    }
}
