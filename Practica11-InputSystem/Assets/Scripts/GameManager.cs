using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;
    public int lasangnas;

    public DatesP datesPlayer;
    public DatesP datesPlayerSave;
    public CardHUD datesHUD;
    public string nameCharacter;
    public int inteligencia;
    public int lasangas;
    public int agylity;
    public int force;
    public float life;



   


    void Start()
    {
        datesHUD.cantidadDeVida = 80;

    }

   
    void Update()
    {
        MakeSingleton();
        life = datesHUD.cantidadDeVida;
        nameCharacter = datesPlayer.nameCharacter;
        inteligencia = datesPlayer.inteligencia;
        lasangas = datesPlayer.lasangas;
        agylity = datesPlayer.agylity;
        force = datesPlayer.force;


    }

    void MakeSingleton()
    {
        if(intance !=null)
        {
            Destroy(gameObject);
        }

        else
        {
            intance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SaveGame()
    {
        SaveLoadGameManager.SavePlayerStats(datesHUD);
    }

    public void LoadGame()
    {
        HUDCotroller data = SaveLoadGameManager.LoadPlayerStats();

        life = data.cantidad;
       

    }
}
