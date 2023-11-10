using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    public List<GameObject> wanderingAgrent = new List<GameObject>();
    public GameObject blackhole;
    float genSpeed;
    Vector3 playerPos;
    int randAgent;
    int startGen;
    bool startRotate = false;
    float rotateSpeed;
    float scaleSpeed;
    float genBlackholeRotateSpeed;
    float genBlackholeScaleSpeed;
    float minSize;
    float maxSize;
    GameObject cloneBlackhole;
    public List<GameObject> floor = new List<GameObject>();
    Vector3 floorPos;
    int randFloor;
    AgentCountCylinder scriptOfCount = null;
    bool genBlockhole = false;
    bool genAgent = false;
    bool regenBlackhole = false;
    WanderingAI scriptofAI = null;

    // Start is called before the first frame update
    void Start()
    {
        startGen = 2;
        rotateSpeed = 500.0f;
        scaleSpeed = 5.0f;
        genBlackholeRotateSpeed = 100.0f;
        genBlackholeScaleSpeed = 10.0f;
        minSize = 0.0f;
        maxSize = 14.0f;
        Invoke("Generate", startGen);
    }

    void Generate()
    {
        randAgent = Random.Range(0, 10);
        genSpeed = Random.Range(20, 23);
        randFloor = Random.Range(0, 4);

        for (int i=0; i< floor.Count; i++)
		{
            scriptOfCount = floor[i].GetComponent<AgentCountCylinder>();
            if (scriptOfCount.agent.Contains(wanderingAgrent[randAgent]))
			{
                break;
			}
            else
			{
                scriptOfCount = null;

            }
		}

        scriptofAI = wanderingAgrent[randAgent].GetComponent<WanderingAI>();

        if (scriptOfCount == null || scriptofAI.tap==true || scriptofAI.moving == true)
        {
            Invoke("Generate", 0);
        }
        else
		{
            wanderingAgrent[randAgent].tag = "Unselected";
            scriptofAI.tap = false;
            scriptofAI.moving = false;

            StartCoroutine(GenBlackhole());
        }
    }

    void Update()
    {
        if (genBlockhole == true)
        {
            cloneBlackhole.transform.RotateAround(cloneBlackhole.transform.position, Vector3.up, genBlackholeRotateSpeed * Time.deltaTime);
            if (cloneBlackhole.transform.localScale.x < maxSize)
            {
                cloneBlackhole.transform.localScale = new Vector3(cloneBlackhole.transform.localScale.x + Time.deltaTime * genBlackholeScaleSpeed, cloneBlackhole.transform.localScale.y + Time.deltaTime * genBlackholeScaleSpeed, cloneBlackhole.transform.localScale.z);
            }
            else
			{
                genBlockhole = false;
            }
        }

        if (startRotate == true)
        {
            wanderingAgrent[randAgent].transform.RotateAround(wanderingAgrent[randAgent].transform.position, Vector3.up, rotateSpeed * Time.deltaTime);

            cloneBlackhole.transform.RotateAround(cloneBlackhole.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
            if (cloneBlackhole.transform.localScale.x > minSize)
            {
                cloneBlackhole.transform.localScale = new Vector3(cloneBlackhole.transform.localScale.x - Time.deltaTime * scaleSpeed, cloneBlackhole.transform.localScale.y - Time.deltaTime * scaleSpeed, cloneBlackhole.transform.localScale.z);
            }

            if (wanderingAgrent[randAgent].transform.localScale.x > minSize)
            {
                wanderingAgrent[randAgent].transform.localScale = new Vector3(wanderingAgrent[randAgent].transform.localScale.x - Time.deltaTime * scaleSpeed, wanderingAgrent[randAgent].transform.localScale.y, wanderingAgrent[randAgent].transform.localScale.z - Time.deltaTime * scaleSpeed);
            }
            else
            {
                wanderingAgrent[randAgent].SetActive(false);
                cloneBlackhole.SetActive(false);
                scriptOfCount.agent.Remove(wanderingAgrent[randAgent]);
                startRotate = false;
            }
        }

        if (genAgent == true)
        {
            wanderingAgrent[randAgent].SetActive(true);

            wanderingAgrent[randAgent].transform.RotateAround(wanderingAgrent[randAgent].transform.position, Vector3.up, rotateSpeed * Time.deltaTime);

            if (wanderingAgrent[randAgent].transform.localScale.x < maxSize)
            {
                wanderingAgrent[randAgent].transform.localScale = new Vector3(wanderingAgrent[randAgent].transform.localScale.x + Time.deltaTime * scaleSpeed, wanderingAgrent[randAgent].transform.localScale.y, wanderingAgrent[randAgent].transform.localScale.z + Time.deltaTime * scaleSpeed);
            }
            else
            {
                genAgent = false;
                wanderingAgrent[randAgent].tag = "WanderingAgent";
                StartCoroutine(BlackDisappear());
            }

        }

        if (regenBlackhole == true)
        {
            cloneBlackhole.transform.RotateAround(cloneBlackhole.transform.position, Vector3.up, genBlackholeRotateSpeed * Time.deltaTime);
            if (cloneBlackhole.transform.localScale.x < maxSize)
            {
                cloneBlackhole.transform.localScale = new Vector3(cloneBlackhole.transform.localScale.x + Time.deltaTime * genBlackholeScaleSpeed, cloneBlackhole.transform.localScale.y + Time.deltaTime * genBlackholeScaleSpeed, cloneBlackhole.transform.localScale.z);
            }
            else
            {
                regenBlackhole = false;
                StartCoroutine(BlackholeFlash());

            }
        }
    }

    IEnumerator GenBlackhole()
    {

        playerPos = wanderingAgrent[randAgent].transform.position;

        playerPos.y = 0.0f;

        Vector3 currentRotation = new Vector3 (90.0f, 0.0f, 0.0f);


        cloneBlackhole = Instantiate(blackhole, playerPos , Quaternion.Euler(currentRotation));

        cloneBlackhole.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);

        genBlockhole = true;

        yield return new WaitForSeconds(4);

        startRotate = true;

        yield return new WaitForSeconds(6);

        Destroy(cloneBlackhole);

        yield return new WaitForSeconds(2);

        floorPos = floor[randFloor].transform.position + Random.insideUnitSphere * 40;

        floorPos.y = 0.0f;

        cloneBlackhole = Instantiate(blackhole, floorPos, Quaternion.Euler(currentRotation));

        cloneBlackhole.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);

        regenBlackhole = true;

        wanderingAgrent[randAgent].transform.localScale = new Vector3(0.0f, 14.0f, 0.0f);
        wanderingAgrent[randAgent].transform.position = new Vector3(floorPos.x, 10.0f, floorPos.z);

        scriptOfCount = null;
        Invoke("Generate", genSpeed);
    }


    public IEnumerator BlackholeFlash()
    {
        for (int i = 0; i < 10; i++)
        {
            cloneBlackhole.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            cloneBlackhole.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(0.2f);

        genAgent = true;

    }

    public IEnumerator BlackDisappear()
    {
        yield return new WaitForSeconds(0.5f);
        cloneBlackhole.SetActive(false);
        Destroy(cloneBlackhole);

    }
}
