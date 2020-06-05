
using UnityEngine;
//Note: Make sure to change the Monobehaviour to whatever you name your script
public class CamerController : MonoBehaviour
{
    //The object the camera will follow
    public Transform target;

    //A Vector 3 that we can edit in the inspector
    public Vector3 offset;

    public static float smoothSpeed = 2f;

    private void LateUpdate()
    {   
       
        /*Alines the postion camera and sets it to the position of the target plus the offest and places all of that data into 
        desiredPosition*/
        Vector3 desiredPostion = target.position + offset;

        //Smooths the transiton of the camera form piont A (transform.position) to point B (desiredPostion) over time (smoothSpeed)
        Vector3 smoothedPositon = Vector3.Lerp(transform.position, desiredPostion, smoothSpeed);

        //Sets the postion of the camera to the smoothedPosition
        transform.position = smoothedPositon;
    }
}

/*To set up script - Go to: https://www.youtube.com/watch?v=MFQhpwc6cKE */
