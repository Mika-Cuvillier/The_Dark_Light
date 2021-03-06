using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Ennemis : MonoBehaviour
{
    /// ******************
    /// PAR MIKA CUVILLIER
    /// Gestion des ennemis
    /// Modifier: 25 mai 2021
    /// ******************

    public float vie; // nombre de vie de l'ennemi
    public GameObject positionPerso; // r�f�rence au personnage
    public bool arret;
    public bool finJeu;
    public float vitesseKnockback;

    // Update is called once per frame
    void Update()
    {
        // Si le dans le scripte de d�placement le jeu est sur pause ou que le dialogue est true
        if((DeplacementPersonnage.jeuPause == true) || (GestionCameras.conversation == true))
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

        if(finJeu == true)
        {
            SceneManager.LoadScene("Finale_Victoire");
        }
    }

    public void ToucheBouleDeFeu(){
        // si l'ennemi touche la boule de feu on enleve 50 de sa vie
        vie = vie -75;
        // si la vie est de 0, alors l'ennemi meurt
        
        if(vie <= 0){

            if(gameObject.tag == "Boss"){
                finJeu = true;
            }
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

            if(gameObject.tag == "Boss"){
                finJeu = true;
            }

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
