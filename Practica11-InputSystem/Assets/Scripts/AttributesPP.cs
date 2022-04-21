using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttributesPP : MonoBehaviour
{
    public float volume;
    public string subtitles;
    public float voicesAndEffects=100f;
    public Image musicBar;
    public Image voicesEffectsBar;
    public Text subtitlesText;
    public GameObject options;
    public GameObject buttons;
    void Start()
    {
        subtitles = "On";
        volume = PlayerPrefs.GetFloat("volumeSave");
        voicesAndEffects = PlayerPrefs.GetFloat("volumenVandE");
        subtitles = PlayerPrefs.GetString("subtitlesSave");
        

    }


    void Update()
    {
        volume = Mathf.Clamp(volume, 0, 100);
        musicBar.fillAmount = volume / 100;

        voicesAndEffects = Mathf.Clamp(voicesAndEffects, 0, 100);
        voicesEffectsBar.fillAmount = voicesAndEffects / 100;

        subtitlesText.text = subtitles;
    }

    public void SaveData()
    {


        PlayerPrefs.SetFloat("volumeSave", volume);
        PlayerPrefs.SetFloat("volumenVandE", voicesAndEffects);
        PlayerPrefs.SetString("subtitlesSave", subtitles);

    }
    
    public void ResetData()
    {
        volume = 100f;
        subtitles = "On";
        voicesAndEffects = 100f;

        PlayerPrefs.SetFloat("volumeSave", volume);
        PlayerPrefs.SetFloat("volumenVandE", voicesAndEffects);
        PlayerPrefs.SetString("subtitlesSave", subtitles);

    }


    public void AumentarMusica()
    {
        volume += 1f;
        //PlayerPrefs.SetFloat("volumeSave", volume);
    }
    public void DisminuirMusica()
    {
        volume -= 1f;
        //PlayerPrefs.SetFloat("volumeSave", volume);
    }

    public void AumentarVandE()
    {
        voicesAndEffects += 1f;
        //PlayerPrefs.SetFloat("volumeSave", volume);
    }
    public void DisminuirVandE()
    {
        voicesAndEffects -= 1f;
        //PlayerPrefs.SetFloat("volumeSave", volume);
    }

    public void ActivarSubtitles()
    {
        subtitles = "On";
        //PlayerPrefs.SetFloat("volumeSave", volume);
    }
    public void DesactivarSubtitles()
    {
        subtitles = "Off";
        //PlayerPrefs.SetFloat("volumeSave", volume);
    }


    public void DesplegarOpciones()
    {
        buttons.SetActive(false);
        options.SetActive(true);
    }

}
