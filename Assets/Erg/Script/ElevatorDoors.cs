using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoors : MonoBehaviour
{
    Animator anim;
    bool Apri;
    // Start is called before the first frame update
    void Start()
    {
        Apri = false;
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Apri = true;
            doorControl("Open");
            Debug.Log("Apri");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Apri = false;
            doorControl("Close");

        }
    }

    void doorControl(string direzione)
    {
        anim.SetTrigger(direzione);
    }
}
