using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusController : MonoBehaviour
{
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }



    public void ReturnGame()
    {
        SceneManager.LoadScene(1);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void Pause()
    {
        SceneManager.LoadScene(3);
    }

    public void PreviusLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(4);
    }

}
