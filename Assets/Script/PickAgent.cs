using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickAgent : MonoBehaviour
{
    WanderingAI scriptOfAI = null;
    PauseMenu scriptOfPause = null;
    string targetname;
    public bool selected;
    public bool tap = false;
    public bool wanderingHitAI = false;

    void Start()
    {
        scriptOfPause = GameObject.FindObjectOfType<PauseMenu>();
        selected = false;
    }

    void Update()
    {
        if (selected == false && scriptOfPause.GameIsPaused == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!IsPointerOverUIObject() && scriptOfPause.GameIsPaused == false)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        targetname = hit.transform.name;
                    }

                    if (hit.collider != null)
                    {
                        if (hit.transform.tag == "WanderingAgent")
                        {
                            scriptOfAI = GameObject.Find(hit.transform.name).GetComponent<WanderingAI>();
                            if (PlayerPrefs.GetInt("Sound", 0) == 0)
                            FindObjectOfType<AudioManager>().Play("Click");
                            wanderingHitAI = true;
                        }
                    }
                    if (wanderingHitAI == true)
                        StartCoroutine(Tap());
                }
            }
        }
    }

    public IEnumerator Tap()
    {
        scriptOfAI.selectedTarget.enabled = true;
        selected = true;
        wanderingHitAI = false;
        yield return new WaitForSeconds(0.0f);
        scriptOfAI.tap = true;
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPoistion = new PointerEventData(EventSystem.current);
        eventDataCurrentPoistion.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPoistion, results);
        return results.Count > 0;
    }
}