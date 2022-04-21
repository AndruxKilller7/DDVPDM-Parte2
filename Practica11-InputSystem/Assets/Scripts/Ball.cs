using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float velocidad = 5f;
    void Start()
    {
        StartCoroutine(Destroyed());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
    }

    IEnumerator Destroyed()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject, 2f);
    }
}
