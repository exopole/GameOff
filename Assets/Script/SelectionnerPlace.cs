using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionnerPlace : MonoBehaviour
{
	public Transform SelectionImage;
	public GameObject SpriteObj;
	public LayerMask Mask;
	public Vector3 size;


	private void Awake()
	{
		Debug.Log("Size rect : " +  SpriteObj.GetComponent<SpriteRenderer>().sprite.rect + "\nVeritable size : " + (SpriteObj.GetComponent<SpriteRenderer>().sprite.rect.width * SpriteObj.transform.lossyScale.x) + "\n size : " + SpriteObj.GetComponent<SpriteRenderer>().sprite.rect.size);
	}

	private void Update()
	{
		RaycastHit hit;
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit, 100,Mask))
		{
			Vector3 positionHtit = hit.point;
			//Debug.Log("toucher : " + positionHtit + " // (positionHtit.x * 10) " + (positionHtit.x * 10));
			float facteurX = positionHtit.x/size.x;
			float facteurZ = positionHtit.z/size.z;
			float referenceX = facteurX - 0.5f - (int)(facteurX);
			float referenceZ = facteurZ - 0.5f - (int)(facteurZ);

			//Debug.Log("Facteur : " + facteurX + " // " + (int)facteurX);
			if (Mathf.Abs(referenceX) >= 0.25f && Mathf.Abs(referenceZ) >= 0.25f)
			{
				if(referenceX >= 0 && referenceZ >= 0)
				{
					positionHtit.x = (int)facteurX * size.x + size.x;
					positionHtit.z = (int)facteurZ * size.z + size.z;
				}
				else if (referenceX < 0 && referenceZ < 0)
				{
					positionHtit.x = (int)facteurX * size.x ;
					positionHtit.z = (int)facteurZ * size.z;
				}
				else if (referenceX >= 0 && referenceZ < 0)
				{
					positionHtit.x = (int)facteurX * size.x + size.x;
					positionHtit.z = (int)facteurZ * size.z;
				}
				else if(referenceX < 0 && referenceZ >= 0)
				{
					positionHtit.x = (int)facteurX * size.x;
					positionHtit.z = (int)facteurZ * size.z + size.z;
				}
				//Debug.Log("referenceX >= 0.25");
				//Debug.Log("Facteur : " + facteurX + " // " + (int)facteurX);
				Debug.Log("reference >= 0.25 \nFacteurX : " + facteurX + " // " + (int)facteurX + " // " + (facteurX - 0.5f - (int)(facteurX)) + "\nFacteurY : " + facteurZ + " // " + (int)facteurZ + " // " + (facteurZ - 0.5f - (int)(facteurZ)));
			}
			else
			{
				positionHtit.x = (int)facteurX * size.x + size.x/2;
				positionHtit.z = (int)facteurZ * size.z + size.z/2;
			}
			//Debug.Log("Reference : " + (Mathf.Abs(facteurX - size.x/2) + Mathf.Abs(facteurY - size.y/2)) + " // " + (int)facteurX);
			SelectionImage.transform.position = positionHtit;
		}
	}
}
