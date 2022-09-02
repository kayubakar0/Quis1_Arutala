using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLogo : MonoBehaviour
{
    private Quaternion rotationY;
    private float initialDistance;
    private Vector3 initialScale;
    public GameObject objek;
    // Update is called once per frame
    void Update()
    {
        //touch screen to rotate logo in y axis only
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchPosition = touch.deltaPosition;
                rotationY = Quaternion.Euler(0f, -touchPosition.x * 100 * Time.deltaTime, 0f);
                transform.rotation = rotationY * transform.rotation;
            }
        }

        //pinch to change object scale without chnage location
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            if (touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled || touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled){
                return;
            }

            if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began){
                initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
                initialScale = objek.transform.localScale;
            } else{
                var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);
                if (Mathf.Approximately(initialDistance, 0)){
                    return;
                }

                var factor = currentDistance / initialDistance;
                objek.transform.localScale = initialScale * factor;
            }

            // Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            // Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            // float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            // float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
            // float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            // transform.localScale += new Vector3(deltaMagnitudeDiff * 0.01f, deltaMagnitudeDiff * 0.01f, deltaMagnitudeDiff * 0.01f); 
        }
        
        
        
    }

}
