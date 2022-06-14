using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PruebasEscena : MonoBehaviour
{
   
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }
    public void ChangeScene2()
    {
        SceneManager.LoadScene(3);
    }

}
