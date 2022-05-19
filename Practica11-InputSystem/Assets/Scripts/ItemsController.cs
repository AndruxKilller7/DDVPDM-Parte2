using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsController : MonoBehaviour
{
    public Text contadorText;
    public int contador;
    public Touch toque;
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contadorText.text = contador.ToString();
        TouchItems();
        
    }

    void TouchItems()
    {
        if (Input.touchCount > 0)
        {
            toque = Input.GetTouch(0);
        }

        Vector2 pos = Camera.main.ScreenToWorldPoint(toque.position);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Lasaña"))
                {
                    hit.collider.transform.gameObject.GetComponent<ItemsMovement>().movimientoActivado = true;


                }


            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 posF = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitR = Physics2D.Raycast(posF, Vector2.zero);
            if (hitR.collider != null)
            {
                if (hitR.collider.CompareTag("Lasaña"))
                {
                    hitR.collider.transform.gameObject.GetComponent<ItemsMovement>().movimientoActivado=true;
                   

                }


            }
        }
    }





        void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.CompareTag("Lasaña"))
        {
            contador += 1;
            Destroy(colision.gameObject);
        }
    }
}
