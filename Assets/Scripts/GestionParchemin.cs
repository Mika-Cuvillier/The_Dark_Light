using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionParchemin : MonoBehaviour
{
    public GameObject pause; //R�f�rence au bouton pause
    public GameObject interfaceCanvas; // R�f�rence au canvas d'interface
    public GameObject interfaceParchemin; // R�f�rence au canvas des parchemins
    public GameObject leParchemin; // R�f�rence au parchemin d�sir�
    public GameObject topCoffre; // r�f�rence au dessus du coffre

    // Start is called before the first frame update
    public void GestionParcheminTest()
    {
        // D�sactiver le personnage et les ennemis
        pause.GetComponent<GestionInterface>().RelancerJeu();

        //Activer le canvas d'interface
        interfaceCanvas.SetActive(true);

        //D�sactiver le canvas des parchemins
        interfaceParchemin.SetActive(false);

        // D�sactiver le parchemin d�sir�e
        leParchemin.SetActive(false);

        //Refermer le coffre
        Invoke("RefermerLeCoffre", 2f);
    }

    void RefermerLeCoffre()
    {
        topCoffre.transform.Rotate(180.0f, 0.0f, 0.0f);
    }
}
