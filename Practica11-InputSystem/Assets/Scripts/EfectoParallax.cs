using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoParallax : MonoBehaviour
{
    public float velocidadDeMovimiento;
    private Transform posicioncamara;
    private Vector3 posicionInicialCamara;
    private float tamaņoDeSprite, posicionInicial;

    void Start()
    {
        posicioncamara = Camera.main.transform;
        posicionInicialCamara = posicioncamara.position;
        tamaņoDeSprite = GetComponent<SpriteRenderer>().bounds.size.x;
        posicionInicial = transform.position.x;
        
    }

   
    void LateUpdate()
    {
        float deltaX = (posicioncamara.position.x - posicionInicialCamara.x)*velocidadDeMovimiento;
        float cantidadDeMovimiento = posicioncamara.position.x * (1 - velocidadDeMovimiento);

        transform.Translate(new Vector3(deltaX, 0, 0));
        posicionInicialCamara = posicioncamara.position;

        if(cantidadDeMovimiento > posicionInicial + tamaņoDeSprite)
        {
            transform.Translate(new Vector3(tamaņoDeSprite, 0, 0));
            posicionInicial += tamaņoDeSprite;
        }
        if(cantidadDeMovimiento < posicionInicial - tamaņoDeSprite)
        {
            transform.Translate(new Vector3(-tamaņoDeSprite, 0, 0));
            posicionInicial -= tamaņoDeSprite;
        }

    }
}
