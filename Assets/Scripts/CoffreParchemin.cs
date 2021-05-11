using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffreParchemin : MonoBehaviour
{
    public GameObject topCoffre;
    public GameObject hero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision infoCollisions)
    {
       // Le coffre s'ouvre
       topCoffre.transform.Rotate(-180.0f, 0.0f, 0.0f);
    }
}
