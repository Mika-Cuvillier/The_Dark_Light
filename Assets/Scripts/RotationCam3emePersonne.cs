using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCam3emePersonne : MonoBehaviour
{
    /// ******************
    /// PAR MIKA CUVILLIER
    /// ******************

    public GameObject personnage; // Game Object du personnage
    public GameObject camera3emePersonne; // Game Object de la cam�ra 3e personne
    public GameObject positionRayCastCamera; // Game Object de la position du ray cast de la cam�ra
    public float hauteurPivot; // la hauteur du pivot
    public float distanceCameraLoin = -5; // la distance de la cam�ra de loin
    public float distanceCameraPret = -2; // la distance de la cam�ra de proche
    public float vitesseCameraX;
    public float vitesseCameraY;
    public static bool jeuPause; // bool�enne si le jeu est sur pause
    
    

    void Update()
    {
        // Si le jeu n'est pas sur pause
        if(jeuPause == false)
        {
            transform.position = personnage.transform.position + new Vector3(0, hauteurPivot, 0);
            transform.Rotate(-Input.GetAxis("Mouse Y") * vitesseCameraY, Input.GetAxis("Mouse X") * vitesseCameraX, 0);

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
