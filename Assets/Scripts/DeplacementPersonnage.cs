using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DeplacementPersonnage : MonoBehaviour
{
    /// ************************
    /// PAR MIKA CUVILLIER
    /// *************************

    public GameObject camera3emePersonne; // Variable contenant la caméra 3e personne
    public GameObject personnage; // GameObject du personnage
    public GameObject pivotRotation; // updated du pivot pour la caméra
    public GameObject vraisEpee; // Variable contenant l'epee dans la main du perso Marc-Antoine Sicotte 2021-04-15
    public GameObject epee; // Objet a ramasser pour tester l'inventaire Marc-Antoine Sicotte 2021-03-30
    public GameObject imageEpee; // Ajout par M-A
    public GameObject lucioleDebut; // GameObject qui réfère au premier png que le héro rencontre Marc-Antoine Sicotte 2021-05-04
    public GameObject uiDialogue; // GameObject de la boite de dialogue Marc-Antoine Sicotte 2021-05-04
    public GameObject discours; // GameObject du discours du PNG Marc-Antoine Sicotte 2021-05-11
    public GameObject nomPNG; // GameObject du nom du PNG Marc-Antoine Sicotte 2021-05-11
    public Image barreVie; // Ajout par M-A
    public Text indicatifInventaire; // Variable affichant la quantité des objets ramasser dans l'inventaire Marc-Antoine Sicotte 2021-04-13
    private int nbObjetRamasser; // Nombre d'objet ramasser (cube) Marc-Antoine Sicotte 2021-04-13
    float vitesseDeplacement; // Variable pour la vitesse de déplacement
    public float hauteurSaut; // Variable pour la hauteur du saut
    public float ajoutGravite; // Variable pour la gravité
    private float forceDuSaut; // Variable pour la force du saut
    public static bool jeuPause; // Variable Static pour permettre d'arrêter la détection des touches quand le jeu est en pause Marc-Antoine Sicotte 2021-03-24
    private bool auSol; // booléenne lorsque le personnage est au sol
    public bool epeeEnMain;
    private bool triggerEpee;
    public bool saut;
    public bool luciole;
    Rigidbody rigidbodyPersonnage; // Rigidbody du personnage

    // Ajout par Tamyla :
    public AudioClip sonObjet; // Audio Clip du son lorsqu'un objet est ramassé
    public AudioClip sonEpee; // Audio Clip lorsqu'on attaque avec l'épée

    void Start()
    {
        // On défini le rigidbody du personnage
        rigidbodyPersonnage = GetComponent<Rigidbody>();
        vraisEpee.GetComponent<Collider>().enabled = false;
        epeeEnMain = false;
        

        if ((SceneManager.GetActiveScene().name == "Lagrotte") || (SceneManager.GetActiveScene().name == "LaProphetie")){
            epeeEnMain = true;
        }
    }

    
    void Update()
    {
        // Si le jeu n'est pas en pause et que la caméra dialogue n'est pas activé
       if((jeuPause == false || GestionCameras.conversation == false))
        {
            float hDeplacement = Input.GetAxisRaw("Horizontal"); // déplacement horizontal
            float vDeplacement = Input.GetAxisRaw("Vertical"); // déplacement vertical

            // Variable direction de déplacement
            Vector3 directionDep = camera3emePersonne.transform.forward * vDeplacement + camera3emePersonne.transform.right * hDeplacement;

            directionDep.y = 0;

            // Déplacement du personnage
            if (directionDep != Vector3.zero) 
            {
                transform.forward = directionDep;
                rigidbodyPersonnage.velocity = (transform.forward * vitesseDeplacement) + new Vector3(0, rigidbodyPersonnage.velocity.y, 0);
            }
            else
            {
                rigidbodyPersonnage.velocity = new Vector3(0, rigidbodyPersonnage.velocity.y, 0);
            }

            // Accélération du personnage lors de son déplacement avec la touche w
            if (vitesseDeplacement <= 15f && (Input.GetKey("w") || Input.GetKey("s")))
            {
                vitesseDeplacement += 0.08f;
            }
            else if (vitesseDeplacement >= 10 && (Input.GetKey("w") || Input.GetKey("s")))
            {
                vitesseDeplacement = 15;
            }
            else
            {
                vitesseDeplacement = 0;
            }

            // Animation de la course selon la vitesse de déplacement
            GetComponent<Animator>().SetFloat("vitesse", vitesseDeplacement);

            RaycastHit infoCollision; // Raycast pour le saut
            auSol = Physics.SphereCast(transform.position + new Vector3(0f, 0.5f, 0f), 0.2f, -Vector3.up, out infoCollision, 0.8f); // définition de la variable au sol

            // Animation du saut
            GetComponent<Animator>().SetBool("sauter", !auSol);

            // Si la touche espace est activé et que le personnage est au sol
            if (Input.GetKeyDown(KeyCode.Space) && auSol)
            {
                forceDuSaut = hauteurSaut;
                saut = true;
                Invoke("remettreTirBouleDeFeu", 1f);
            }

            // Si le clique droit est activé 
            if (Input.GetKey(KeyCode.Mouse0) && epeeEnMain == true && saut == false)
            {
                // Attaque avec l'épée
                GetComponent<Animator>().SetBool("épée", true);
                Invoke("EnleverAnimationEpee", 0.2f);
                personnage.GetComponent<AudioSource>().clip = sonEpee;
                personnage.GetComponent<AudioSource>().Play();
                vraisEpee.GetComponent<Collider>().enabled = true;
                Invoke("RetirerColliderEpee", 1f);
            }

            ////////////////////////// ZONE TESTE BARRE DE VIE /////////////

            barreVie.fillAmount += 0.00001f;
        }

    }

     void FixedUpdate(){
        if(auSol) {
            GetComponent<Rigidbody>().AddRelativeForce(0f, forceDuSaut, 0f, ForceMode.VelocityChange);
        }else{
            GetComponent<Rigidbody>().AddRelativeForce(0f, ajoutGravite, 0f, ForceMode.VelocityChange);
        }
        forceDuSaut = 0f;
    }

    //******************************************************** DÉTECTTION COLLISION **************************************//
    void OnCollisionEnter(Collision infosCollision)
    {

       if (infosCollision.gameObject.tag == "epee") // La collision pour ramasser l'épée parterre Marc-Antoine Sicotte 2021-04-15;
        {
           triggerEpee = true;
           InvokeRepeating("RamasserEpee", 0.1f, 0.1f);
        }

        // Si on entre en collision avec un ennemi
        if(infosCollision.gameObject.tag == "Ennemi1")
        {
            barreVie.fillAmount -= 0.3f;
            infosCollision.gameObject.GetComponent<Ennemis>().animationAttaque();
        }

        if(infosCollision.gameObject.tag == "Ennemi2")
        {
            barreVie.fillAmount -= 0.08f;
            infosCollision.gameObject.GetComponent<Ennemis>().animationAttaque();
        }

        if(infosCollision.gameObject.tag == "Ennemi3")
        {
            barreVie.fillAmount -= 0.2f;
            infosCollision.gameObject.GetComponent<Ennemis>().animationAttaque();
        }

        if(infosCollision.gameObject.tag == "Ennemi4")
        {
            barreVie.fillAmount -= 0.15f;
            infosCollision.gameObject.GetComponent<Ennemis>().animationAttaque();
        }

        if(luciole == true && infosCollision.gameObject.tag == "TransitionGrotte"){
            SceneManager.LoadScene("Lagrotte");
        }
        if(infosCollision.gameObject.tag == "TransitionProphétie"){
            SceneManager.LoadScene("LaProphetie");
        }

    }


    void OnTriggerEnter(Collider infoObjet) // Fonction qui permet l'affichage de la boite de dialogue quand le personnage est proche d'un PNG Marc-Antoine Sicotte 2021-05-04
    {
        if (infoObjet.gameObject.tag == "png1")
        {
            discours.SetActive(true);
            nomPNG.SetActive(true);
            uiDialogue.SetActive(true);
            GestionCameras.conversation = true;
            Gestiondialogue.quiParle += 1;
        }
    }

    void OnTriggerExit(Collider infoObjet)
    {
        if (infoObjet.gameObject.tag == "png1")
        {
            discours.SetActive(false);
            nomPNG.SetActive(false);
            uiDialogue.SetActive(false);
            GestionCameras.conversation = false;
        }
    }

    void EnleverAnimationEpee(){
        GetComponent<Animator>().SetBool("épée", false);
    }

    void RetirerColliderEpee(){
        vraisEpee.GetComponent<Collider>().enabled = false;
    }

    void remettreTirBouleDeFeu(){
        saut = false;
    }

    void RamasserEpee(){
        if(Input.GetKey(KeyCode.E) && triggerEpee == true){ 
                nbObjetRamasser += 1;
                indicatifInventaire.text += nbObjetRamasser;
                imageEpee.SetActive(true);
                epee.SetActive(false);
                personnage.GetComponent<AudioSource>().clip = sonObjet; //Tamyla
                personnage.GetComponent<AudioSource>().Play(); // Tamyla
                vraisEpee.SetActive(true);
                epeeEnMain = true;
                triggerEpee = false;
            }
    }
}
