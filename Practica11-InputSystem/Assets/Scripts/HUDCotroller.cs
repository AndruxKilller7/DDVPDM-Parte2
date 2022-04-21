using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class HUDCotroller 
{
    //public Image barlife;

    //public Text cantidadText;
    public float cantidad = 100f;

    public HUDCotroller(CardHUD datesPlayer)
    {
        cantidad = datesPlayer.cantidadDeVida;
        
    }

  

  
    //void Update()
    //{
    //    //cantidad = GameManager.intance.life;
    //    //cantidad = Mathf.Clamp(cantidad, 0, 100);
    //    //barlife.fillAmount = cantidad / 100;
    //    //cantidadText.text = cantidad.ToString()+"%";
    //}

   
}
