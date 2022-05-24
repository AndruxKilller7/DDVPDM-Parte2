using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemieGhost : MonoBehaviour
{
    public Transform player;
    Animator animEn;
    public GameObject attackCollider;
    public float velocidad;
    public float distance;
    bool ping;
    bool pong;
    float max;
    float min;
    public bool isDetected;
    public float vida;
    public Image barlife;
    void Start()
    {
        animEn = GetComponent<Animator>();
        ping = true;
        max = transform.position.x + 2;
        min = transform.position.x - 2;
    }

   
    void Update()
    {
        
        vida = Mathf.Clamp(vida, 0, 100);
        barlife.fillAmount = vida / 100;

        if (vida<=0)
        {
            Destroy(this.gameObject);
        }

        if(isDetected==false)
        {
            if (ping)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.Translate(Vector3.right * velocidad * Time.deltaTime);

            }
            if (pong)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.Translate(Vector3.right * velocidad * Time.deltaTime);
            }

            if (transform.position.x > max)
            {
                ping = false;
                pong = true;

            }
            if (transform.position.x < min)
            {
                pong = false;
                ping = true;
            }
        }
        

        distance = Vector3.Distance(player.position, transform.position);
        if(distance<1)
        {
            isDetected = true;
            animEn.SetTrigger("isAttack");

            transform.rotation= Quaternion.Euler(transform.rotation.x, player.transform.rotation.y,transform.rotation.z);
        }
        else
        {
            isDetected = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Power1"))
        {
            Destroy(collision.gameObject);
            animEn.SetTrigger("isDamage");
            vida -= 50;

        }
    }

    public void AttackActive()
    {
        attackCollider.SetActive(true);
    }
    public void AttackDiseable()
    {
        attackCollider.SetActive(false);
    }
}
