using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
namespace PathCreation.Examples
{

    public class StopForBlackhole : MonoBehaviour
    {
        HumanPathFollower myScript = null;
        SpwanAgent scriptOfAI = null;
        public Animator anim;

        void OnTriggerEnter(Collider aOther)
        {

            if (aOther.tag == "Unselected")
            {
                myScript = transform.parent.GetComponent<HumanPathFollower>();
                scriptOfAI = GameObject.FindObjectOfType<SpwanAgent>();
                scriptOfAI.timeStopApplied = true;
                myScript.speed = 0;
                anim.SetBool("Moving", false);
                StartCoroutine(Stop());
            }
        }

        IEnumerator Stop()
        {
            yield return new WaitForSeconds(2);

            myScript.speed = scriptOfAI.speed;
            anim.SetBool("Moving", true);
        }
    }
}
