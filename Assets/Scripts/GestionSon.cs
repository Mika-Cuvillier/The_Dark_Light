using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSon : MonoBehaviour
{
    public AudioClip melodie; // Variable contenant la musique du jeu Marc-Antoine Sicotte 2021-03-23
    public GameObject Audio;
   
    public void EteindreSon()
    {
        GetComponent<AudioSource>().Pause();
    }
}
