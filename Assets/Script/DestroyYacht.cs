using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyYacht : MonoBehaviour
{
    public GameObject yacht;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            Destroy(yacht);
        }
    }
}
