using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gestiondialogue : MonoBehaviour
{
    public GameObject discours;
    public GameObject nom;
    public static int quiParle;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(GestionCameras.conversation == true)
        {
            if(quiParle == 1)
            {
                nom.GetComponent<Text>().text = "Luciole";
                discours.GetComponent<Text>().text = "Bonsoir chère inconnu! Tu es sain et sauf on ne peu en dire autant de ton bateau... Ramasse ton épé et vas vite de cacher au village!";
            }
        }
    }
}
