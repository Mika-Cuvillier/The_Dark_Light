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
    /// Gestion du personnage
    /// Modifier: 24 mai 2021
    /// *************************

    public GameObject camera3emePersonne; // Variable contenant la caméra 3e personne
    public GameObject personnage; // GameObject du personnage
    public GameObject pivotRotation; // updated du pivot pour la caméra
    public GameObject vraisEpee; // Variable contenant l'epee dans la main du perso Marc-Antoine Sicotte 2021-04-15
    public GameObject epee; // Objet a ramasser pour tester l'inventaire Marc-Antoine Sicotte 2021-03-30
    public GameObject imageEpee; // Ajout par M-A
    public GameObject imageLuciole; // Variable representante l'image de la luciole dans l'inventaire Marc-Antoine Sicotte 2021-05-17
    public GameObject luciole2; // GameObject Luciole à ramasser Marc-Antoine Sicotte 2021-05-21
    public GameObject luciole3; // GameObject Luciole à ramasser Marc-Antoine Sicotte 2021-05-21
    public GameObject luciole4; // GameObject Luciole à ramasser Marc-Antoine Sicotte 2021-05-21
    public GameObject lucioleDebut; // GameObject qui réfère au premier png que le héro rencontre Marc-Antoine Sicotte 2021-05-04
    public GameObject uiDialogue; // GameObject de la boite de dialogue Marc-Antoine Sicotte 2021-05-04
    public GameObject discours; // GameObject du discours du PNG Marc-Antoine Sicotte 2021-05-11
    public GameObject prophetie1; // Gameobject qui relate aux morceaux de la prophetie Marc-Antoine Sicotte 2021-05-22
    public GameObject prophetie2; // Gameobject qui relate aux morceaux de la prophetie Marc-Antoine Sicotte 2021-05-22
    public GameObject prophetie3; // Gameobject qui relate aux morceaux de la prophetie Marc-Antoine Sicotte 2021-05-22
    public GameObject prophetie4; // Gameobject qui relate aux morceaux de la prophetie Marc-Antoine Sicotte 2021-05-22
    public GameObject prophetie5; // Gameobject qui relate aux morceaux de la prophetie Marc-Antoine Sicotte 2021-05-22
    public GameObject prophetie6; // Gameobject qui relate aux morceaux de la prophetie Marc-Antoine Sicotte 2021-05-22
    public GameObject canvasPro; // variable du canvas de la prophetie
    public GameObject nomPNG; // GameObject du nom du PNG Marc-Antoine Sicotte 2021-05-11
    public GameObject escalier1; // GameObject des escalier dans la scene prophetie Marc-Antoine Sicotte 2021-05-21
    public GameObject escalier2; // GameObject des escalier dans la scene prophetie Marc-Antoine Sicotte 2021-05-21
    public Image barreVie; // Ajout par M-A
    public Text nbProphetie; // Indicatif du nombre de parchemin trouvé Marc-Antoine Sicotte 2021-05-24;
    public Text nbLuciole; // Varibale affichant la quantité de luciole ramassée dans l'inventaire Marc-Antoine Sicotte 2021-05-17
    public Text nbEpee; // Variable affichant la quantité des objets ramasser dans l'inventaire Marc-Antoine Sicotte 2021-04-13
    private int nbLucioleRamasse; // Variable qui compte le nombre de Luciole ramasser Marc-Antoine Sicotte 2021-05-24; 
    private int nbProphetieRamasse; // Variable qui compte le nombre de parchemin ramasser Marc-Antoine Sicotte 2021-05-24
    private int ordeDialogue; // Variable qui gère l'orde des dialogues Marc-Antoine Sicotte 2021-04-13
    float vitesseDeplacement; // Variable pour la vitesse de déplacement
    public float hauteurSaut; // Variable pour la hauteur du saut
    public float ajoutGravite; // Variable pour la gravité
    private float forceDuSaut; // Variable pour la force du saut
    public static bool jeuPause; // Variable Static pour permettre d'arrêter la détection des touches quand le jeu est en pause Marc-Antoine Sicotte 2021-03-24
    public bool pro1;
    public bool pro2;
    public bool pro3;
    public bool pro4;
    public bool pro5;
    public bool pro6;
    private bool auSol; // booléenne lorsque le personnage est au sol
    public bool quete1Bool;
    public bool epeeEnMain; // Variable pour savoir si on a l'épée en main
    private bool triggerEpee;
    public bool saut; // Variable pour savoir si le saut est true
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
        
        // Si on est sur lagrotte ou la prophétie, on a déja l'épée en main
        if ((SceneManager.GetActiveScene().name == "Lagrotte") || (SceneManager.GetActiveScene().name == "LaProphetie")){
            epeeEnMain = true;
        }
    }

    
    void Update()
    {
        // Si le jeu n'est pas en pause et que la caméra dialogue n'est pas activé
       if(jeuPause == false)
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

            if(quete1Bool == true)
            {
                Invoke("quete1", 15f);
                quete1Bool = false;
            }

            if(nbLucioleRamasse >= 4)
            {
                luciole = true;
                SceneChangement.niveau = 2;
            }

            if(pro1 == true && pro2 == true && pro3 == true && pro4 == true && pro5 == true && pro6 == true ){
                escalier1.SetActive(true);
                escalier2.SetActive(true);
            }

            ////////////////////////// ZONE TESTE BARRE DE VIE /////////////

            barreVie.fillAmount += 0.00001f;
        }

    }
        // Le saut
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

        if(infosCollision.gameObject.tag == "Boss")
        {
            barreVie.fillAmount -= 0.35f;
            infosCollision.gameObject.GetComponent<Ennemis>().animationAttaque();
        }

       if(infosCollision.gameObject.tag == "Soleile") //marc
       {
           pro1 = true;
           nbProphetieRamasse += 1;
           prophetie1.SetActive(true);
           canvasPro.SetActive(true);
           Invoke("enleverProphetie", 3f);
       }
       if(infosCollision.gameObject.tag == "cfEnnemi") // marc
       {
           pro2 = true;
           nbProphetieRamasse += 1;
           prophetie3.SetActive(true);
           canvasPro.SetActive(true);
           Invoke("enleverProphetie", 3f);
       }

       if(infosCollision.gameObject.tag == "CFluciole") // marc
       {
           pro3 = true;
           nbProphetieRamasse += 1;
           prophetie2.SetActive(true);
           canvasPro.SetActive(true);
           Invoke("enleverProphetie", 3f);
           
       }

        if(infosCollision.gameObject.tag == "Arbre") //marc
       {
           pro4 = true;
           nbProphetieRamasse += 1;
           prophetie5.SetActive(true);
           canvasPro.SetActive(true);
           Invoke("enleverProphetie", 3f);
       }
       if(infosCollision.gameObject.tag == "cfEpee") // marc
       {
           pro5 = true;
           nbProphetieRamasse += 1;
           prophetie6.SetActive(true);
           canvasPro.SetActive(true);
           Invoke("enleverProphetie", 3f);
       }

       if(infosCollision.gameObject.tag == "Palmier") // marc
       {
           pro6 = true;
           nbProphetieRamasse += 1;
           prophetie4.SetActive(true);
           canvasPro.SetActive(true);
           Invoke("enleverProphetie", 3f);
       }

        if(infosCollision.gameObject.tag == "fingrotte") // marc
       {
           SceneChangement.niveau = 3;
           SceneManager.LoadScene("SceneChangement");

       }


        if(infosCollision.gameObject.tag == "Luciole2") //Marc
        {
            nbLucioleRamasse += 1;
            nbLuciole.GetComponent<Text>().text = nbLucioleRamasse.ToString();
            personnage.GetComponent<AudioSource>().clip = sonObjet; //Tamyla
            personnage.GetComponent<AudioSource>().Play(); // Tamyla
            
        }
        if(infosCollision.gameObject.tag == "Luciole3")// Marc
        {
            nbLucioleRamasse += 1;
            nbLuciole.GetComponent<Text>().text = nbLucioleRamasse.ToString();
            personnage.GetComponent<AudioSource>().clip = sonObjet; //Tamyla
            personnage.GetComponent<AudioSource>().Play(); // Tamyla
            
            
        }
        if(infosCollision.gameObject.tag == "Luciole4") // Marc
        {
            nbLucioleRamasse += 1;
            nbLuciole.GetComponent<Text>().text = nbLucioleRamasse.ToString();
            personnage.GetComponent<AudioSource>().clip = sonObjet; //Tamyla
            personnage.GetComponent<AudioSource>().Play(); // Tamyla
            
        }

            // Si on rentre en collision on change de scène
        if(luciole == true && infosCollision.gameObject.tag == "TransitionGrotte"){
            SceneManager.LoadScene("SceneChangement");
        }

        nbProphetie.GetComponent<Text>().text = nbProphetieRamasse.ToString();

    }


    void OnTriggerEnter(Collider infoObjet) // Fonction qui permet l'affichage de la boite de dialogue quand le personnage est proche d'un PNG Marc-Antoine Sicotte 2021-05-04
    {
        discours.SetActive(true);
        nomPNG.SetActive(true);
        uiDialogue.SetActive(true);
        GestionCameras.conversation = true;
        if (infoObjet.gameObject.tag == "png1")
        {
            nbLucioleRamasse += 1;
            imageLuciole.SetActive(true);
            nbLuciole.GetComponent<Text>().text = nbLucioleRamasse.ToString();
            nomPNG.GetComponent<Text>().text = "Luciole";
            discours.GetComponent<Text>().text = "Bonsoir chère inconnu! Tu es sain et sauf on ne peu en dire autant de ton bateau... Ramasse ton épé et vas vite te cacher au village!";
            ordeDialogue += 1;
            

        }
        else if (infoObjet.gameObject.tag == "png2")
        {
            if(ordeDialogue != 1)
            {
                nomPNG.GetComponent<Text>().text = "Villageois";
                discours.GetComponent<Text>().text = "Ces démons nous cause des soucis à chaque jour et il faut être à l’affut à chaque instant!";
            }
            if(ordeDialogue == 1)
            {
                nomPNG.GetComponent<Text>().text = "Villageois";
                discours.GetComponent<Text>().text = "Tu n'es pas d'ici toi. Notre île est maudite, chaque nuit des monstres apparaient! Si tu veux nous aider va voir ma femme.";
                ordeDialogue += 1;
                
            }

        }
        else if (infoObjet.gameObject.tag == "png3")
        {
            if(ordeDialogue !=2 )
            {
                nomPNG.GetComponent<Text>().text = "Villagoisee";
                discours.GetComponent<Text>().text = "Nom d’une carpe! La récolte à encore baissé cette saison, ces satanés démons ne s’arrêteront donc jamais...";
            }
            if(ordeDialogue ==2)
            {
                 nomPNG.GetComponent<Text>().text = "Villagoisee";
                discours.GetComponent<Text>().text = "Une nouvelle tête, mais quel miracle! Peut-être sauras tu levé cette malédiction. Pour commencer il faut apprendre à se battre va voir l'entraineur sur la coline.";
                ordeDialogue += 1;
            }
        }
        else if (infoObjet.gameObject.tag == "png4")
        {
            if(ordeDialogue != 3)
            {
               nomPNG.GetComponent<Text>().text = "Entraineur";
                discours.GetComponent<Text>().text = " J’ai envie d’une bonne marmite remplit de soupe au poulet pas toi!";
                
            }
           if(ordeDialogue == 3)
            {
                nomPNG.GetComponent<Text>().text = "Entraineur";
                discours.GetComponent<Text>().text = "Jeune Combatant je vous attendais! Pour attaquer avec ton épée clique gauche avec la souris, pour la boule de feu clique droit. Essaye sur ce sac de sable. AHIIHAAA!";
                ordeDialogue += 1;
                quete1Bool = true;
            }
        }

        else if (infoObjet.gameObject.tag == "png5")
        {
            
          
            
                nomPNG.GetComponent<Text>().text = "Villageoise";
                discours.GetComponent<Text>().text = "Vite vite vite allez au village! Les monstres nous ont envahi!";
                
            
        }
        else
        {
            nomPNG.GetComponent<Text>().text = "Inconnu";
            discours.GetComponent<Text>().text = "Hmmm?";
            
        }
    }

    void OnTriggerExit(Collider infoObjet)
    {
        lucioleDebut.SetActive(false);
        GestionCameras.conversation = false;
        discours.SetActive(false);
        nomPNG.SetActive(false);
        uiDialogue.SetActive(false);
    }

    void EnleverAnimationEpee(){
        GetComponent<Animator>().SetBool("épée", false);
    }

    void RetirerColliderEpee(){
        vraisEpee.GetComponent<Collider>().enabled = false;
    }

    void quete1(){
        discours.SetActive(true);
        nomPNG.SetActive(true);
        uiDialogue.SetActive(true);
        GestionCameras.conversation = true;
        nomPNG.GetComponent<Text>().text = "Luciole";
        discours.GetComponent<Text>().text = "Hey! Je crois que la grotte mène à l'autre côté de l'ile, parcontre elle est très sombre. Essaye de ramasser 3 autres Luciole comme moi nous t'éclairons lors de la traversé!";
        Invoke("finQuete1", 8f);
        
    }

    void finQuete1(){
        
        GestionCameras.conversation = false;
        discours.SetActive(false);
        nomPNG.SetActive(false);
        uiDialogue.SetActive(false);
    }

    void remettreTirBouleDeFeu(){
        saut = false;
    }

    void enleverProphetie()
    {
        canvasPro.SetActive(false);
    }

    void RamasserEpee(){

        if(Input.GetKey(KeyCode.E) && triggerEpee == true){ 
                
                nbEpee.GetComponent<Text>().text = "1";
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
