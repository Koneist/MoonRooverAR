using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonRoverAr.Scripts.Vehicle
{
	public class VehiclePhysics : MonoBehaviour
	{
		[Header("Assigned")]
		[SerializeField] private WheelCollider[] _wheellCollider;
		[SerializeField] private Transform[] _wheelMeshes;
		
		[SerializeField] private float _maxSteerAngle = 30;
		[SerializeField] private float motorForce = 50;


		public void Steer(float input)
		{
			
			_wheellCollider[0].steerAngle = _maxSteerAngle * input;
			_wheellCollider[1].steerAngle = _maxSteerAngle * input;
		}

		public void Accelerate(float input)
		{
			for (int i = 0; i < 2; ++i)
			{
				_wheellCollider[i].motorTorque = motorForce * input;
			}
		}

		private void UpdateWheelPoses()
		{
			Vector3 pos;
			Quaternion quat;

			for (int i = 0; i < _wheellCollider.Length; ++i)
			{
				_wheellCollider[i].GetWorldPose(out pos, out quat);
				_wheelMeshes[i].position = pos;
				_wheelMeshes[i].rotation = quat;
			}
		}

		private void FixedUpdate()
		{
			UpdateWheelPoses();
		}

	}
}
