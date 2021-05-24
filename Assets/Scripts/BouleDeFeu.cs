using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouleDeFeu : MonoBehaviour
{
    /// ******************
    /// PAR MIKA CUVILLIER
    /// ******************
   
    public GameObject bouleDeFeu; // Game Object � la boule de feu
    public GameObject epee; // Game Object de l'�p�e
    public GameObject personnage; // Game Object du personnage

    void Start()
    {
        // Ajout par Tamyla : On joue le son de la boule de feu
        bouleDeFeu.GetComponent<AudioSource>().Play();
    }

    private void OnCollisionEnter(Collision infoCollisions)
    {
        //Si la boule de feu touche un ennemi appelle fonction touchebouledefeu dans le scipte de l'ennemi
        if(infoCollisions.gameObject.tag == "Ennemi1"){ 
            infoCollisions.gameObject.GetComponent<Ennemis>().ToucheBouleDeFeu(); 
        }
        if(infoCollisions.gameObject.tag == "Ennemi2"){ 
            infoCollisions.gameObject.GetComponent<Ennemis>().ToucheBouleDeFeu(); 
        }
        if(infoCollisions.gameObject.tag == "Ennemi3"){ 
            infoCollisions.gameObject.GetComponent<Ennemis>().ToucheBouleDeFeu(); 
        }
        if(infoCollisions.gameObject.tag == "Ennemi4"){ 
            infoCollisions.gameObject.GetComponent<Ennemis>().ToucheBouleDeFeu(); 
        }
        if(infoCollisions.gameObject.tag == "Boss"){ 
            infoCollisions.gameObject.GetComponent<Ennemis>().ToucheBouleDeFeu(); 
        }
        Destroy(gameObject);
    }

    void FixedUpdate(){
        Physics.IgnoreCollision(bouleDeFeu.GetComponent<Collider>(), epee.GetComponent<Collider>());
        Physics.IgnoreCollision(bouleDeFeu.GetComponent<Collider>(), personnage.GetComponent<Collider>());
    }
}
