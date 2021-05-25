using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDialogue : MonoBehaviour
{
    /// ******************
    /// PAR MIKA CUVILLIER
    /// Caméra dialogue
    /// Modifier: 25 mars 2021
    /// ******************

    public GameObject laCible; // GameObject de la cible pour la cam�ra
    public Vector3 distance; // distance entre la cam�ra et la cible

    // Update is called once per frame
    void Update()
    {
        // transformation de la position de la cam�ra 
       transform.position = laCible.transform.position + distance;
    }
}
