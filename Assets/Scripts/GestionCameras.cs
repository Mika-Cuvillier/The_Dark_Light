using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCameras : MonoBehaviour
{
    /// ******************
    /// PAR MIKA CUVILLIER
    /// ******************
    
    public GameObject cam3emePersonne; // Game Object de la caméra 3e personne
    public GameObject camDialogue; // Game Object de la caméra dialogue
    public static bool dialogue; // booléenne du dialogue

    // Start is called before the first frame update
    void Start()
    {
        //Au début, la caméra 3e personne est activé
        cam3emePersonne.SetActive(true);
        camDialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Si le dialogue est activé alors on change de caméra
        if(dialogue){
            cam3emePersonne.SetActive(false);
            camDialogue.SetActive(true);
        }else{
            cam3emePersonne.SetActive(true);
            camDialogue.SetActive(false);
        }
    }
}
