using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFlash : MonoBehaviour
{

    public List<Renderer> carRenderer = new List<Renderer>();
    private int flashCounter = 0;
    private float waitLength = 0.2f;

    private int flashNo = 6;

    public IEnumerator CarAIFlash()
    {
        yield return new WaitForSecondsRealtime(waitLength);

        for (int i = 0; i < carRenderer.Count; i++)
        {

            carRenderer[i].enabled = !carRenderer[i].enabled;

        }

        yield return new WaitForSecondsRealtime(waitLength);
        flashCounter++;

        if (flashCounter < flashNo)
        {
            StartCoroutine(CarAIFlash());
        }
    }
}
