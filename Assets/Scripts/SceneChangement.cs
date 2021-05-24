using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangement : MonoBehaviour
   
{
    /// ************************
    /// XANDER VANEGAS BUSTAMANTE
    /// *************************

    public static int niveau;

    // Start is called before the first frame update
    void Start()
    {
        niveau = 1;
    }

    void Update()
{
    if(niveau == 1)
    {
      
      Invoke("NiveauNaufrage", 4.8f);
    }
}
   

    void NiveauNaufrage()
    {
      SceneManager.LoadScene("Le_Naufrage");
    }
}
