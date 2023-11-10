using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class CarPathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed;
        float distanceTravelled;
        SpwanCar scriptOfCar = null;
        SpwanSpaceship scriptOfSpaceship = null;

        void Start()
        {
            scriptOfCar = GameObject.FindObjectOfType<SpwanCar>();
            scriptOfSpaceship = GameObject.FindObjectOfType<SpwanSpaceship>();

            if (this.tag == "Car" || this.tag == "Yacht")
            {
                speed = scriptOfCar.speed;
            }
            else if (this.tag == "Spaceship")
            {
                speed = scriptOfSpaceship.speed;
            }

            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                if (this.tag == "Yacht")
				{
                    Vector3 currentRotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction).eulerAngles;
                    currentRotation.x = 90.0f;
                    currentRotation.y = currentRotation.y-90.0f;
                    transform.localRotation = Quaternion.Euler(currentRotation);
                }

                if (this.tag == "Spaceship")
                {
                    Vector3 currentRotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction).eulerAngles;
                    currentRotation.y = currentRotation.y - 180.0f;
                    transform.localRotation = Quaternion.Euler(currentRotation);
                }
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Target")
            {
                Destroy(gameObject);
            }

        }
    }
}