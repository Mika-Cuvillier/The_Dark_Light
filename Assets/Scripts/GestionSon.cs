using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSon : MonoBehaviour
{
    public AudioClip melodie; // Variable contenant la musique du jeu Marc-Antoine Sicotte 2021-03-23
   // public SpriteRenderer spriteRenderer;
    //public Sprite sonMute;
    //public Sprite sonOn;
    //private bool son;
    // Start is called before the first frame update
    void Start()
    {
       // son = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown("m"))
        { 
            if(son == true)
            {
                GetComponent<AudioSource>().Pause(); // Mettre la melodie sur pause Marc-Antoine Sicotte 2021-03-23
                son = false;
                //spriteRenderer.sprite = sonMute;

            }

            if (son == false)
            {
                GetComponent<AudioSource>().Play(); // Rejouer la melodie Marc-Antoine Sicotte 2021-03-23
                //spriteRenderer.sprite = sonOn;
                
            } 
        } */
    }

    public void EteindreSon()
    {
        GetComponent<AudioSource>().Pause();
    }
}
