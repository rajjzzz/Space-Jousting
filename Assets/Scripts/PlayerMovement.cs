using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float MoveSpeed = 100f;
	public float RotateSpeed = 10f;

	public string HorizontalAxis;
	public string VerticalAxis;

	public float StartingFuel;
	public Slider FuelSlider;
	public float RechargeTime;
	public float RechargeFactor;

	private float CurrentFuel;

	private float RechargeCount;


	private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
		
		rb2d = GetComponent<Rigidbody2D>();

		CurrentFuel = StartingFuel;
		FuelSlider.maxValue = StartingFuel;

	}

	public void ResetFuel() {
		CurrentFuel = StartingFuel;
		rb2d.velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float horMove = Input.GetAxis(HorizontalAxis);
		float verMove = Input.GetAxis(VerticalAxis);

		rb2d.AddTorque(-RotateSpeed * Time.deltaTime * horMove);

		float movement = MoveSpeed * Time.deltaTime * verMove;
		Vector2 move = transform.up;

		if (Mathf.Abs(movement) > CurrentFuel)
			movement *= CurrentFuel/Mathf.Abs(movement);
			
		rb2d.AddForce(move * movement, ForceMode2D.Impulse);

		movement = Mathf.Abs(movement);

		CurrentFuel -= movement;
		
		if (movement > 0)
		{
			RechargeCount = RechargeTime;
		}
		else
		{
			RechargeCount -= Time.deltaTime;
			if (RechargeCount <= 0) {
				CurrentFuel += Time.deltaTime * RechargeFactor;
				if (CurrentFuel >= StartingFuel)
					CurrentFuel = StartingFuel;
			}
		}

		FuelSlider.value = CurrentFuel;

	}

}
