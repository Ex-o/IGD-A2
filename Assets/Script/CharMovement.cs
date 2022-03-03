using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    private void Awake()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();

        var colls = GetComponentsInChildren<Collider>();
        colls.ToList().ForEach(x => x.gameObject.AddComponent<CharCollisionHandler>());
        SetKinematic(true);
    }

    public void SetKinematic(bool f)
    {
        _rigidbodies.ToList().ForEach(x => x.isKinematic = f);
    }
}
