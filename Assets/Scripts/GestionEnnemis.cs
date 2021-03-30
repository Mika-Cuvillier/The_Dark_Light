using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionEnnemis : MonoBehaviour
{

    public GameObject ChauveSouris;
    public GameObject Fantome;
    public GameObject Lapin;
    public GameObject Slime;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreationChauveSouris", 2f, 5f);
        InvokeRepeating("CreationFantomes", 2f, 3f);
        InvokeRepeating("CreationLapins", 2f, 5f);
        InvokeRepeating("CreationSlimes", 2f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
