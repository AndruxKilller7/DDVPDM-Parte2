using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEMovement : MonoBehaviour
{
    public float velocity;
    public GameObject effect;

    void Start()
    {
        Destroy(this.gameObject, 6f);
    }


    void Update()
    {
        transform.Translate(Vector3.left * velocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(effect, new Vector2(collision.transform.position.x+0.5f, collision.transform.position.y + 1f), transform.rotation);
            Destroy(this.gameObject);
            //velocity = 0.0f;
           
        }

    }
}
