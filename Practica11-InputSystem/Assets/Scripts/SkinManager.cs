using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SkinManager : MonoBehaviour
{
    public DatesP character1;
    public DatesP character2;
    private UnityEngine.U2D.Animation.SpriteResolver head;
    private UnityEngine.U2D.Animation.SpriteResolver leftarm;
    private UnityEngine.U2D.Animation.SpriteResolver rightarm;
    private UnityEngine.U2D.Animation.SpriteResolver lefthand;
    private UnityEngine.U2D.Animation.SpriteResolver righthand;
    private UnityEngine.U2D.Animation.SpriteResolver leftleg;
    private UnityEngine.U2D.Animation.SpriteResolver rightleg;
    private UnityEngine.U2D.Animation.SpriteResolver leftfoot;
    private UnityEngine.U2D.Animation.SpriteResolver rightfoot;
    private UnityEngine.U2D.Animation.SpriteResolver hair;
    private UnityEngine.U2D.Animation.SpriteResolver body;

    

   

    void Start()
    {
        head = GameObject.Find("head_0").GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();
        leftarm = GameObject.Find("arm_r").GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();
        rightarm = GameObject.Find("arm_l").GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();
        leftleg = GameObject.Find("leg_r").GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();
        rightleg = GameObject.Find("leg_l").GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();
        leftfoot = GameObject.Find("foot_r").GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();
        rightfoot = GameObject.Find("foot_l").GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();
        lefthand = GameObject.Find("hand_r").GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();
        righthand = GameObject.Find("hand_l").GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();
        hair = GameObject.Find("hair").GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();
        body = GameObject.Find("body").GetComponent<UnityEngine.U2D.Animation.SpriteResolver>();
    }

  
    void Update()
    {
        
    }

    public void SelectCharacter1()
    {
        head.SetCategoryAndLabel("Head", "Normal");
        lefthand.SetCategoryAndLabel("LeftHand", "Normal");
        righthand.SetCategoryAndLabel("RightHand", "Normal");
        body.SetCategoryAndLabel("Body", "Normal");
        hair.SetCategoryAndLabel("Hair", "Normal");
        leftfoot.SetCategoryAndLabel("LeftFoot", "Normal");
        rightfoot.SetCategoryAndLabel("RightFoot", "Normal");
        leftleg.SetCategoryAndLabel("LeftLeg", "Normal");
        rightleg.SetCategoryAndLabel("RightLeg", "Normal");
        leftarm.SetCategoryAndLabel("LeftArm", "Normal");
        rightarm.SetCategoryAndLabel("RightArm", "Normal");

        GameManager.intance.nameCharacter = character1.nameCharacter;
        GameManager.intance.inteligencia = character1.inteligencia;
        GameManager.intance.lasangas = character1.lasangas;
        GameManager.intance.agylity = character1.agylity;
        GameManager.intance.force = character1.force;
    }
    public void SelectCharacter2()
    {
        head.SetCategoryAndLabel("Head", "Skull");
        lefthand.SetCategoryAndLabel("LeftHand", "Skull");
        righthand.SetCategoryAndLabel("RightHand", "Skull");
        body.SetCategoryAndLabel("Body", "Skull");
        hair.SetCategoryAndLabel("Hair", "Skull");
        leftfoot.SetCategoryAndLabel("LeftFoot", "Skull");
        rightfoot.SetCategoryAndLabel("RightFoot", "Skull");
        leftleg.SetCategoryAndLabel("LeftLeg", "Skull");
        rightleg.SetCategoryAndLabel("RightLeg", "Skull");
        leftarm.SetCategoryAndLabel("LeftArm", "Skull");
        rightarm.SetCategoryAndLabel("RightArm", "Skull");


        GameManager.intance.nameCharacter = character2.nameCharacter;
        GameManager.intance.inteligencia = character2.inteligencia;
        GameManager.intance.lasangas = character2.lasangas;
        GameManager.intance.agylity = character2.agylity;
        GameManager.intance.force = character2.force;

    }
}
