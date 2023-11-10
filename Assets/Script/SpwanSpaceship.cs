using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

namespace PathCreation.Examples
{

    public class SpwanSpaceship : MonoBehaviour
    {
        public List<PathCreator> pathPrefab = new List<PathCreator>();
        public CarPathFollower followerPrefab;
        float genSpeed;
        public int randCar;
        public float speed;
        int startGen;

        public List<GameObject> carAlert = new List<GameObject>();

        void Start()
        {
            startGen = Random.Range(100, 105);
            speed = 6;
            Invoke("Generate", startGen);
        }

        void Generate()
        {
            randCar = Random.Range(0, 12);
            switch (speed)
            {
                case 6f:
                    genSpeed = Random.Range(22, 25);
                    break;

                case 9f:
                    genSpeed = Random.Range(14, 16);
                    break;


                case 12f:
                    genSpeed = Random.Range(11, 13);
                    break;


                case 15f:
                    genSpeed = Random.Range(8, 11);
                    break;

                case 18f:
                    genSpeed = Random.Range(8, 11);
                    break;

                default:
                    genSpeed = Random.Range(22, 25);
                    break;
            }

            StartCoroutine(AlertStop());

        }

        IEnumerator AlertStop()
        {

            carAlert[randCar / 3].SetActive(true);

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(5);

            carAlert[randCar / 3].SetActive(false);

            var path = pathPrefab[randCar];
            var follower = Instantiate(followerPrefab);
            follower.pathCreator = path;
            Invoke("Generate", genSpeed);
        }
    }
}
