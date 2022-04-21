using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float velocidadDeMovimiento;
    public GameObject image1;
    public GameObject image2;
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Translate(Vector3.left * velocidadDeMovimiento * Time.deltaTime);
        if (transform.position.x < -1.6)
        {
            image1.transform.position = new Vector2(32.16f, -2.270232f);
        }
        //if (transform.position.x < -1.6)
        //{
        //    image1.transform.position = new Vector2(5.86f, 2.270232f);
        //}
    }

    
}
