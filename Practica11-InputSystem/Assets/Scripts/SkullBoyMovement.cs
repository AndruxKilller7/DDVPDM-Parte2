using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullBoyMovement : MonoBehaviour
{
    public float velocidad;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Walk", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("Walk", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
    }
}
