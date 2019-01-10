using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	public float MaxStartSpeed;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-MaxStartSpeed, MaxStartSpeed), Random.Range(-MaxStartSpeed, MaxStartSpeed)));
	}
	
}
