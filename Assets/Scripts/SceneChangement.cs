using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangement : MonoBehaviour
   
{
    /// ************************
    /// XANDER VANEGAS BUSTAMANTE
    /// *************************

    public static int niveau = 1;

    void Update()
{
    if(niveau == 1)
    {
      
      Invoke("NiveauNaufrage", 4.8f);
    }

    if(niveau == 2)
    {
      
      Invoke("NiveauGrotte", 4.8f);
    }

    if(niveau == 3)
    {
      
      Invoke("NiveauProphetie", 4.8f);
    }

}
   

    void NiveauNaufrage()
    {
      SceneManager.LoadScene("Le_Naufrage");
    }

    void NiveauGrotte()
    {
      SceneManager.LoadScene("LaGrotte");
    }

    void NiveauProphetie()
    {
      SceneManager.LoadScene("LaProphetie");
    }
}
