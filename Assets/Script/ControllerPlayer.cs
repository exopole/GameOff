using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(DeplacementBehaviour))]
public class ControllerPlayer : MonoBehaviour
{

    public DeplacementBehaviour DeplacementBehaviour;
	public StandaloneInputModule InputModule;
    // Start is called before the first frame update
    void Start()
    {
        DeplacementBehaviour = GetComponent<DeplacementBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        Deplacement();
    }

    private void Deplacement()
	{
		Vector3 direction = new Vector3();
        direction.x = InputModule.input.GetAxisRaw(InputModule.horizontalAxis);
        direction.z = InputModule.input.GetAxisRaw(InputModule.verticalAxis);
        DeplacementBehaviour.Direction = direction.normalized;
	}
}
