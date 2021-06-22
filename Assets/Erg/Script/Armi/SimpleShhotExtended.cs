using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShhotExtended : MonoBehaviour
{
    private SimpleShoot simpleShoot;
    private OVRGrabbable oVRGrabbable;
    public OVRInput.Button shootbutton; 
    void Start()
    {
        simpleShoot = GetComponentInChildren<SimpleShoot>();
        oVRGrabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(oVRGrabbable.isGrabbed && OVRInput.GetDown(shootbutton,oVRGrabbable.grabbedBy.GetController()))
        {
            simpleShoot.PullTheTrigger();
        }
    }
}
