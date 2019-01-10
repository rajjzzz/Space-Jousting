using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	public LayerMask AttackLayer;
	public string KillTag = "Body";
	public GameObject Imprint;
	public GameObject Explosion;
	public float MaxStartSpeed;
	
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-MaxStartSpeed, MaxStartSpeed), Random.Range(-MaxStartSpeed, MaxStartSpeed)));
	}

	void OnCollisionEnter2D(Collision2D other)
	{

		if ((AttackLayer & (1 << other.collider.gameObject.layer)) != 0) {

			if (other.collider.gameObject.tag == KillTag) {
				
				GameObject otherImprint = Instantiate(Imprint, other.gameObject.transform.position, other.gameObject.transform.rotation);

				Instantiate(Explosion, other.gameObject.transform.position, other.gameObject.transform.rotation);

				ParticleSystem[] otherParticles = otherImprint.GetComponentsInChildren<ParticleSystem>();
				
				foreach (ParticleSystem system in otherParticles)
				{
					var main = system.main;
					main.startColor = other.gameObject.GetComponentInChildren<PlayerAttack>().ImprintColor;
					system.Play();
				}

				other.gameObject.SetActive(false);
			}

		}
	}

}
