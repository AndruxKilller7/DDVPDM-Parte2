using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
   
    void Start()
    {
        Destroy(this.gameObject, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
