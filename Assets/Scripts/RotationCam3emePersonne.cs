using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCam3emePersonne : MonoBehaviour
{
    
    public GameObject personnage;
    public GameObject camera3emePersonne;
    public GameObject positionRayCastCamera;
    public float hauteurPivot;
    public float distanceCameraLoin = -5;
    public float distanceCameraPret = -2;

    public static bool jeuPause;
    
    

    void Update()
    {
        if(jeuPause == false)
        {
            transform.position = personnage.transform.position + new Vector3(0, hauteurPivot, 0);
            transform.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

            transform.localEulerAngles = new Vector3(Mathf.Clamp(transform.localEulerAngles.x, 10, 80), transform.localEulerAngles.y, 0);


            if (Physics.Raycast(positionRayCastCamera.transform.position, positionRayCastCamera.transform.forward, -distanceCameraLoin))
            {
                camera3emePersonne.transform.localPosition = new Vector3(0, 1, distanceCameraPret);
            }
            else
            {
                camera3emePersonne.transform.localPosition = new Vector3(0, 0, distanceCameraLoin);
            }
        }

    }
    
}
