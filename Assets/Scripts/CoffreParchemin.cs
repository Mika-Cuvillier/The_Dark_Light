using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffreParchemin : MonoBehaviour
{
    /// ************************
    /// PAR TAMYLA AIT-CHELLOUCHE
    /// *************************
    
    public GameObject topCoffre; // r�f�rence au dessus du coffre
    public GameObject interfaceUi; // reference au canvas d'interface du jeu
    public GameObject btnFermer; // reference au bouton pour fermer le canvas;



    
    

    private void OnCollisionEnter(Collision infoCollisions)
    {

        // Le coffre s'ouvre
        topCoffre.transform.Rotate(-180.0f, 0.0f, 0.0f);

        //La musique joue
        GetComponent<AudioSource>().Play();

        //le bouton apparait
        btnFermer.SetActive(true);

      
    }
}
