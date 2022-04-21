using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;


public class SkinManager : MonoBehaviour
{
    public DatesP character1;
    public DatesP character2;
    private SpriteResolver head;
    private SpriteResolver leftarm;
    private SpriteResolver rightarm;
    private SpriteResolver lefthand;
    private SpriteResolver righthand;
    private SpriteResolver leftleg;
    private SpriteResolver rightleg;
    private SpriteResolver leftfoot;
    private SpriteResolver rightfoot;
    private SpriteResolver hair;
    private SpriteResolver body;

    

   

    void Start()
    {
        head = GameObject.Find("head_0").GetComponent<SpriteResolver>();
        leftarm = GameObject.Find("arm_r").GetComponent<SpriteResolver>();
        rightarm = GameObject.Find("arm_l").GetComponent<SpriteResolver>();
        leftleg = GameObject.Find("leg_r").GetComponent<SpriteResolver>();
        rightleg = GameObject.Find("leg_l").GetComponent<SpriteResolver>();
        leftfoot = GameObject.Find("foot_r").GetComponent<SpriteResolver>();
        rightfoot = GameObject.Find("foot_l").GetComponent<SpriteResolver>();
        lefthand = GameObject.Find("hand_r").GetComponent<SpriteResolver>();
        righthand = GameObject.Find("hand_l").GetComponent<SpriteResolver>();
        hair = GameObject.Find("hair").GetComponent<SpriteResolver>();
        body = GameObject.Find("body").GetComponent<SpriteResolver>();
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
