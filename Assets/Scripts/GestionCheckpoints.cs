using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionCheckpoints : MonoBehaviour
{
    public Image barreVie;
    void Update()
    {
        if(barreVie.fillAmount <= 0.001){
            if(SceneManager.GetActiveScene().name == "Le_Naufrage")
            {
                SceneManager.LoadScene("Le_Naufrage");
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
