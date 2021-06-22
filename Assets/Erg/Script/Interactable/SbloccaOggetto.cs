using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SbloccaOggetto : MonoBehaviour
{
    public GameObject SpawnPoint;
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void SbloccaBloccaOggetto(bool bloccasblocca)
    {
        transform.position = SpawnPoint.transform.position;
        this.gameObject.SetActive(bloccasblocca);
    }
}
