using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionProphetie : MonoBehaviour
{
    /// ************************
    /// PAR TAMYLA AIT-CHELLOUCHE
    /// *************************
    
    public GameObject interfaceProphetie; // R�f�rence au canvas des parchemins
    public GameObject pause; //R�f�rence au bouton pause
    public GameObject interfaceCanvas; // R�f�rence au canvas d'interface
    public GameObject topCoffre; // r�f�rence au dessus du coffre


    public void DesactiverProphetie()
    {
        //Activer Canvas de la prophetie
        interfaceProphetie.SetActive(false);

        // R�activer le personnage et les ennemis
        pause.GetComponent<GestionInterface>().RelancerJeu();

        //Activer le canvas d'interface
        interfaceCanvas.SetActive(true);

        //Refermer le coffre
        Invoke("RefermerLeCoffre", 2f);

    }

    void RefermerLeCoffre()
    {
        topCoffre.transform.Rotate(180.0f, 0.0f, 0.0f);
    }
}