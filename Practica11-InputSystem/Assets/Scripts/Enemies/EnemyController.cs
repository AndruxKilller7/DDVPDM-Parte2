using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float vida;
    public Image barlife;
    public Animator anim;
    void Start()
    {
        
    }

   
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);
        barlife.fillAmount = vida / 100;
        ControlDeVida();
    }


    public void ControlDeVida()
    {
        if(vida<=0.0f)
        {
            anim.SetTrigger("Dead");
        }
    }


    public void DestruirEnemigo()
    {
        Destroy(this.gameObject);
    }
}
