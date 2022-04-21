using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDatesP : MonoBehaviour
{
    public DatesP datesPlayer;
    public string nameCharacter;
    public int inteligencia;
    public int lasangas;
    public int agylity;
    public int force;

    void Start()
    {
        nameCharacter = datesPlayer.nameCharacter;
        inteligencia = datesPlayer.inteligencia;
        lasangas = datesPlayer.lasangas;
        agylity = datesPlayer.agylity;
        force = datesPlayer.force;
    }

    
    void Update()
    {
        GameManager.intance.nameCharacter = nameCharacter;
        GameManager.intance.inteligencia = inteligencia;
        GameManager.intance.lasangas = lasangas;
        GameManager.intance.agylity = agylity;
        GameManager.intance.force = force;
    }
}
