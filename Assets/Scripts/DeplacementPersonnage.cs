using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeplacementPersonnage : MonoBehaviour
{
    
    public GameObject camera3emePersonne;
    public GameObject personnage;
    public GameObject pivotRotation;
    public GameObject leCube; // objet a ramasser pour tester l'inventaire Marc-Antoine Sicotte 2021-03-30
    public GameObject imageCube;
    public Image barreVie;
    public Text indicatifInventaire; // Variable affichant la quantité des objets ramasser dans l'inventaire Marc-Antoine Sicotte 2021-04-13
    private int nbObjetRamasser; // Nombre d'objet ramasser (cube) Marc-Antoine Sicotte 2021-04-13
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

            ////////////////////////// ZONE TESTE BARRE DE VIE /////////////


            barreVie.fillAmount += 0.0001f;
            if (Input.GetKeyDown("b"))
            {

                barreVie.fillAmount -= 0.1f;
            }

           
        }

    }

    //******************************************************** DÉTECTTION COLLISION **************************************//
    void OnCollisionEnter(Collision infosCollission)
    {
        if (infosCollission.gameObject.tag == "cube")
        {
           
                imageCube.SetActive(true);
                leCube.SetActive(false);
                nbObjetRamasser += 1;
                indicatifInventaire.text += nbObjetRamasser;



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
