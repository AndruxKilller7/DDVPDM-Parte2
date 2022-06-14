using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public float velocidad;
    public bool vuelta;
    public float limite;
    Vector2 limites;
    void Start()
    {
        limites = new Vector2(transform.position.x, transform.position.y);
    }

    
    void Update()
    {
        if (vuelta == false)
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        }

        if(vuelta)
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
        }

        if (transform.position.x > limites.x + limite)
        {
            vuelta = true;
          
        }

        if (transform.position.x < limites.x - limite)
        {
            vuelta = false;
           
        }

    }
}
