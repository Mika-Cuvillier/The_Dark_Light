using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TirBouleDeFeu : MonoBehaviour
{
    /// ******************
    /// PAR MIKA CUVILLIER
    /// ******************
 
    public GameObject bouleDeFeu; // Game Object de la boule de feu
    public GameObject personnage; // Game Object du personnage
    public GameObject epee; // Game Object de l'épée
    public Image jaugeFeu; // Image de la jauge de feu
    public float vitesseBouleDeFeu; // la vitesse de la boule de feu
    private bool peutTirer; // booléeane si on peut tirer une nouvelle boule de feu

    // Start is called before the first frame update
    void Start()
    {
        // Au départ, on peut tirer une boule de feu
        peutTirer = true;
        GetComponent<Animator>().SetBool("bouleDeFeu", false);
    }

    // Update is called once per frame
    void Update()
    {
        // Si on fait un clique gauche et qu'on peut tirer
        if(Input.GetKeyDown(KeyCode.Mouse1) && peutTirer){
            Tir();
            GetComponent<Animator>().SetBool("bouleDeFeu", true);
            Invoke("EnleverAnimationBouleDeFeu", 0.5f);
        }
        Physics.IgnoreCollision(bouleDeFeu.GetComponent<Collider>(), epee.GetComponent<Collider>());
        Physics.IgnoreCollision(bouleDeFeu.GetComponent<Collider>(), personnage.GetComponent<Collider>());
    }
 
    void Tir(){
        jaugeFeu.fillAmount -= 1f; // Descend la jauge de feu au minimum apr�s avoir tirer Marc-Antoine Sicotte 2021-03-30
        peutTirer = false;
        Invoke("ActiveTir", 5f);
        Invoke("NouvelleBouleDeFeu", 0.4f);
    }




    void ActiveTir(){
        // On peut tirer à nouveau
        peutTirer = true;
        jaugeFeu.fillAmount += 1f; // Remonte la jauge de feu au maximum apr�s avoir reactiver le tir Marc-Antoine Sicotte 2021-03-30

    }

    void EnleverAnimationBouleDeFeu(){
        GetComponent<Animator>().SetBool("bouleDeFeu", false);
    }

    void NouvelleBouleDeFeu()
    {
        GameObject nouvelleBoule = Instantiate(bouleDeFeu, bouleDeFeu.transform.position, bouleDeFeu.transform.rotation);
        nouvelleBoule.SetActive(true);
        nouvelleBoule.GetComponent<Rigidbody>().velocity = nouvelleBoule.transform.forward * vitesseBouleDeFeu;

    }
}
