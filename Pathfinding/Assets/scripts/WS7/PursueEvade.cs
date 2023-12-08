using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueEvade : MonoBehaviour
{
    public GameObject Character;
    public GameObject Target;

    public bool IsEvadeMode = false;

    private Vector3 _velocity;
    public float Mass = 15;
    public float MaxVelocity = 3;
    public float MaxForce = 15;

    // Start is called before the first frame update
    void Start()
    {
        _velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredVelocity = Target.transform.position - Character.transform.position;

        float pred = desiredVelocity.magnitude / MaxVelocity;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity * pred;

        Vector3 steering = desiredVelocity - _velocity;
        steering = Vector3.ClampMagnitude(steering, MaxForce);
        steering /= Mass;

        _velocity = Vector3.ClampMagnitude(_velocity + steering, MaxVelocity);

        if (!IsEvadeMode)
            Character.transform.position += _velocity * UnityEngine.Time.deltaTime;
        else
            Character.transform.position += (-1 * _velocity) * UnityEngine.Time.deltaTime;

        Character.transform.position = new Vector3(Character.transform.position.x, 1, Character.transform.position.z);
        Character.transform.forward = _velocity.normalized;
    }
}
