using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentCountCylinder : MonoBehaviour
{
    public int i = 0;

    GameManager scriptOfGame = null;
    private GameObject triggerFloor;

    private int flashCounter = 0;
    private float waitLength = 0.1f;
    private int flashNo = 6;
    public Button pauseButton;
    public Button fastForwardButton;
    public List<GameObject> agent = new List<GameObject>();
    PickAgent scriptOfPick = null;

    void Start()
    {
        triggerFloor = GameObject.Find("Trigger" + transform.name);

        triggerFloor.GetComponent<Renderer>().enabled = false;

        scriptOfPick = GameObject.FindObjectOfType<PickAgent>();
    }

    void OnTriggerEnter(Collider aOther)
    {
        if (aOther.tag == "WanderingAgent" || aOther.tag == "RunningAgent")
        {
            if (aOther.GetType() == typeof(CapsuleCollider))
            {

                    agent.Add(aOther.transform.parent.gameObject);

                    i = agent.Count;

                    if (transform.tag == "Floor1")
                    {
                        if (i > 1)
                        {
                            scriptOfPick.selected = true;
                            Time.timeScale = 0;
                            fastForwardButton = GameObject.Find("FastForwardButton").GetComponent<Button>();
                            fastForwardButton.interactable = false;
                            pauseButton.interactable = false;

                            if (PlayerPrefs.GetInt("Sound", 0) == 0)
                                FindObjectOfType<AudioManager>().Play("GameOver");

                            StartCoroutine(FloorFlash());

                        }
                    }

                    else if (transform.tag == "Floor2")
                    {
                        if (i > 2)
                        {
                            scriptOfPick.selected = true; 
                            Time.timeScale = 0;
                            fastForwardButton = GameObject.Find("FastForwardButton").GetComponent<Button>();
                            fastForwardButton.interactable = false;
                            pauseButton.interactable = false;
                            if (PlayerPrefs.GetInt("Sound", 0) == 0)
                                FindObjectOfType<AudioManager>().Play("GameOver");

                            StartCoroutine(FloorFlash());
                        }
                    }

                    else if (transform.tag == "Floor3")
                    {
                        if (i > 3)
                        {
                            scriptOfPick.selected = true;
                            Time.timeScale = 0;
                            fastForwardButton = GameObject.Find("FastForwardButton").GetComponent<Button>();
                            fastForwardButton.interactable = false;
                            pauseButton.interactable = false;
                            if (PlayerPrefs.GetInt("Sound", 0) == 0)
                                FindObjectOfType<AudioManager>().Play("GameOver");


                            StartCoroutine(FloorFlash());

                        }
                    }

                    else if (transform.tag == "Floor4")
                    {
                        if (i > 4)
                        {
                            scriptOfPick.selected = true;
                            Time.timeScale = 0;
                            fastForwardButton = GameObject.Find("FastForwardButton").GetComponent<Button>();
                            fastForwardButton.interactable = false;
                            pauseButton.interactable = false;
                            if (PlayerPrefs.GetInt("Sound", 0) == 0)
                                FindObjectOfType<AudioManager>().Play("GameOver");


                            StartCoroutine(FloorFlash());
                        }
                    }
                }

            }
        }

    private void OnTriggerExit(Collider aOther)
    {
        if (aOther.tag == "WanderingAgent" || aOther.tag == "RunningAgent")
        {
            agent.Remove(aOther.transform.parent.gameObject);
        }
        i = agent.Count;
    }

    public IEnumerator FloorFlash()
    {
        yield return new WaitForSecondsRealtime(waitLength);

        triggerFloor.GetComponent<Renderer>().enabled = !triggerFloor.GetComponent<Renderer>().enabled;

        yield return new WaitForSecondsRealtime(waitLength);
        flashCounter++;

        if (flashCounter < flashNo)
        {
            StartCoroutine(FloorFlash());
        }
        else
        {
            scriptOfGame = GameObject.FindObjectOfType<GameManager>();

            scriptOfGame.GameOver();
        }
    }
}
