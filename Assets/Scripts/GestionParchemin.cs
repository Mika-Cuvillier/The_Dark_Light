using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionParchemin : MonoBehaviour
{
    public GameObject pause; //Référence au bouton pause
    public GameObject interfaceCanvas; // Référence au canvas d'interface
    public GameObject interfaceParchemin; // Référence au canvas des parchemins
    public GameObject topCoffre; // référence au dessus du coffre

    public void RetourCoffre()
    {
        // Désactiver le personnage et les ennemis
        pause.GetComponent<GestionInterface>().RelancerJeu();

        //Activer le canvas d'interface
        interfaceCanvas.SetActive(true);

        //Désactiver le canvas des parchemins
        interfaceParchemin.SetActive(false);

        //Refermer le coffre
        Invoke("RefermerLeCoffre", 2f);
    }

    void RefermerLeCoffre()
    {
        topCoffre.transform.Rotate(180.0f, 0.0f, 0.0f);
    }
}
