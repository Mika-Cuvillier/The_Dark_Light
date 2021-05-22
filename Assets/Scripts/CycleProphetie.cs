using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleProphetie : MonoBehaviour
{
    /// ************************
    /// PAR TAMYLA AIT-CHELLOUCHE
    /// *************************

    // SKYBOX
    public Material CielJour;
    public Material CielNuit;
    public Material CielDemiJour;

    // LUMI�RES
    public GameObject LumieresJour;
    public GameObject LumieresNuit;
    public GameObject LumieresTwilight;

    // MUSIQUES
    public GameObject MusiqueOn;
    public AudioClip jourMusique;
    public AudioClip nuitMusique;

    void Start()
    {
        // On commence le jeu le jour
        Invoke("AmbianceJour", 0.1f);
    }

    void AmbianceJour()
    {
        // On active les diff�rentes lumi�res reli� aux jour et on change le skybox du jeu
        RenderSettings.skybox = CielJour;
        LumieresJour.SetActive(true);

        //On d�sactive les lumi�res de nuits
        LumieresNuit.SetActive(false);

        // Changement de l'AudioClip pour la musique de jour
        MusiqueOn.GetComponent<AudioSource>().clip = jourMusique;
        MusiqueOn.GetComponent<AudioSource>().Play();

        // Appel de la fonction pour activer le cycle du cr�puscule
        Invoke("AmbianceTwilight", 50f);
    }

    // 
    void AmbianceTwilight()
    {
        // On active les diff�rentes lumi�res du cr�puscule et on change le skybox du jeu
        RenderSettings.skybox = CielDemiJour;
        LumieresTwilight.SetActive(true);

        // On d�sactive les lumi�res de jours
        LumieresJour.SetActive(false);

        // Appel de la fonction pour activer le cycle de la nuit
        Invoke("AmbianceNuit", 200f);
    }

    void AmbianceNuit()
    {
        // On active les diff�rentes lumi�res de nuit et on change le skybox du jeu
        RenderSettings.skybox = CielNuit;
        LumieresNuit.SetActive(true);

        // On d�sactive les lumi�res du cr�puscule
        LumieresTwilight.SetActive(false);

        // Changement de l'AudioClip pour la musique de nuit
        MusiqueOn.GetComponent<AudioSource>().clip = nuitMusique;
        MusiqueOn.GetComponent<AudioSource>().Play();
    }
}
