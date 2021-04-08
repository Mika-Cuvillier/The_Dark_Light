using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouleDeFeu : MonoBehaviour
{
    private void OnCollisionEnter(Collision infoCollisions)
    {
        if(infoCollisions.gameObject.tag == "Ennemi"){ 
            infoCollisions.gameObject.GetComponent<Ennemis>().ToucheBouleDeFeu(); 
        }
        Destroy(gameObject);
    }
}
