using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFollowing : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public float maxdistance;
    private Transform myTransform;
    //------------------------------------//    

    void Awake()
    {
        myTransform = transform;
    }


    void Start()
    {

        maxdistance = 2;
    }


    void Update()
    {
        transform.LookAt(target);

        if (Vector3.Distance(target.position, myTransform.position) > maxdistance)
        {
            // Get a direction vector from us to the target
            Vector3 dir = target.position - myTransform.position;

            // Normalize it so that it's a unit direction vector
            dir.Normalize();

            // Move ourselves in that direction
            myTransform.position += dir * moveSpeed * Time.deltaTime;
        }
    }
}
