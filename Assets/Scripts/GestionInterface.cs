using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GestionInterface : MonoBehaviour
{
    // Script pour mettre le jeu � l'arr�t Marc-Antoine Sicotte 2021-03-24
    public GameObject lePerso;

    // Start is called before the first frame update


    public void ArretJeu() 
    {
        lePerso.GetComponent<Animator>().enabled = false;
        DeplacementPersonnage.jeuPause = true;
        RotationCam3emePersonne.jeuPause = true;
    }

    public void RelancerJeu()
    {
        lePerso.GetComponent<Animator>().enabled = true;
        DeplacementPersonnage.jeuPause = false;
        RotationCam3emePersonne.jeuPause = false;
    }


}
