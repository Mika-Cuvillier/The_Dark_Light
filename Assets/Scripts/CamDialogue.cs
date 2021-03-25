using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDialogue : MonoBehaviour
{
    public GameObject laCible;
    public Vector3 distance;

    // Update is called once per frame
    void Update()
    {
       transform.position = laCible.transform.position + distance;
    }
}
