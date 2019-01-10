using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public LayerMask AttackLayer;
	public string KillTag = "Body";
	public GameObject Imprint;
	public GameObject Explosion;
	public Color ImprintColor;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{

		if ((AttackLayer & (1 << other.collider.gameObject.layer)) != 0) {

			if (other.collider.gameObject.tag == KillTag) {
				
				GameObject myImprint = Instantiate(Imprint, transform.parent.position, transform.parent.rotation);
				GameObject otherImprint = Instantiate(Imprint, other.gameObject.transform.position, other.gameObject.transform.rotation);

				Instantiate(Explosion, other.gameObject.transform.position, other.gameObject.transform.rotation);

				ParticleSystem[] myParticles = myImprint.GetComponentsInChildren<ParticleSystem>();
				ParticleSystem[] otherParticles = otherImprint.GetComponentsInChildren<ParticleSystem>();
				
				foreach (ParticleSystem system in myParticles)
				{
					var main = system.main;
					main.startColor = ImprintColor;
					system.Play();
				}
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
