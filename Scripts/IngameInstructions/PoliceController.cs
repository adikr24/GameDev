using System;
using UnityEngine;
using UnityEngine.AI;

public class PoliceController : MonoBehaviour
{
    [SerializeField] private WheelCollider _frontLeftWheelCollider;
    [SerializeField] private WheelCollider _frontRightWheelCollider;
    [SerializeField] private WheelCollider _rearLeftWheelCollider;
    [SerializeField] private WheelCollider _rearRightWheelCollider;
    
    [SerializeField] private Transform _frontLeftTransform;
    [SerializeField] private Transform _frontRightTransform;
    [SerializeField] private Transform _rearLeftTransform;
    [SerializeField] private Transform _rearRightTransform;
    
    [SerializeField] private Transform _target;

    private NavMeshAgent _navMeshAgent;
    private float _maxTurnAngle = 30f;
    private float _acceleration = 1500f;
	
	// to get away with the error in the system //
	public Vector3 pos  = new Vector3 (0,0,0);

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(pos);
    }

    private void FixedUpdate()
    {
        Steer();
        Drive();
        UpdateWheels();
    }

    private void Steer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(_target.position);
        float newSteerAngle = (relativeVector.x / relativeVector.magnitude) * _maxTurnAngle;

        _frontLeftWheelCollider.steerAngle = newSteerAngle;
        _frontRightWheelCollider.steerAngle = newSteerAngle;
    }

    private void Drive()
    {
        _frontLeftWheelCollider.motorTorque = _acceleration;
        _frontRightWheelCollider.motorTorque = _acceleration;
        _rearLeftWheelCollider.motorTorque = _acceleration;
        _rearRightWheelCollider.motorTorque = _acceleration;
    }
    
    private void UpdateWheels()
    {
        UpdateWheel(_frontLeftWheelCollider, _frontLeftTransform);
        UpdateWheel(_frontRightWheelCollider, _frontRightTransform);
        UpdateWheel(_rearLeftWheelCollider, _rearLeftTransform);
        UpdateWheel(_rearRightWheelCollider, _rearRightTransform);
    }
    
    private void UpdateWheel(WheelCollider wheelCollider, Transform transform)
    {
        wheelCollider.GetWorldPose(out Vector3 position, out Quaternion rotation);

        transform.position = position;
        transform.rotation = rotation;
    }
}
