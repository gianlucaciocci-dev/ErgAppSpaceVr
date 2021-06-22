using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatMidAir : MonoBehaviour
{
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public Transform Player;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    //Music
    Transform Music;
    AudioSource movimento;
    AudioSource stop;
    //private Transform AnelloRotante1;
    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        //AnelloRotante1 = gameObject.transform.Find("Cylinder.007AnelloRotante").GetComponentInChildren<Transform>();
        //instanzio musica
        Music = transform.Find("MusicDrone");
        movimento = Music.Find("Movimento").GetComponent<AudioSource>();
        stop = Music.Find("Stop").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
        posOffset = transform.position;
        // Spin object around Y-Axis
        //AnelloRotante1.Rotate(new Vector3(0f, 1, 0f), Space.World);
        if (Vector3.Distance(Player.position, transform.position) > 2)
        {
            Vector3 dir = Player.position - transform.position;

            //        // Normalize it so that it's a unit direction vector
            dir.Normalize();

            //        // Move ourselves in that direction
            transform.position += dir * 1 * Time.deltaTime;
            
            movimento.Play();
        }
        else
        {
            
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = tempPos;
            movimento.Stop();
            stop.Play();
        }
        // Float up/down with a Sin()

    }
}
