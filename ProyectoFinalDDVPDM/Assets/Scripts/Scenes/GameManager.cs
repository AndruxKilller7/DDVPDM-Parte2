using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;
    public Text lifeText;
    public PlayerStats datesPlayer;
    public float life;






    void Start()
    {

        datesPlayer.life = 80;

    }


    void Update()
    {
        MakeSingleton();

        life = datesPlayer.life;
        lifeText.text = life.ToString();
    

    }

    void MakeSingleton()
    {
        if (intance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            intance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}




