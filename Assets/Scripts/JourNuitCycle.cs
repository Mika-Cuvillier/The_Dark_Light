using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourNuitCycle : MonoBehaviour
{
    /// ************************
    /// PAR TAMYLA AIT-CHELLOUCHE
    /// *************************
    /// 
    /// IL FAUT MODIFIER LE INVOKE POUR LES MOMENTS DE QUETE OU LE CYCLE CHANGE
    ///

    public Material CielJour;
    public Material CielNuit;
    public Material CielDemiJour;

    public GameObject LumierePointJour;
    public GameObject LumierePointNuit;
    public GameObject LumierePointTwilight;
    public GameObject LumiereDirectionalJour;
    public GameObject LumiereDirectionalNuit;
    public GameObject LumiereDirectionalTwilight;

    void Start()
    {

        Invoke("LumiereJour", 1f);
        

    }

    void LumiereJour ()
    {
        RenderSettings.skybox = CielJour;
        LumiereDirectionalJour.SetActive(true);
        LumierePointJour.SetActive(true);

        Invoke("LumiereTwilight", 10f);
    }

    // Update is called once per frame
    void LumiereTwilight()
    {
        RenderSettings.skybox = CielDemiJour;
        LumiereDirectionalTwilight.SetActive(true);
        LumierePointTwilight.SetActive(true);

        LumiereDirectionalJour.SetActive(false);
        LumierePointJour.SetActive(false);

        LumiereDirectionalNuit.SetActive(false);
        LumierePointNuit.SetActive(false);

        Invoke("LumiereNuit", 10f);
    }

    void LumiereNuit ()
    {
        RenderSettings.skybox = CielNuit;
        LumiereDirectionalNuit.SetActive(true);
        LumierePointNuit.SetActive(true);

        LumiereDirectionalJour.SetActive(false);
        LumierePointJour.SetActive(false);

        LumiereDirectionalTwilight.SetActive(false);
        LumierePointTwilight.SetActive(false);

        Invoke("LumiereJour", 10f);
    }

   /* void Test()
    {
        // TEST AVEC LES KEYCODE SI LE CHANGEMENT DE LUMINOSITÉ FONCTIONNE + SKYBOX
        /* if (Input.GetKeyDown(KeyCode.I))
           {
               RenderSettings.skybox = CielNuit;
               LumiereDirectionalNuit.SetActive(true);
               LumierePointNuit.SetActive(true);

               LumiereDirectionalJour.SetActive(false);
               LumierePointJour.SetActive(false);

               LumiereDirectionalTwilight.SetActive(false);
               LumierePointTwilight.SetActive(false);
           }

           if (Input.GetKeyDown(KeyCode.U))
           {
               RenderSettings.skybox = CielDemiJour;
               LumiereDirectionalTwilight.SetActive(true);
               LumierePointTwilight.SetActive(true);

               LumiereDirectionalJour.SetActive(false);
               LumierePointJour.SetActive(false);

               LumiereDirectionalNuit.SetActive(false);
               LumierePointNuit.SetActive(false);
           }

           if (Input.GetKeyDown(KeyCode.P))
           {
               RenderSettings.skybox = CielJour;
               LumiereDirectionalJour.SetActive(true);
               LumierePointJour.SetActive(true);

               LumiereDirectionalNuit.SetActive(false);
               LumierePointNuit.SetActive(false);

               LumiereDirectionalTwilight.SetActive(false);
               LumierePointTwilight.SetActive(false);
           } 
    } */
}
