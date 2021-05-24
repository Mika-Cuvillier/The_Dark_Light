using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffacerLuciole : MonoBehaviour
{

    public GameObject hero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision infosCollision)
    {
        if(infosCollision.gameObject.tag =="hero")
        {
            print("ok");
            Destroy(gameObject);
        }
    }
}
