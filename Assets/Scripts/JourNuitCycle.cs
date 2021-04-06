using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourNuitCycle : MonoBehaviour
{
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
        RenderSettings.skybox = CielJour;
        LumiereDirectionalJour.SetActive(true);
        LumierePointJour.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
    // TEST AVEC LES KEYCODE SI LE CHANGEMENT DE LUMINOSITÉ FONCTIONNE + SKYBOX
      if (Input.GetKeyDown(KeyCode.I))
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
    }
}
