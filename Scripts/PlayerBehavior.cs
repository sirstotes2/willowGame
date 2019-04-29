using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
	private Rigidbody2D rb2D;
	public Controls c;
	private Collider2D floorCollider;
	public LayerMask groundLayers;
	public float jumpSpeed = 0f;
	public float walkSpeed = 0f;
	public bool isGrounded = false;
	private bool needFall = true;
	// Use this for initialization
	void Start () {
		rb2D = transform.GetComponent<Rigidbody2D>();
		floorCollider = transform.GetComponents<Collider2D>()[1];
	}
	
	// Update is called once per frame
	void Update () {
		if (c.GetHorizontal() > 0) {
			MoveRight(walkSpeed);
		} else if (c.GetHorizontal() < 0) {
			MoveLeft(walkSpeed);
		} else {
			Stop();
		}
		if (c.GetVertical() > 0 && isGrounded) {
			Jump();
		}
		if (!(c.GetVertical() > 0) && !isGrounded && needFall) {
			Fall();
		}
	}
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			isGrounded = true;
			needFall = false;
		}
	}
	void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}
	public void MoveRight (float speed) {
		rb2D.AddForce(transform.right * speed);
	}
	public void MoveLeft (float speed) {
		rb2D.AddForce(-transform.right * speed);
	}
	public void Stop () {
		rb2D.velocity = new Vector2(rb2D.velocity.x*0.5f, rb2D.velocity.y);
	}
	public void Jump () {
        rb2D.AddForce(transform.up * jumpSpeed);
		isGrounded = false;
		needFall = true;
	}
	public void Fall () {
        rb2D.AddForce(-transform.up * jumpSpeed * 0.1f);
	}
}
