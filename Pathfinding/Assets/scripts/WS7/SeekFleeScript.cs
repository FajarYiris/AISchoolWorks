using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekFleeScript : MonoBehaviour
{

    [SerializeField] private GameObject _character;
    [SerializeField] private GameObject _target;

    [SerializeField] private bool _fleeMode = false;

    private Vector3 _velocity;
    [SerializeField] private float _mass = 15.0f;
    [SerializeField] private float _maxVelocity = 3.0f;
    [SerializeField] private float _maxForce = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        _velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredVelocity = _target.transform.position - _character.transform.position;
        desiredVelocity = desiredVelocity.normalized * _maxVelocity;

        Vector3 steering = desiredVelocity - _velocity;
        steering = Vector3.ClampMagnitude(steering, _maxForce);
        steering /= _mass;

        _velocity = Vector3.ClampMagnitude(_velocity + steering, _maxVelocity);

        if(!_fleeMode)
            _character.transform.position += _velocity * UnityEngine.Time.deltaTime;
        else
            _character.transform.position += (-1 * _velocity) * UnityEngine.Time.deltaTime;

        _character.transform.position = new Vector3(_character.transform.position.x, 1, _character.transform.position.z);
        _character.transform.forward = _velocity.normalized;
    }
}
