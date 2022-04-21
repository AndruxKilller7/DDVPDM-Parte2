using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsMovement : MonoBehaviour
{
    public Transform contenerdorDeItems;
    public bool movimientoActivado;
    public float speedMovement;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        MoverItem();
    }

    public void MoverItem()
    {
        if(movimientoActivado)
        {

            if(contenerdorDeItems.position.x>transform.position.x)
            {
                transform.Translate(Vector2.right * speedMovement * Time.deltaTime);
            }

            if (contenerdorDeItems.position.x < transform.position.x)
            {
                transform.Translate(Vector2.left * speedMovement * Time.deltaTime);
            }

            if (contenerdorDeItems.position.y > transform.position.y)
            {
                transform.Translate(Vector2.up * speedMovement * Time.deltaTime);
            }

            if (contenerdorDeItems.position.y < transform.position.y)
            {
                transform.Translate(Vector2.down * speedMovement * Time.deltaTime);
            }
        }


        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            movimientoActivado = true;
        }

        if (col.CompareTag("MetaItem"))
        {
            Destroy(this.gameObject, 0.5f);
        }
    }

}
