using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentCount : MonoBehaviour
{
    int i = 0;
    GameManager scriptOfGame = null;
    private GameObject triggerFloor;

    private int flashCounter = 0;
    private float waitLength = 0.1f;
    private int flashNo = 6;
    public Button pauseButton;
    public Button fastForwardButton;
    PickAgent scriptOfPick = null;

    void Start()
    {

        triggerFloor = GameObject.Find("Trigger" + transform.name);

        triggerFloor.GetComponent<Renderer>().enabled = false;

        scriptOfPick = GameObject.FindObjectOfType<PickAgent>();
    }

    Dictionary<Collider, int> m_Colliders = new Dictionary<Collider, int>();
    void OnTriggerEnter(Collider aOther)
    {
        if (aOther.tag == "WanderingAgent" || aOther.tag == "RunningAgent")
        {
            if (aOther.GetType() == typeof(CapsuleCollider))
            {
                if (m_Colliders.ContainsKey(aOther))
                {
                    m_Colliders[aOther]++;
                }
                else
                {
                    m_Colliders.Add(aOther, 1);

                    i = m_Colliders.Count;

                    if (i > 3)
                    {
                        scriptOfPick.selected = true;
                        Time.timeScale = 0;
                        pauseButton.interactable = false;
                        fastForwardButton = GameObject.Find("FastForwardButton").GetComponent<Button>();
                        fastForwardButton.interactable = false;
                        if (PlayerPrefs.GetInt("Sound", 0) == 0)
                            FindObjectOfType<AudioManager>().Play("GameOver");


                        StartCoroutine(FloorFlash());
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider aOther)
    {

        if (aOther.tag == "WanderingAgent" || aOther.tag == "RunningAgent")
        {
            if (aOther.GetType() == typeof(CapsuleCollider))
            {

                if (m_Colliders.ContainsKey(aOther))
                {
                    m_Colliders[aOther]--;
                    if (m_Colliders[aOther] <= 0)
                    {
                        m_Colliders.Remove(aOther);
                    }
                }
            }
        }
        i = m_Colliders.Count;
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
