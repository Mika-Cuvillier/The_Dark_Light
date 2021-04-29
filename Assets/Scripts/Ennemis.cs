using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemis : MonoBehaviour
{
    /// ******************
    /// PAR MIKA CUVILLIER
    /// ******************

    public float vie; // nombre de vie de l'ennemi
    public GameObject positionPerso; // r�f�rence au personnage
    public bool arret;
    public float vitesseKnockback;
    /* private float forceKnockback =10; */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Si le dans le scripte de d�placement le jeu est sur pause
        if(DeplacementPersonnage.jeuPause == true)
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }
        else
        {
            GetComponent<NavMeshAgent>().enabled = true;
        }
        
        if(GetComponent<NavMeshAgent>().enabled == true){ 
            GetComponent<NavMeshAgent>().SetDestination(positionPerso.transform.position);
        }

        if(arret == true){
            GetComponent<NavMeshAgent>().enabled = false;
        }
        else{
            GetComponent<NavMeshAgent>().enabled = true;
        }
    }

    public void ToucheBouleDeFeu(){
        // si l'ennemi touche la boule de feu on enleve 50 de sa vie
        vie = vie -75;
        // si la vie est de 0, alors l'ennemi meurt
        if(vie <= 0){
            GetComponent<Animator>().SetBool("mort", true);
            GetComponent<NavMeshAgent>().enabled = false; 
            gameObject.tag = "Untagged"; 
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject, 2f);

            // Ajouter par Tamyla
            GetComponent<AudioSource>().Play(); // Joue son mort de l'ennemi
        }
    }

    public void AttaqueEpee(){
        // si l'ennemi touche l'�p�e on enleve 50 de sa vie
        vie = vie -50;
        // si la vie est de 0, alors l'ennemi meurt
        if (vie <= 0){
            GetComponent<Animator>().SetBool("mort", true);
            GetComponent<NavMeshAgent>().enabled = false; 
            gameObject.tag = "Untagged"; 
            GetComponent<Collider>().enabled = false; 
            Destroy(gameObject, 2f);
            /* Vector3 direction = transform.position - transform.position;
            direction.y = 0;
            GetComponent<Rigidbody>().AddForce(direction.normalized * forceKnockback, ForceMode.Impulse); */

            // Ajouter par Tamyla
            GetComponent<AudioSource>().Play(); // Joue son mort de l'ennemi
        }
    }

    public void animationAttaque()
    {
        // Animation d'attaque
        GetComponent<Animator>().SetBool("attaque", true);
        Invoke("cancelAttaque", 2f);
        arret = true;
        Invoke("cancelArret", 1.5f); 
    }

    void cancelAttaque()
    {
        // Arr�t de l'animation d'attaque
        GetComponent<Animator>().SetBool("attaque", false);
    }
    void cancelArret(){
        arret = false;
    } 
}
