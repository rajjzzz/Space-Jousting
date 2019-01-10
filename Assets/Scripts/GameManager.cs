using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject PlayerOne;
	public GameObject PlayerTwo;

	public Transform PositionOne;
	public Transform PositionTwo;

	public float PostGameDelay;

	private bool PlayerOneRespawning = false;
	private bool PlayerTwoRespawning = false;

	public Text PlayerOneScoreText;
	public Text PlayerTwoScoreText;

	private int PlayerOneScoreCount = 0;
	private int PlayerTwoScoreCount = 0;

	// Use this for initialization
	void Start () {

		PlayerOne.transform.position = PositionOne.position;
		PlayerOne.transform.rotation = PositionOne.rotation;

		PlayerTwo.transform.position = PositionTwo.position;
		PlayerTwo.transform.rotation = PositionTwo.rotation;

		PlayerOne.SetActive(true);
		PlayerTwo.SetActive(true);

		PlayerOne.GetComponent<PlayerMovement>().ResetFuel();
		PlayerTwo.GetComponent<PlayerMovement>().ResetFuel();

		foreach(GameObject particle in GameObject.FindGameObjectsWithTag("Particles"))
		{
			Destroy(particle);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (!PlayerOne.activeInHierarchy && !PlayerOneRespawning)
			StartCoroutine(RespawnPlayerOne());

		if (!PlayerTwo.activeInHierarchy && !PlayerTwoRespawning)
			StartCoroutine(RespawnPlayerTwo());

	}

	IEnumerator RespawnPlayerOne() {

		PlayerTwoScoreCount++;
		PlayerTwoScoreText.text = PlayerTwoScoreCount + "";

		PlayerOneRespawning = true;

		yield return new WaitForSeconds(PostGameDelay);

		PlayerOne.transform.position = PositionOne.position;
		PlayerOne.transform.rotation = PositionOne.rotation;
		PlayerOne.SetActive(true);
		PlayerOne.GetComponent<PlayerMovement>().ResetFuel();

		// foreach(GameObject particle in GameObject.FindGameObjectsWithTag("Particles"))
		// {
		// 	Destroy(particle);
		// }

		PlayerOneRespawning = false;
		
	}

	IEnumerator RespawnPlayerTwo() {

		PlayerOneScoreCount++;
		PlayerOneScoreText.text = PlayerOneScoreCount + "";

		PlayerTwoRespawning = true;

		yield return new WaitForSeconds(PostGameDelay);

		PlayerTwo.transform.position = PositionTwo.position;
		PlayerTwo.transform.rotation = PositionTwo.rotation;
		PlayerTwo.SetActive(true);
		PlayerTwo.GetComponent<PlayerMovement>().ResetFuel();

		// foreach(GameObject particle in GameObject.FindGameObjectsWithTag("Particles"))
		// {
		// 	Destroy(particle);
		// }

		PlayerTwoRespawning = false;
		

	}

}
