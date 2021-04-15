using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionCheckpoints : MonoBehaviour
{
    /// ******************
    /// PAR MIKA CUVILLIER
    /// ******************
    
    public Image barreVie; // Image de la barre de vie

    void Update()
    {
       // Si on n'a plus de vie, on reload la scène de départ (pour le moment)
        if(barreVie.fillAmount <= 0.001){
            if(SceneManager.GetActiveScene().name == "Le_Naufrage")
            {
                SceneManager.LoadScene("Finale_Perdue");
            }
            /*else if(SceneManager.GetActiveScene().name = "")
            {
                SceneManager.LoadScene("");
            }
            else if(SceneManager.GetActiveScene().name = "")
            {
                SceneManager.LoadScene("");
            }
            else if(SceneManager.GetActiveScene().name = "")
            {
                SceneManager.LoadScene("");
            }*/
        }
    }
}
