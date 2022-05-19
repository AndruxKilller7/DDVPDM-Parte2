using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsMovement : MonoBehaviour
{
    public Transform contenerdorDeItems;
    public bool movimientoActivado;
    public float speedMovement;
    BoxCollider2D colliderObj;
    public Touch toque;

    void Start()
    {
        colliderObj = GetComponent<BoxCollider2D>();
    }

   
    void Update()
    {
        MoverItem();
        //TouchItems();
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

    //void TouchItems()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        toque = Input.GetTouch(0);
    //    }

    //    Vector2 pos = Camera.main.ScreenToWorldPoint(toque.position);
    //    RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
    //    if (hit.collider != null)
    //    {
    //        movimientoActivado = true;
    //        Debug.Log("YEES");
    //    }

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Vector2 posF = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        RaycastHit2D hitR = Physics2D.Raycast(posF, Vector2.zero);
    //        if (hitR.collider != null)
    //        {
    //            movimientoActivado = true;
    //            Debug.Log(hitR.point);
    //        }
    //    }

    //}
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
