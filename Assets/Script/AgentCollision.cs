using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentCollision : MonoBehaviour
{

    WanderingAI scriptOfAI = null;

    private int flashCounter = 0;
    private float waitLength = 0.2f;
    public Renderer playerRenderer; //only one sprite

    private int flashNo = 6;
    public Button pauseButton;
    public Button fastForwardButton;
    PickAgent scriptOfPick = null;

    void Start()
	{
        scriptOfPick = GameObject.FindObjectOfType<PickAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            Destroy(gameObject);
        }

        if (other.tag == "WanderingAgent")
        {
            if (other.GetType() == typeof(SphereCollider))
            {
                scriptOfPick.selected = true;

                Time.timeScale = 0;
                pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
                pauseButton.interactable = false;
                fastForwardButton = GameObject.Find("FastForwardButton").GetComponent<Button>();
                fastForwardButton.interactable = false;

                if (PlayerPrefs.GetInt("Sound", 0) == 0)
                    FindObjectOfType<AudioManager>().Play("Crash");
                scriptOfAI = GameObject.Find(other.name).GetComponent<WanderingAI>();

                playerRenderer.enabled = false;
                scriptOfAI.playerRenderer.enabled = false;

                StartCoroutine(scriptOfAI.WanderingAgentFlash());
                StartCoroutine(RunningAgentFlash());
            }
        }
    }

    public IEnumerator RunningAgentFlash()
    {
        yield return new WaitForSecondsRealtime(waitLength);

        playerRenderer.enabled = !playerRenderer.enabled;

        yield return new WaitForSecondsRealtime(waitLength);
        flashCounter++;

        if (flashCounter < flashNo)
        {
            StartCoroutine(RunningAgentFlash());
        }

    }
}
