using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDialogue : MonoBehaviour
{
    /// ******************
    /// PAR MIKA CUVILLIER
    /// ******************

    public GameObject laCible; // GameObject de la cible pour la caméra
    public Vector3 distance; // distance entre la caméra et la cible

    // Update is called once per frame
    void Update()
    {
        // transformation de la position de la caméra 
       transform.position = laCible.transform.position + distance;
    }
}
