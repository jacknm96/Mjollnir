using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class MovementBase : MonoBehaviour
{
    public Rigidbody rb;
    protected Vector3 direction = Vector3.zero;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected abstract void OnMove();

    protected float DistanceFromPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y) + (a.z - b.z) * (a.z - b.z));
    }
}
