using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirBouleDeFeu : MonoBehaviour
{
    public GameObject bouleDeFeu;
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
    }

    void Tir(){
        peutTirer = false;
        Invoke("ActiveTir", 5f);
        Invoke("NouvelleBouleDeFeu", 0.4f);
    }

    void ActiveTir(){
        peutTirer = true;
    }

    void EnleverAnimationBouleDeFeu(){
        GetComponent<Animator>().SetBool("bouleDeFeu", false);
    }

    void NouvelleBouleDeFeu(){
        GameObject nouvelleBoule = Instantiate(bouleDeFeu, bouleDeFeu.transform.position, bouleDeFeu.transform.rotation);
        nouvelleBoule.SetActive(true);
        nouvelleBoule.GetComponent<Rigidbody>().velocity = nouvelleBoule.transform.forward * vitesseBouleDeFeu;

    }
}
