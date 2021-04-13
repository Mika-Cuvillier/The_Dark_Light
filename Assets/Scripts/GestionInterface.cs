using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GestionInterface : MonoBehaviour
{
    // Script pour mettre le jeu � l'arr�t Marc-Antoine Sicotte 2021-03-24
    public GameObject lePerso;
    public GameObject slime;
    public GameObject fantome;
    public GameObject chauvesouris;
    public GameObject lapin;

    // Start is called before the first frame update


    public void ArretJeu() 
    {
        slime.GetComponent<NavMeshAgent>().enabled = false;
        fantome.GetComponent<NavMeshAgent>().enabled = false;
        chauvesouris.GetComponent<NavMeshAgent>().enabled = false;
        lapin.GetComponent<NavMeshAgent>().enabled = false;
        lePerso.GetComponent<Animator>().enabled = false;
        DeplacementPersonnage.jeuPause = true;
        RotationCam3emePersonne.jeuPause = true;
    }

    public void RelancerJeu()
    {
        slime.GetComponent<NavMeshAgent>().enabled = true;
        fantome.GetComponent<NavMeshAgent>().enabled = true;
        chauvesouris.GetComponent<NavMeshAgent>().enabled = true;
        lapin.GetComponent<NavMeshAgent>().enabled = true;
        lePerso.GetComponent<Animator>().enabled = true;
        DeplacementPersonnage.jeuPause = false;
        RotationCam3emePersonne.jeuPause = false;
    }


}
