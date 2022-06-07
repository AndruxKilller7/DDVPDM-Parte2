using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float velocity;


    void Start()
    {
        Destroy(this.gameObject, 6f);
    }


    void Update()
    {
        transform.Translate(Vector3.up * velocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemiw")|| collision.CompareTag("Wall") || collision.CompareTag("Teleporter") || collision.CompareTag("Jumper") || collision.CompareTag("Arquero"))
        {
            transform.parent = collision.gameObject.transform;
            velocity = 0.0f;
        }
       
    }

}
