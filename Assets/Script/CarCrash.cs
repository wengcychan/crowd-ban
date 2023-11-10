using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCrash : MonoBehaviour
{
    WanderingAI scriptOfAI = null;
    CarFlash scriptOfCar = null;
    public Button pauseButton;
    public Button fastForwardButton;
    PickAgent scriptOfPick = null;

    // Start is called before the first frame update
    void Start()
    {
        scriptOfPick = GameObject.FindObjectOfType<PickAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Car")
        {
            if (other.GetType() == typeof(BoxCollider) || other.GetType() == typeof(MeshCollider))
            {
                scriptOfPick.selected = true;
                Time.timeScale = 0;
                pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
                pauseButton.interactable = false;
                fastForwardButton = GameObject.Find("FastForwardButton").GetComponent<Button>();
                fastForwardButton.interactable = false;
                if (PlayerPrefs.GetInt("Sound", 0) == 0)
                    FindObjectOfType<AudioManager>().Play("Crash");

                scriptOfAI = transform.parent.GetComponent<WanderingAI>();
                scriptOfCar = GameObject.Find(other.transform.parent.name).GetComponent<CarFlash>();

                scriptOfAI.playerRenderer.enabled = false; //only one sprite

                for (int i = 0; i < scriptOfCar.carRenderer.Count; i++)
                {
                    scriptOfCar.carRenderer[i].enabled = false;
                }

                StartCoroutine(scriptOfAI.WanderingAgentFlash());
                StartCoroutine(scriptOfCar.CarAIFlash());
            }
        }
    }
}
