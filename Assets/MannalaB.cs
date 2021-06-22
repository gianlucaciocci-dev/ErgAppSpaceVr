using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannalaB : MonoBehaviour
{
    AudioSource Mannala;
    AudioSource MusicAmbiente;
    void Start()
    {
        Mannala = GetComponent<AudioSource>();
        MusicAmbiente = GameObject.Find("Music").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            if(MusicAmbiente.isPlaying)
            {
                MusicAmbiente.Stop();
                Mannala.Play();
                Debug.Log("mannala");
            }
            else if(Mannala.isPlaying)
            {
                Mannala.Stop();
                MusicAmbiente.Play();
            }
           
            //other.gameObject.tag = "Untagged";
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Untagged")
    //    {
            
    //        other.gameObject.tag = "Player";
    //    }
    //}
}
