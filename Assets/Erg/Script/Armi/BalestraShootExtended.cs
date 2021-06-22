using Nokobot.Assets.Crossbow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalestraShootExtended : MonoBehaviour
{
    private CrossbowShoot crossbowshoot;
    public GameObject Player;
    private OVRGrabbable oVRGrabbable;
    public OVRInput.Button shootbutton;
    private TeleportAimHandlerParabolic teleport;
   
    void Start()
    {
        crossbowshoot = GetComponentInChildren<CrossbowShoot>();
        oVRGrabbable = GetComponent<OVRGrabbable>();
        teleport = Player.GetComponentInChildren<TeleportAimHandlerParabolic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oVRGrabbable.isGrabbed && OVRInput.GetDown(shootbutton, oVRGrabbable.grabbedBy.GetController()))
        {
            //teleport.enabled = false;
            crossbowshoot.PullTheTrigger();
        }
        else
        {
            //teleport.enabled = true;
        }
    }
}
