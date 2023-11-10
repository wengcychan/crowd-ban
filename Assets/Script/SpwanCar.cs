using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

namespace PathCreation.Examples
{

    public class SpwanCar : MonoBehaviour
    {
        public List<PathCreator> pathPrefab = new List<PathCreator>();
        public CarPathFollower followerPrefab;
        public float genSpeed;
        public int randCar;
        int startGen;
        public float speed;

        public List<GameObject> carAlert = new List<GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            speed = 6f;
            startGen = Random.Range(100, 105);
            Invoke("Generate", startGen);
        }

        // Update is called once per frame
        void Generate()
        {
            randCar = Random.Range(0, 16);
            switch (speed)
            {
                case 6f:
                    genSpeed = Random.Range(28, 30);
                    break;

                case 9f:
                    genSpeed = Random.Range(18, 20);
                    break;

                case 12f:
                    genSpeed = Random.Range(15, 17);
                    break;

                case 15f:
                    genSpeed = Random.Range(12, 14);
                    break;

                case 18f:
                    genSpeed = Random.Range(12, 14);
                    break;

                default:
                    genSpeed = Random.Range(28, 30);
                    break;

            }

            StartCoroutine(AlertStop());

        }

        IEnumerator AlertStop()
        {

            carAlert[randCar/4].SetActive(true);

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(5);

            carAlert[randCar/4].SetActive(false);

            var path = pathPrefab[randCar];
            var follower = Instantiate(followerPrefab);
            follower.pathCreator = path;
            Invoke("Generate", genSpeed);
        }
    }
}
