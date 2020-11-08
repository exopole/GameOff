using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class DeplacementBehaviour : MonoBehaviour
{

	private CharacterController mCharacterController;
	public Vector3 Direction;

	public float Speed;

	private void Awake()
	{
		mCharacterController = GetComponent<CharacterController>();
	}

	private void LateUpdate()
	{
		mCharacterController.Move(Direction * Time.deltaTime * Speed);
	}


}
