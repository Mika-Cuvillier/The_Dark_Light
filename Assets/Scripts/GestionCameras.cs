using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCameras : MonoBehaviour
{
    public GameObject cam3emePersonne;
    public GameObject camDialogue;
    public static bool dialogue;
    // Start is called before the first frame update
    void Start()
    {
        cam3emePersonne.SetActive(true);
        camDialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogue){
            cam3emePersonne.SetActive(false);
            camDialogue.SetActive(true);
        }else{
            cam3emePersonne.SetActive(true);
            camDialogue.SetActive(false);
        }
    }
}
