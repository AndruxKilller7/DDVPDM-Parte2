using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsController : MonoBehaviour
{
    public Text contadorText;
    public int contador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contadorText.text = contador.ToString();
    }

    void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.CompareTag("Lasaña"))
        {
            contador += 1;
        }
    }
}
