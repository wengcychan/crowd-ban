using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WanderingAI : MonoBehaviour
{

    public Rigidbody rb; //ray
    public bool tap; //Ray

    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Quaternion playerRot;
    public float rotSpeed = 5;
    public float speed;
    public bool moving = false;
    private int flashCounter = 0;

    private float waitLength = 0.2f;
    public Renderer playerRenderer; // only sprite
    public MeshRenderer selectedTarget;


    private int flashNo = 6;
    GameManager scriptOfGame = null;

    public Button pauseButton;
    public Button fastForwardButton;
    public bool tapFinished;
    WanderingAI scriptOfAI = null;
    PickAgent scriptOfPick = null;
    public bool hitAI = false;
    PauseMenu scriptOfPause = null;

    public Animator anim;

    void Start()
    {
        tap = false;
        tapFinished = false;
        rb = GetComponent<Rigidbody>();
        selectedTarget.enabled = false;

        scriptOfPause = GameObject.FindObjectOfType<PauseMenu>();
        scriptOfGame = GameObject.FindObjectOfType<GameManager>();
        scriptOfPick = GameObject.FindObjectOfType<PickAgent>();
    }

    void Update()
    {

        speed = scriptOfGame.wanderingAISpeed;

        if (tap == true && scriptOfPause.GameIsPaused == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!IsPointerOverUIObject() && scriptOfPause.GameIsPaused == false)
                {
                    selectedTarget.enabled = false;
                    SetTargetPosition();
                    if (hitAI == false)
                        StartCoroutine(Tap());

                    hitAI = false;
                }
            }
        }

        if (moving == true)
        {
            Move();

            anim.SetBool("Move", moving);
        }
    }

    private bool IsPointerOverUIObject()
	{
        PointerEventData eventDataCurrentPoistion = new PointerEventData(EventSystem.current);
        eventDataCurrentPoistion.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPoistion, results);
        return results.Count > 0;
	}

    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (hit.transform.tag != "WanderingAgent" && hit.transform.tag == "Floor1" || hit.transform.tag == "Floor2" || hit.transform.tag == "Floor3" || hit.transform.tag == "Floor4")
                {
                    targetPosition = hit.point;

                    lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y, targetPosition.z - transform.position.z);
                    playerRot = Quaternion.LookRotation(lookAtTarget);
                    moving = true;
                    targetPosition.y = transform.position.y;
                }
            }
        }
        
        tap = false;
   
        if (hit.collider != null)
        {
            if (hit.transform.tag == "WanderingAgent")
            {
                GameObject.Find("PickAgent").GetComponent<PickAgent>().selected = true;
                scriptOfAI = GameObject.Find(hit.transform.name).GetComponent<WanderingAI>();
                if (PlayerPrefs.GetInt("Sound", 0) == 0)
                    FindObjectOfType<AudioManager>().Play("Click");
                StartCoroutine(AnotherAITap());
            }
        }
    }

    public IEnumerator Tap()
    {
        yield return new WaitForSeconds(0.0f);
        GameObject.Find("PickAgent").GetComponent<PickAgent>().selected = false;
    }

    public IEnumerator AnotherAITap()
    {
        scriptOfAI.selectedTarget.enabled = true;
        GameObject.Find("PickAgent").GetComponent<PickAgent>().selected = true;
        hitAI = true;
        yield return new WaitForSeconds(0.0f);
        scriptOfAI.tap = true;
    }

    void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, rotSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0f, transform.rotation.eulerAngles.y, 0f));

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            moving = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "WanderingAgent" || other.tag == "Unselected")
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
                playerRenderer.enabled = false;
                StartCoroutine(WanderingAgentFlash());
            }
        }


    }

    public IEnumerator WanderingAgentFlash()
    {
        yield return new WaitForSecondsRealtime(waitLength);
        playerRenderer.enabled = !playerRenderer.enabled;

        yield return new WaitForSecondsRealtime(waitLength);
        flashCounter++;

        if (flashCounter < flashNo)
        {
            StartCoroutine(WanderingAgentFlash());
        }
        else
        {
            scriptOfGame.GameOver();
        }
    }
}