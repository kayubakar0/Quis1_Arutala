using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoominOut : MonoBehaviour
{
    Camera mainCamera;
    public float zoomsize = 60f;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.fieldOfView = zoomsize;
    }

    public void sliderZoom(float zoom){
        zoomsize = zoom;
    }
}
