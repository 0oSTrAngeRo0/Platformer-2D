using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [field: SerializeField]
    public float Mass { get; private set; }

    [field: SerializeField]
    public Vector3 Velocity { get; private set; }

    [field: SerializeField, ReadOnly]
    public Vector3 Acceleration { get; set; }

    private void Update()
    {
        Velocity += Acceleration * Time.deltaTime;
        transform.position += Velocity * Time.deltaTime;
    }
}
