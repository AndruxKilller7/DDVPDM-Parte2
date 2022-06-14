using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text contador;
    public int tiempoParaContinuar;
    public float timeC;
    public float tiempoMaximo;
    void Start()
    {
        
    }

   
    void Update()
    {
        contador.text = tiempoParaContinuar.ToString();
        ContadorIniciado();
    }

    public void ContadorIniciado()
    {
        if(tiempoParaContinuar>0)
        {
            timeC += 0.1f * Time.deltaTime;
            if (timeC >= tiempoMaximo)
            {
                tiempoParaContinuar -= 1;
                timeC = 0.0f;
            }
        }
       

    }

    public void Continuar()
    {
        SceneManager.LoadScene(2);
    }

    public void Renunciar()
    {
        SceneManager.LoadScene(1);
    }
}
