using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapScreen : MonoBehaviour {

	public LayerMask WrapLayer;
	public GameObject OppositeBound;
	public float Offset;
	public bool Vertical;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Head") {
			return;
		}

		if ((WrapLayer & (1 << other.gameObject.layer)) != 0) {

			if (Vertical) 
			{
				WrapVertical(other.gameObject.transform.parent);
			}
			else
			{
				WrapHorizontal(other.gameObject.transform.parent);
			}
			

		}
	}

	void WrapVertical(Transform other) {

		Vector3 otherPos = other.position;

		float distance = transform.position.y - OppositeBound.transform.position.y;
		float playerDistance = distance-2*(transform.position.y - otherPos.y);

		other.position = new Vector2(otherPos.x, otherPos.y - playerDistance + Offset);

	}

	void WrapHorizontal(Transform other) {

		Vector3 otherPos = other.position;

		float distance = transform.position.x - OppositeBound.transform.position.x;
		float playerDistance = distance-2*(transform.position.x - otherPos.x);

		other.position = new Vector2(otherPos.x - playerDistance + Offset, otherPos.y);

	}
}
