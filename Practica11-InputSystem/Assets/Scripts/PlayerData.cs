using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    int lasangnas;
    string nameCharacter;
    public DatesP playerDates;

    public PlayerData(DatesP datesPlayer)
    {
        lasangnas = datesPlayer.lasangas;
        nameCharacter = datesPlayer.nameCharacter;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
