using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplegarMenuDePausa : MonoBehaviour
{
    public GameObject panelDePausa;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Desplegar()
    {
        panelDePausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Cerrar()
    {
        panelDePausa.SetActive(false);
        Time.timeScale = 1f;
    }
}
