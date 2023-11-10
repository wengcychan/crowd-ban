using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenRatio : MonoBehaviour
{

    public GameObject background;
    public GameObject background3;
    public List<GameObject> detectionFloor0 = new List<GameObject>();
    public List<GameObject> detectionFloor1 = new List<GameObject>();
    public float changePosition;
    public float ratio;
    public float height;
    public float width;
    public GameObject carSign0;
    public GameObject carSign2;
    public List<GameObject> humanSign0 = new List<GameObject>();
    public List<GameObject> humanSign1 = new List<GameObject>();

    void Awake()
    {
        height = Screen.height;
        width = Screen.width;

        if (Camera.main.aspect > (1920f / 1080f))// > 16:9
		{
            background3.SetActive(true);
            background.SetActive(false);

            ratio = (width / height) / (1920f / 1080f);
            changePosition = (3200f * ratio - 3200f) / 2f / 10f;

            Vector3 temp = new Vector3(changePosition, 0f, 0f);

            for (int i = 0; i < detectionFloor0.Count; i++)
            {
                detectionFloor0[i].transform.position -= temp;
            }

            for (int i = 0; i < detectionFloor1.Count; i++)
            {
                detectionFloor1[i].transform.position += temp;
            }

            carSign0.transform.position -= temp;
            carSign2.transform.position += temp;

            for (int i = 0; i < humanSign0.Count; i++)
            {
                humanSign0[i].transform.position -= temp;
            }

            for (int i = 0; i < humanSign1.Count; i++)
            {
                humanSign1[i].transform.position += temp;
            }
        }

        else if (Camera.main.aspect < (1920f / 1080f))// < 16:9
        {
            ratio = (width / height) / (1920f / 1080f);

            changePosition = (3200f - 3200f * ratio) / 2f / 10f;

            Vector3 tempSign = new Vector3(changePosition, 0f, 0f);
            Vector3 tempFloor = new Vector3(0f , 0f, changePosition * 2f);

            for (int i = 0; i < detectionFloor0.Count; i++)
            {
                detectionFloor0[i].transform.localScale += tempFloor;
            }

            for (int i = 0; i < detectionFloor1.Count; i++)
            {
                detectionFloor1[i].transform.localScale -= tempFloor;
            }

            carSign0.transform.position += tempSign;
            carSign2.transform.position -= tempSign;

            for (int i = 0; i < humanSign0.Count; i++)
            {
                humanSign0[i].transform.position += tempSign;
            }

            for (int i = 0; i < humanSign1.Count; i++)
            {
                humanSign1[i].transform.position -= tempSign;
            }

        }
    }
}
