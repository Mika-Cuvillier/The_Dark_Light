using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemis : MonoBehaviour
{
    public float vie;
    public GameObject positionPerso;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<NavMeshAgent>().enabled == true){ 
            GetComponent<NavMeshAgent>().SetDestination(positionPerso.transform.position);
        }
    }

    public void ToucheBouleDeFeu(){
        vie = vie -75;
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
        vie = vie -50;
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
}
