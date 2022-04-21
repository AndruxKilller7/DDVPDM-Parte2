using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    Animator anim;
    public string nameAnimation;
    
    void Start()
    {
        anim = GetComponent<Animator>();
     
    }

   
    void Update()
    {
       
    }


    public void ActivateAnimation()
    {
        anim.SetBool(nameAnimation, true);
    }

    public void EnableAnimation()
    {
        anim.SetBool(nameAnimation, false);
    }




}
