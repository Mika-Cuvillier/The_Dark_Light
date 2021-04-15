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
    public GameObject positionPerso; // référence au personnage

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Si le dans le scripte de déplacement le jeu est sur pause
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
        // si l'ennemi touche l'épée on enleve 50 de sa vie
        vie = vie -50;
        // si la vie est de 0, alors l'ennemi meurt
        if (vie <= 0){
            GetComponent<Animator>().SetBool("mort", true);
            GetComponent<NavMeshAgent>().enabled = false; 
            gameObject.tag = "Untagged"; 
            GetComponent<Collider>().enabled = false; 
            Destroy(gameObject, 2f);

            // Ajouter par Tamyla
            GetComponent<AudioSource>().Play(); // Joue son mort de l'ennemi
        }
    }

    public void animationAttaque()
    {
        // Animation d'attaque
        GetComponent<Animator>().SetBool("attaque", true);
        Invoke("cancelAttaque", 2f);
    }

    void cancelAttaque()
    {
        // Arrêt de l'animation d'attaque
        GetComponent<Animator>().SetBool("attaque", false);
    }
}
