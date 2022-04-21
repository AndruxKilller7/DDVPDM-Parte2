using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HUDManager : MonoBehaviour
{
    public Image barlife;

    public Text cantidadText;
    public float cantidad;
    void Start()
    {

    }


    void Update()
    {
        cantidad = GameManager.intance.life;
        cantidad = Mathf.Clamp(cantidad, 0, 100);
        barlife.fillAmount = cantidad / 100;
        cantidadText.text = cantidad.ToString() + "%";
    }

    public void SaveDates()
    {
        GameManager.intance.SaveGame();
    }

    public void LoadDates()
    {
        GameManager.intance.LoadGame();
    }

    public void DisminuirVida()
    {
        GameManager.intance.datesHUD.cantidadDeVida -= 5f;
        GameManager.intance.life -= 5;
    }

    public void AumentarVida()
    {
        GameManager.intance.datesHUD.cantidadDeVida += 5f;
        GameManager.intance.life += 5;
    }
}
