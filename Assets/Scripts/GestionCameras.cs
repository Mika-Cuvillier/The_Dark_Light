using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCameras : MonoBehaviour
{
    /// ******************
    /// PAR MIKA CUVILLIER
    /// ******************
    
    public GameObject cam3emePersonne; // Game Object de la cam�ra 3e personne
    public GameObject camDialogue; // Game Object de la cam�ra dialogue
    public static bool dialogue; // bool�enne du dialogue

    // Start is called before the first frame update
    void Start()
    {
        //Au d�but, la cam�ra 3e personne est activ�
        cam3emePersonne.SetActive(true);
        camDialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Si le dialogue est activ� alors on change de cam�ra
        if(dialogue){
            cam3emePersonne.SetActive(false);
            camDialogue.SetActive(true);
        }else{
            cam3emePersonne.SetActive(true);
            camDialogue.SetActive(false);
        }
    }
}
