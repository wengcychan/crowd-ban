using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    // Start is called before the first frame update

    public Animation anim;

    void Start()
    {
        anim.Play("Running");
    }
}
