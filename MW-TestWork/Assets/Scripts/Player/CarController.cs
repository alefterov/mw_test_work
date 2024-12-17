using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 80; 
    [SerializeField] private float _maxSpeed = 60; 
    [SerializeField] private float _drag = 0.98f; 
    [SerializeField] private float _steerAngle = 20; 
    [SerializeField] private float _traction = 1; 


    private Vector3 _moveForce;
    void Update()
    {
        _moveForce += transform.forward * _moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += _moveForce * Time.deltaTime;

        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * _moveForce.magnitude * _steerAngle * Time.deltaTime);

        _moveForce *= _drag;
        _moveForce = Vector3.ClampMagnitude(_moveForce, _maxSpeed);

        Debug.DrawRay(transform.position, _moveForce.normalized * 20, Color.blue);
        Debug.DrawRay(transform.position, transform.forward * 20, Color.red);

        _moveForce = Vector3.Lerp(_moveForce.normalized, transform.forward, _traction * Time.deltaTime) * _moveForce.magnitude;
    }
}
