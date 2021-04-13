using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FumeBoule : MonoBehaviour
{

    // Script qui génère les particules de fumé lors de l'impact de la boule de feu Marc-Antoine Sicotte 2021-04-08
    public GameObject perso;
    public GameObject impactBoule;

    private void OnCollisionEnter(Collision infoCollisions)
    {
        GameObject fume = Instantiate(impactBoule);
        fume.transform.position = infoCollisions.GetContact(0).point;
        fume.SetActive(true);
        fume.transform.LookAt(perso.transform);
        fume.transform.Translate(0f, 0.5f, 0.5f);
        Destroy(fume, 0.7f);
        Destroy(gameObject);

    }
    
    
}
