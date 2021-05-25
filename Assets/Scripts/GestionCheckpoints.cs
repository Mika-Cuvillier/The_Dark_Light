using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionCheckpoints : MonoBehaviour
{
    /// ******************
    /// PAR MIKA CUVILLIER
    /// Gestion des checkpoints
    /// Modifier: 19 avril 2021
    /// ******************
    
    public Image barreVie; // Image de la barre de vie

    void Update()
    {
       // Si on n'a plus de vie, on reload la sc�ne dand laquelle on était
        if(barreVie.fillAmount <= 0.001){
            if(SceneManager.GetActiveScene().name == "Le_Naufrage")
            {
                SceneManager.LoadScene("Le_Naufrage");
            }
            else if(SceneManager.GetActiveScene().name == "Lagrotte")
            {
                SceneManager.LoadScene("Lagrotte");
            }
            else
            {
                SceneManager.LoadScene("LaProphetie");
            }
        }
    }
}
