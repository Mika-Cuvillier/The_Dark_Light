using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourNuitCycle : MonoBehaviour
{
    /// ************************
    /// PAR TAMYLA AIT-CHELLOUCHE
    /// *************************
    /// Il va falloir modifier les invoke lors que les checkpoints seront programm�s
    ///

    // SKYBOX
    public Material CielJour;
    public Material CielNuit;
    public Material CielDemiJour;

    // LUMI�RES
    public GameObject LumierePointJour;
    public GameObject LumierePointNuit;
    public GameObject LumierePointTwilight;
    public GameObject LumiereDirectionalJour;
    public GameObject LumiereDirectionalNuit;
    public GameObject LumiereDirectionalTwilight;

    // MUSIQUES
    public GameObject MusiqueOn;
    public AudioClip jourMusique;
    public AudioClip nuitMusique;

    void Start()
    {
        // On commence le jeu le jour
        Invoke("LumiereJour", 1f);
    }

    void LumiereJour ()
    {
        // On active les diff�rentes lumi�res reli� aux jour et on change le skybox du jeu
        RenderSettings.skybox = CielJour;
        LumiereDirectionalJour.SetActive(true);
        LumierePointJour.SetActive(true);

        //On d�sactive les lumi�res de nuits
        LumiereDirectionalNuit.SetActive(false);
        LumierePointNuit.SetActive(false);

        // Changement de l'AudioClip pour la musique de jour
        MusiqueOn.GetComponent<AudioSource>().clip = jourMusique;
        MusiqueOn.GetComponent<AudioSource>().Play();

        // Appel de la fonction pour activer le cycle du cr�puscule
        Invoke("LumiereTwilight", 30f);
    }

    // 
    void LumiereTwilight()
    {
        // On active les diff�rentes lumi�res du cr�puscule et on change le skybox du jeu
        RenderSettings.skybox = CielDemiJour;
        LumiereDirectionalTwilight.SetActive(true);
        LumierePointTwilight.SetActive(true);

        // On d�sactive les lumi�res de jours
        LumiereDirectionalJour.SetActive(false);
        LumierePointJour.SetActive(false);

        // Appel de la fonction pour activer le cycle de la nuit
        Invoke("LumiereNuit", 20f);
    }

    void LumiereNuit ()
    {
        // On active les diff�rentes lumi�res de nuit et on change le skybox du jeu
        RenderSettings.skybox = CielNuit;
        LumiereDirectionalNuit.SetActive(true);
        LumierePointNuit.SetActive(true);

        // On d�sactive les lumi�res du cr�puscule
        LumiereDirectionalTwilight.SetActive(false);
        LumierePointTwilight.SetActive(false);

        // Changement de l'AudioClip pour la musique de nuit
        MusiqueOn.GetComponent<AudioSource>().clip = nuitMusique;
        MusiqueOn.GetComponent<AudioSource>().Play();

        // Appel de la fonction pour activer le cycle du jour
        Invoke("LumiereJour", 50f);
    }

}
