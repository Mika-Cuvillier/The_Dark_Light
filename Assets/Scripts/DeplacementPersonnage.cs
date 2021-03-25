using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementPersonnage : MonoBehaviour
{
    
    public GameObject camera3emePersonne;
    public GameObject personnage;
    public GameObject pivotRotation;
    float vitesseDeplacement;
    public float hauteurSaut;
    public float ajoutGravite;
    private float forceDuSaut;
    public static bool jeuPause; // Variable Static pour permettre d'arrêter la détection des touches quand le jeu est en pause Marc-Antoine Sicotte 2021-03-24
    private bool auSol;
    Rigidbody rigidbodyPersonnage;

    void Start()
    {
        rigidbodyPersonnage = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
       if((jeuPause == false && GestionCameras.dialogue == false))
        {
            float hDeplacement = Input.GetAxisRaw("Horizontal");
            float vDeplacement = Input.GetAxisRaw("Vertical");

            Vector3 directionDep = camera3emePersonne.transform.forward * vDeplacement + camera3emePersonne.transform.right * hDeplacement;

            directionDep.y = 0;
            if (directionDep != Vector3.zero)
            {
                transform.forward = directionDep;
                rigidbodyPersonnage.velocity = (transform.forward * vitesseDeplacement) + new Vector3(0, rigidbodyPersonnage.velocity.y, 0);
            }
            else
            {
                rigidbodyPersonnage.velocity = new Vector3(0, rigidbodyPersonnage.velocity.y, 0);
            }

            if (vitesseDeplacement <= 10f && Input.GetKey("w"))
            {
                vitesseDeplacement += 0.05f;
            }
            else if (vitesseDeplacement >= 10 && Input.GetKey("w"))
            {
                vitesseDeplacement = 10;
            }
            else
            {
                vitesseDeplacement = 0;
            }

            GetComponent<Animator>().SetFloat("vitesse", vitesseDeplacement);

            RaycastHit infoCollision;
            auSol = Physics.SphereCast(transform.position + new Vector3(0f, 0.5f, 0f), 0.2f, -Vector3.up, out infoCollision, 0.8f);

            GetComponent<Animator>().SetBool("sauter", !auSol);

            if (Input.GetKeyDown(KeyCode.Space) && auSol)
            {
                forceDuSaut = hauteurSaut;
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                GetComponent<Animator>().SetBool("épée", true);
                Invoke("EnleverAnimationEpee", 0.2f);
            }
        }

    }
    
    void FixedUpdate(){
        if(auSol) {
            GetComponent<Rigidbody>().AddRelativeForce(0f, forceDuSaut, rigidbodyPersonnage.velocity.y, ForceMode.VelocityChange);
        }else{
            GetComponent<Rigidbody>().AddRelativeForce(0f, ajoutGravite, rigidbodyPersonnage.velocity.y, ForceMode.VelocityChange);
        }
        forceDuSaut = 0f;
    }

    void EnleverAnimationEpee(){
        GetComponent<Animator>().SetBool("épée", false);
    }
}
