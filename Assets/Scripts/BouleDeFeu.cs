using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouleDeFeu : MonoBehaviour
{
    public GameObject bouleDeFeu;
    public GameObject epee;
    public GameObject personnage;
    private void OnCollisionEnter(Collision infoCollisions)
    {
        if(infoCollisions.gameObject.tag == "Ennemi"){ 
            infoCollisions.gameObject.GetComponent<Ennemis>().ToucheBouleDeFeu(); 
        }
        Destroy(gameObject);
    }

    void FixedUpdate(){
        Physics.IgnoreCollision(bouleDeFeu.GetComponent<Collider>(), epee.GetComponent<Collider>());
        Physics.IgnoreCollision(bouleDeFeu.GetComponent<Collider>(), personnage.GetComponent<Collider>());
    }
}
