using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    [field: SerializeField]
    public List<Planet> Planets { get; private set; } = new();

    [field: SerializeField, ReadOnly]
    public float MetersPerUnit { get; private set; } = 1f;

    [field: SerializeField, ReadOnly]
    public float G { get; private set; } = 6.67e-11f;

    private float temp_radius;
    private Vector3 temp_acceleration;
    private Vector3 temp_direction;

    private void Update()
    {
        foreach(Planet planet in Planets)
        {
            temp_acceleration.Set(0,0,0);
            foreach(Planet other in Planets)
            {
                temp_direction = planet.transform.position - other.transform.position;
                temp_radius = temp_direction.sqrMagnitude;
                temp_direction.Normalize();
                temp_acceleration += (other.Mass/temp_radius) * temp_direction;
            }
            planet.Acceleration = temp_acceleration * G;
        }
    }
}
