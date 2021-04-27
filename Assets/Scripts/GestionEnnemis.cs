using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GestionEnnemis : MonoBehaviour
{
    /// ******************
    /// PAR MIKA CUVILLIER
    /// ******************

    public GameObject ChauveSouris; // R�f�rence � l'ennemi chauve souris
    public GameObject Fantome; // R�f�rence � l'ennemi fant�me
    public GameObject Lapin; // R�f�rence � l'ennemi lapin
    public GameObject Slime; // R�f�rence � l'ennemi slime

    public float vie; // nombre de vie
    // Start is called before the first frame update
    void Start()
    {
        // Cr�ation des ennemis
        InvokeRepeating("CreationChauveSouris", 2f, 20f);
        InvokeRepeating("CreationFantomes", 2f, 25f);
        InvokeRepeating("CreationLapins", 2f, 15f);
        InvokeRepeating("CreationSlimes", 2f, 35f);
    }

    // Update is called once per frame
    public void Update()
    {
    }

    // Cr�ations des ennemis avec un Instantiate (copie)
    void CreationChauveSouris(){
        GameObject nouvelleChauveSouris= Instantiate(ChauveSouris);
        nouvelleChauveSouris.SetActive(true);
    }
    void CreationFantomes(){
        GameObject nouveauFantome= Instantiate(Fantome);
        nouveauFantome.SetActive(true);
    }
    void CreationLapins(){
        GameObject nouveauLapin= Instantiate(Lapin);
        nouveauLapin.SetActive(true);
    }
    void CreationSlimes(){
        GameObject nouveauSlime= Instantiate(Slime);
        nouveauSlime.SetActive(true);
    }

}
