using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor_3 : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag =="Player")
        {
            anim.SetBool("character_nearby", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("character_nearby", false);
        //if (other.transform.tag == "Player")
        //{
            
        //}
    }
}
