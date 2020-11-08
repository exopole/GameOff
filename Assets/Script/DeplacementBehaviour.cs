using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TestDeplacement
{
	CharacterController,
	RigidbodyMovePosition,
	RigidBodyAddForce
}

[RequireComponent(typeof(CharacterController))]
public class DeplacementBehaviour : MonoBehaviour
{

	private CharacterController mCharacterController;
	private Rigidbody mBody;
	public TestDeplacement Test = TestDeplacement.CharacterController;
	public Vector3 Direction;

	public float Speed;
	public float SpeedForce;
	public float VelocityMax;

	private void Awake()
	{
		mCharacterController = GetComponent<CharacterController>();
		mBody = GetComponent<Rigidbody>();
	}

	private void LateUpdate()
	{
		if (Test == TestDeplacement.CharacterController)
		{
			mCharacterController.enabled = true;
			mCharacterController.Move(Direction * Time.deltaTime * Speed);
		}
		else
		{
			mCharacterController.enabled = false;

		}
		if (Direction != Vector3.zero)
			transform.forward = Direction;
	}

	private void FixedUpdate()
	{
		switch (Test)
		{
			case TestDeplacement.RigidbodyMovePosition:
				mBody.MovePosition(mBody.position + Direction * Speed * Time.deltaTime);
				break;
			case TestDeplacement.RigidBodyAddForce:
				mBody.AddForce(Direction * Speed);
				break;
			default:
				break;
		}
	}


}
