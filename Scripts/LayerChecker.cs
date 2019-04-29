using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChecker : MonoBehaviour {
	public bool isTouching = false;
	void OnCollisionEnter2D (Collision2D col) {
		Debug.Log("fjgshkugrrgkjskj");
		if (col.gameObject.tag == "Ground") {
			isTouching = true;
		}
	}
	void OnCollisionExit2D (Collision2D col) {
		Debug.Log("hj");
		if (col.gameObject.tag == "Ground") {
			isTouching = false;
		}
	}
}
