using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouleDeFeu : MonoBehaviour
{

    private void OnCollisionEnter(Collision infoCollisions){
        Destroy(gameObject);
    }
}
