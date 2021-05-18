using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleNaufrage : MonoBehaviour
{
    /// ************************
    /// PAR TAMYLA AIT-CHELLOUCHE
    /// *************************

    // SKYBOX
    public Material CielNuit;
    public Material CielDemiJour;

    // LUMIÈRES
    public GameObject LumieresNuit;
    public GameObject LumieresTwilight;

    // MUSIQUES
    public GameObject MusiqueOn;
    public AudioClip jourMusique;
    public AudioClip nuitMusique;

    void Start()
    {
        // On commence le jeu au crépuscule
        Invoke("AmbianceTwilight", 0.1f);
    }

    // 
    void AmbianceTwilight()
    {
        // On active les différentes lumières du crépuscule et on change le skybox du jeu
        RenderSettings.skybox = CielDemiJour;
        LumieresTwilight.SetActive(true);

        // Changement de l'AudioClip pour la musique de nuit
        MusiqueOn.GetComponent<AudioSource>().clip = jourMusique;
        MusiqueOn.GetComponent<AudioSource>().Play();

        // Appel de la fonction pour activer le cycle de la nuit
        Invoke("AmbianceNuit", 30f);
    }

    void AmbianceNuit()
    {
        // On active les différentes lumières de nuit et on change le skybox du jeu
        RenderSettings.skybox = CielNuit;
        LumieresNuit.SetActive(true);

        // On désactive les lumières du crépuscule
        LumieresTwilight.SetActive(false);

        // Changement de l'AudioClip pour la musique de nuit
        MusiqueOn.GetComponent<AudioSource>().clip = nuitMusique;
        MusiqueOn.GetComponent<AudioSource>().Play();

    }

}
