using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

namespace PathCreation.Examples
{

    public class SpwanAgent : MonoBehaviour
    {
        public List<PathCreator> pathPrefab = new List<PathCreator>();
        public HumanPathFollower followerPrefab;
        public float genSpeed;
        public int randAgent;
        public bool timeStopApplied = false;
        public float speed;
        public bool doubleAgent = false;


        public List<GameObject> agentAlert = new List<GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            speed = 4.0f;
            Invoke("Generate", 0);
        }

        // Update is called once per frame
        void Generate()
        {
            randAgent = Random.Range(0, 101);
            StartCoroutine(AlertStop());
            if (doubleAgent == false)
            {
                switch (speed)
                {
                    case 4f:
                        if (randAgent >= 0 && randAgent <= 83)
                            genSpeed = Random.Range(16, 19);
                        else
                            genSpeed = Random.Range(22, 25);
                        break;

                    case 6f:
                        if (randAgent >= 0 && randAgent <= 83)
                            genSpeed = Random.Range(11, 14);
                        else
                            genSpeed = Random.Range(16, 19);
                        break;

                    case 8f:
                        if (randAgent >= 0 && randAgent <= 83)
                            genSpeed = Random.Range(7, 10);
                        else
                            genSpeed = Random.Range(11, 14);
                        break;

                    case 10f:
                        if (randAgent >= 0 && randAgent <= 83)
                            genSpeed = Random.Range(5, 8);
                        else
                            genSpeed = Random.Range(7, 10);
                        break;

                    case 12f:
                        if (randAgent >= 0 && randAgent <= 83)
                            genSpeed = Random.Range(5, 8);
                        else
                            genSpeed = Random.Range(7, 10);
                        break;

                    default:
                        if (randAgent >= 0 && randAgent <= 83)
                            genSpeed = Random.Range(16, 19);
                        else
                            genSpeed = Random.Range(22, 25);
                        break;

                }
            }
            else
            {
                switch (speed)
                {
                    case 4f:
                        if (randAgent >= 0 && randAgent <= 83)
                            genSpeed = Random.Range(10, 13);
                        else
                            genSpeed = Random.Range(15, 17);
                        break;

                    case 6f:
                        if (randAgent >= 0 && randAgent <= 83)
                            genSpeed = Random.Range(6, 8);
                        else
                            genSpeed = Random.Range(11, 13);
                        break;

                    case 8f:
                        if (randAgent >= 0 && randAgent <= 83)
                            genSpeed = Random.Range(2, 4);
                        else
                            genSpeed = Random.Range(6, 8);
                        break;

                    case 10f:
                        if (randAgent >= 0 && randAgent <= 83)
                            genSpeed = Random.Range(1, 3);
                        else
                            genSpeed = Random.Range(2, 4);
                        break;

                    case 12f:
                        if (randAgent >= 0 && randAgent <= 83)
                            genSpeed = Random.Range(1, 3);
                        else
                            genSpeed = Random.Range(2, 4);
                        break;

                    default:
                        if (randAgent >= 0 && randAgent <= 83)
                            genSpeed = Random.Range(10, 13);
                        else
                            genSpeed = Random.Range(15, 17);
                        break;
                }
            }
        }

        IEnumerator AlertStop()
        {
            if (timeStopApplied == true)
			{
                yield return new WaitForSeconds(2);
                timeStopApplied = false;
            }

            if (randAgent >= 0 && randAgent <= 5)
			{
                agentAlert[0].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[0].SetActive(false);
            }
            else if (randAgent >= 6 && randAgent <= 11)
            {
                agentAlert[1].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[1].SetActive(false);
            }
            else if (randAgent >= 12 && randAgent <= 17)
            {
                agentAlert[2].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[2].SetActive(false);
            }
            else if (randAgent >= 18 && randAgent <= 21)
            {
                agentAlert[3].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[3].SetActive(false);
            }
            else if (randAgent >= 22 && randAgent <= 26)
            {
                agentAlert[4].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[4].SetActive(false);
            }
            else if (randAgent >= 27 && randAgent <= 32)
            {
                agentAlert[5].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[5].SetActive(false);
            }
            else if (randAgent >= 33 && randAgent <= 38)
            {
                agentAlert[6].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[6].SetActive(false);
            }
            else if (randAgent >= 39 && randAgent <= 44)
            {
                agentAlert[7].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[7].SetActive(false);
            }
            else if (randAgent >= 45 && randAgent <= 49)
            {
                agentAlert[8].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[8].SetActive(false);
            }
            else if (randAgent >= 50 && randAgent <= 54)
            {
                agentAlert[9].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[9].SetActive(false);
            }
            else if (randAgent >= 55 && randAgent <= 59)
            {
                agentAlert[10].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[10].SetActive(false);
            }
            else if (randAgent >= 60 && randAgent <= 63)
            {
                agentAlert[11].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[11].SetActive(false);
            }
            else if (randAgent >= 64 && randAgent <= 67)
            {
                agentAlert[12].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[12].SetActive(false);
            }
            else if (randAgent >= 68 && randAgent <= 72)
            {
                agentAlert[13].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[13].SetActive(false);
            }
            else if (randAgent >= 73 && randAgent <= 77)
            {
                agentAlert[14].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[14].SetActive(false);
            }
            else if (randAgent >= 78 && randAgent <= 83)
            {
                agentAlert[15].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[15].SetActive(false);
            }
            else if (randAgent >= 84 && randAgent <= 85)
            {
                agentAlert[16].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[16].SetActive(false);
            }
            else if (randAgent >= 86 && randAgent <= 87)
            {
                agentAlert[17].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[17].SetActive(false);
            }
            else if (randAgent >= 88 && randAgent <= 88)
            {
                agentAlert[18].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[18].SetActive(false);
            }
            else if (randAgent >= 89 && randAgent <= 89)
            {
                agentAlert[19].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[19].SetActive(false);
            }
            else if (randAgent >= 90 && randAgent <= 92)
            {
                agentAlert[20].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[20].SetActive(false);
            }
            else if (randAgent >= 93 && randAgent <= 95)
            {
                agentAlert[21].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[21].SetActive(false);
            }
            else if (randAgent >= 96 && randAgent <= 98)
            {
                agentAlert[22].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[22].SetActive(false);
            }

            else if (randAgent >= 99 && randAgent <= 100)
            {
                agentAlert[23].SetActive(true);
                yield return new WaitForSeconds(5);
                agentAlert[23].SetActive(false);
            }

            var path = pathPrefab[randAgent];
            var follower = Instantiate(followerPrefab);
            follower.pathCreator = path;
            Invoke("Generate", genSpeed);
        }
    }
}
