using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prophetie : MonoBehaviour
{
    /// ************************
    /// PAR TAMYLA AIT-CHELLOUCHE
    /// *************************

    public GameObject interfaceParchemin; // R�f�rence au canvas des parchemins
    public GameObject interfaceProphetie; // R�f�rence au canvas des parchemins


    public void ActiverProphetie()
    {
        //D�sactiver le canvas des parchemins
        interfaceParchemin.SetActive(false);

        //Activer Canvas de la prophetie
        interfaceProphetie.SetActive(true);

    }
}
