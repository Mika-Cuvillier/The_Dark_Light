using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueEpee : MonoBehaviour
{
    /// ******************
    /// PAR MIKA CUVILLIER
    /// ******************

    private float forceKnockback =250;
    public AudioClip sonKnockback;
    public Material MatSlime;

    private void OnCollisionEnter(Collision infoCollisions)
    {
        // Si l'�p�e entre en collision avec l'ennemi on appelle la fonction attaqueepee dans le scipt de l'ennemi
        if(infoCollisions.gameObject.tag == "Ennemi1"){ 
            infoCollisions.gameObject.GetComponent<Ennemis>().AttaqueEpee();
            infoCollisions.gameObject.GetComponent<AudioSource>().PlayOneShot(sonKnockback, 2f);
            infoCollisions.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Vector3 direction = infoCollisions.transform.position - transform.parent.position;
            direction.y = 0;
            infoCollisions.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * forceKnockback, ForceMode.Impulse);  
        }
        if(infoCollisions.gameObject.tag == "Ennemi2"){ 
            infoCollisions.gameObject.GetComponent<Ennemis>().AttaqueEpee();
            infoCollisions.gameObject.GetComponent<AudioSource>().PlayOneShot(sonKnockback, 2f);
            infoCollisions.gameObject.GetComponent<Renderer>().material = MatSlime;
            Vector3 direction = infoCollisions.transform.position - transform.parent.position;
            direction.y = 0;
            infoCollisions.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * forceKnockback, ForceMode.Impulse); 
        }
        if(infoCollisions.gameObject.tag == "Ennemi3"){ 
            infoCollisions.gameObject.GetComponent<Ennemis>().AttaqueEpee(); 
            infoCollisions.gameObject.GetComponent<AudioSource>().PlayOneShot(sonKnockback, 2f);
            infoCollisions.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Vector3 direction = infoCollisions.transform.position - transform.parent.position;
            direction.y = 0;
            infoCollisions.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * forceKnockback, ForceMode.Impulse); 
        }
        if(infoCollisions.gameObject.tag == "Ennemi4"){ 
            infoCollisions.gameObject.GetComponent<Ennemis>().AttaqueEpee(); 
            infoCollisions.gameObject.GetComponent<AudioSource>().PlayOneShot(sonKnockback, 2f);
            infoCollisions.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Vector3 direction = infoCollisions.transform.position - transform.parent.position;
            direction.y = 0;
            infoCollisions.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * forceKnockback, ForceMode.Impulse); 
        }
    }
}
