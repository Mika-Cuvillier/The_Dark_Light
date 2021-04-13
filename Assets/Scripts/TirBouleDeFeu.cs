using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TirBouleDeFeu : MonoBehaviour
{
    public GameObject bouleDeFeu;
    public GameObject personnage;
    public GameObject epee;
    public Image jaugeFeu;
    public float vitesseBouleDeFeu;
    private bool peutTirer;

    // Start is called before the first frame update
    void Start()
    {
        peutTirer = true;
        GetComponent<Animator>().SetBool("bouleDeFeu", false);
    }

    // Update is called once per frame
    void Update()
    {
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
