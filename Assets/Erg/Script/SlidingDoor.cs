using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    Animator anim;
    bool Apri;
    AudioSource slidingsound;
    // Start is called before the first frame update
    void Start()
    {
        Apri = false;
        anim  =GetComponent<Animator>();
        slidingsound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Apri = true;
            doorControl("Open");
            slidingsound.Play();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Apri = false;
            doorControl("Close");
            slidingsound.Play();
        }
    }

    void doorControl(string direzione)
    {
        anim.SetTrigger(direzione);
    }
}
