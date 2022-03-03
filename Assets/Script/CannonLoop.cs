using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLoop : MonoBehaviour
{
    private const float FOV = 55;
    private const float CD = 1f; 
    private Vector2 _projection;
    public Transform Barrel;
    public GameObject CannonBallPrefab;
    public float ForceMagnitude = 1.5f;
    public List<GameObject> Targets;

    private void Awake()
    {
        _projection = new Vector2(transform.position.x, transform.position.y);
    }

    private void Start()
    {
        StartCoroutine(_shootTargets());
    }
    public bool InFOV(Vector3 v)
    {
        
        Vector2 x = new Vector2(v.x, v.z);
        float angle = Vector2.Angle(x - _projection, (new Vector2(0, 0)) - _projection);

        if (angle > FOV)
        {
            Debug.Log("Out of range!");
        }
        return angle <= FOV;
    }
    private IEnumerator _shootTargets()
    {
        foreach(var target in Targets)
        {
            if (InFOV(target.transform.position))
            {
                yield return new WaitForSeconds(CD);
                _shootTarget(target.transform.position);
            }
        }
    }
    private void _shootTarget(Vector3 target)
    {
        transform.LookAt(target);
        var ball = Instantiate(CannonBallPrefab, Barrel.position, Quaternion.identity);
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        var dir = target - transform.position;
        ballBody.AddForce(ForceMagnitude * dir, ForceMode.Impulse);
    }
}