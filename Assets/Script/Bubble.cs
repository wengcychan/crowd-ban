using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float speed;
    public Vector3 direction;       
    public Rigidbody rig;
    public bool goingLeft;     
    public bool goingDown;          
    public float height;
    public float width;
    public float ratio;
    float upperRange;
    float lowerRange;
    GameManager scriptOfGame = null;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(Random.Range(0.0f, 1.0f), 0, Random.Range(0.0f, 1.0f));
        height = Screen.height;
        width = Screen.width;
        ratio = (width / height) / (1920f / 1080f);
        upperRange = 160f * ratio - 45f;
        lowerRange = -160f * ratio + 45f;
        
        scriptOfGame = GameObject.FindObjectOfType<GameManager>();
        speed = scriptOfGame.bubbleSpeed / ratio;
    }

    // Update is called once per frame
    void Update()
    {
        speed = scriptOfGame.bubbleSpeed / ratio;

        rig.velocity = direction * speed * Time.deltaTime;

        if (transform.position.x > upperRange && !goingLeft)
        {
            direction = new Vector3(-direction.x, 0, direction.z);
            goingLeft = true;
        }
        if (transform.position.x < lowerRange && goingLeft)
        {
            direction = new Vector3(-direction.x, 0, direction.z);
            goingLeft = false;
        }
        if (transform.position.z > 45 && !goingDown)
        {
            direction = new Vector3(direction.x, 0, -direction.z);
            goingDown = true;
        }
        if (transform.position.z < -45 && goingDown)
        {
            direction = new Vector3(direction.x, 0, -direction.z);
            goingDown = false;
        }

    }

    void OnTriggerEnter(Collider aOther)
    {
        if (aOther.tag == "Floor3")
        {
            Vector3 dir = new Vector3();            

            dir = transform.position - aOther.transform.position;

            dir.Normalize();                       

            direction = dir;                        

            if (dir.x > 0)                          
                goingLeft = false;
            if (dir.x < 0)                          
                goingLeft = true;
            if (dir.z > 0)                          
                goingDown = false;
            if (dir.z < 0)                         
                goingDown = true;
        }
    }
}
