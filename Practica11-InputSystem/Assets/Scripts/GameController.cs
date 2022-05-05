using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject map;
    public GameObject closeButton;
    public Camera main;
    Vector3 startPositionCamera;
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;
    bool mapaActivo;

    void Start()
    {
        startPositionCamera = new Vector3(main.transform.position.x, main.transform.position.y, main.transform.position.z);
    }

    
    void Update()
    {
        MultiTouchTeclado();
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("zoom");
            touchStart = main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(touchStart);
        }
        if(mapaActivo)
        {
            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;
                if (difference > 0)
                {
                    print("accion1");
                }
                else
                {
                    print("accion2");
                }
                zoom(difference * 0.01f);
            }

            else if (Input.GetMouseButton(0))
            {
                Vector3 direction = touchStart - main.ScreenToWorldPoint(Input.mousePosition);
                Camera.main.transform.position += direction;
            }
            zoom(Input.GetAxis("Mouse ScrollWheel"));
        }
       
    }

    public void DesplegarMapa()
    {
        map.gameObject.SetActive(true);
        closeButton.SetActive(true);
        mapaActivo = true;
    }

    public void CerrarMapa()
    {
        map.gameObject.SetActive(false);
        closeButton.SetActive(false);
        main.orthographicSize = 5f;
        main.transform.position = new Vector3(startPositionCamera.x, startPositionCamera.y, startPositionCamera.z);
        mapaActivo = false;
    }

    public void MultiTouchTeclado()
    {
        
    }

    public void MultiTouch()
    {
        
    }

    void zoom(float increment)
    {
        main.orthographicSize = Mathf.Clamp(main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

    /* void zoomPerspectiva(float increment)
     {
         Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
     }*/
}
