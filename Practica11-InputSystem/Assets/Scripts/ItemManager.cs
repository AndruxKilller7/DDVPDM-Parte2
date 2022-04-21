using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemManager : MonoBehaviour
{
    public Text container;
    public Text nameCharacter;
    public Text inteligencia;
    public Text lasangas;
    public Text agylity;
    public Text force;
    public Text saveName;
    public Text saveInteligence;

    void Start()
    {
       
    }

    
    void Update()
    {
        container.text = GameManager.intance.lasangnas.ToString();
        nameCharacter.text = GameManager.intance.nameCharacter;
        inteligencia.text = GameManager.intance.inteligencia.ToString();
        lasangas.text = GameManager.intance.lasangas.ToString();
        agylity.text = GameManager.intance.agylity.ToString();
        force.text = GameManager.intance.agylity.ToString();
        
    }


    void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Lasaña"))
        {
            GameManager.intance.lasangnas += 1;
        }
    }

}
