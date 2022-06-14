using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float velocidad;
    Vector2 move;
    Rigidbody2D rB;
    public bool enElPiso;
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        PlayerActions inputs = new PlayerActions();
        inputs.Enable();
        inputs.Actions.Movement.performed += ctx => Caminar(ctx.ReadValue<float>());
        inputs.Actions.Movement.canceled += ctx => Detenerse();
        inputs.Actions.Jump.performed += ctx => Saltar();
    }

    // Update is called once per frame
    void Update()
    {
        ControlDeMovimiento();
    }

    public void ControlDeMovimiento()
    {
        if (move.x == 0)
        {
            //animBoy.SetBool("isWalk", false);
        }
        if (move.x > 0)
        {
            //animBoy.SetBool("isWalk", true);
            transform.Translate(Vector3.right * move.x * velocidad * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if (move.x < 0)
        {
            //animBoy.SetBool("isWalk", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.left * move.x * velocidad * Time.deltaTime);
        }
    }

    public void Caminar(float value)
    {

        move.x = value;

    }

    public void Detenerse()
    {
        move.x = 0.0f;
    }

    public void Saltar()
    {
        if(enElPiso)
        {
            enElPiso = false;
            rB.velocity = new Vector2(rB.velocity.x, velocidad);
        }

       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Piso") || collision.gameObject.CompareTag("PlataformaM"))
        {
            enElPiso = true;
        }

        if(collision.gameObject.CompareTag("PlataformaM"))
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlataformaM"))
        {
            transform.parent = null;
        }
    }

}
