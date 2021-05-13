using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffreParchemin : MonoBehaviour
{
    public GameObject topCoffre; // r�f�rence au dessus du coffre
    public GameObject interfaceParchemin;

    // Canvas � enlever
    public GameObject interfaceCanvas;

    //R�f�rence au bouton pause
    public GameObject pause; 

    private void OnCollisionEnter(Collision infoCollisions)
    {
        // Le coffre s'ouvre
        topCoffre.transform.Rotate(-180.0f, 0.0f, 0.0f);

        //La musique joue
        GetComponent<AudioSource>().Play();

        // D�sactiver le personnage et les ennemis
        pause.GetComponent<GestionInterface>().ArretJeu();

        // D�sactiver le canvas d'interface
        interfaceCanvas.SetActive(false);

        // Activer le canvas des parchemins
        interfaceParchemin.SetActive(true);
    }
}
