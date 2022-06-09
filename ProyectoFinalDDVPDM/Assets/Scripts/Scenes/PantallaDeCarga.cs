using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PantallaDeCarga : MonoBehaviour
{
    public int sceneID;
    public float valorDeBarra;
    public Image barra;
    public bool cargando;
    void Start()
    {
       
    }

    
    void Update()
    {

        //valorDeBarra = Mathf.Clamp(valorDeBarra, 0, 100f);
        //barra.fillAmount = valorDeBarra / 100f;

        if(Input.GetKeyDown(KeyCode.A))
        {
            cargando = true;
            CargarEscena();
        }
        if (cargando)
        {
            barra.fillAmount += 0.5f*Time.deltaTime;
        }


    }



    public void CargarEscena()
    {
        
 
       
        StartCoroutine(CargaAsync());
    }

    IEnumerator CargaAsync()
    {
        yield return null;
        AsyncOperation asyncoperation = SceneManager.LoadSceneAsync(sceneID);
        asyncoperation.allowSceneActivation = false;
        while (!asyncoperation.isDone)
        {
            
            
            if (barra.fillAmount >= 1.0f)
            {
                asyncoperation.allowSceneActivation = true;
             
            }

            yield return null;

        }

      

    }



    
}
