using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision ball)
    { 
        transform.root.gameObject.GetComponent<CharMovement>().SetKinematic(false);
    }
}
