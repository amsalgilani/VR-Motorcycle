using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float acceleration = 0.5f;
    public float maximumSpeed = 10f;
    public float obstacleSlowdown = 0.25f;
    private float speed = 0f;
    public bool reachedFinishLine = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Acceleration logic

        speed += acceleration * Time.deltaTime;
        if (speed > maximumSpeed)
        {
            speed = maximumSpeed;
        }
        // Make the player move
        Vector3 direction = new Vector3(
            transform.forward.x,
            0,
            transform.forward.z
            ); 
        transform.position += direction.normalized * speed * Time.deltaTime;
        
        // Make player stay inside a certain area
        if (transform.position.x < -5f)
        {
            transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
        } else if (transform.position.x > 5f)
        {
            transform.position = new Vector3(5f, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.tag == "Obstacle")
        {
            speed *= obstacleSlowdown;

        } else if (otherCollider.tag == "FinishLine")
        {
            reachedFinishLine = true;
        }
    }
    
        
    }

