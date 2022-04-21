using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBall : MonoBehaviour
{
    public GameObject ball;
    public Transform pivot;
    void Start()
    {
        StartCoroutine(Shooting());
    }

    
    void Update()
    {
        
    }


    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(ball, pivot.transform.position, pivot.transform.rotation);
    }
}
