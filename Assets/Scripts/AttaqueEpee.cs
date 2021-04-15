using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueEpee : MonoBehaviour
{
    /// ******************
    /// PAR MIKA CUVILLIER
    /// ******************

    private void OnCollisionEnter(Collision infoCollisions)
    {
        // Si l'épée entre en collision avec l'ennemi on appelle la fonction attaqueepee dans le scipt de l'ennemi
        if(infoCollisions.gameObject.tag == "Ennemi"){ 
            infoCollisions.gameObject.GetComponent<Ennemis>().AttaqueEpee(); 
        }
    }
}
