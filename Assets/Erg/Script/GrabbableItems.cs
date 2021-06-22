using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItems : OVRGrabbable
{
    [SerializeField] private Material _IsGrabbableMat;
    private Material _Originalmat;
    private Renderer _renderer;
    protected override void Start()
    {
        base.Start();
        _renderer = GetComponent<Renderer>();
        _Originalmat = _renderer.material;
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        _renderer.material = _IsGrabbableMat;
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        _renderer.material = _Originalmat;
    }
}
