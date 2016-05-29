using UnityEngine;
using System.Collections;

public class MovimientoInicial : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public float flapSpeed    = 100f;
	public float forwardSpeed = 1f;

	Animator animator;
	bool didFlap = false;
	int contador = 0;

	public Collider complete;

	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();
		
		if(animator == null) {
			Debug.LogError("Didn't find animator!");
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {

		if (contador == 25) {
			didFlap = true;
			contador = 0;
		}
		contador++;

		GetComponent<Rigidbody2D>().AddForce( Vector2.right * forwardSpeed );
		
		if(didFlap) {
			GetComponent<Rigidbody2D>().AddForce( Vector2.up * flapSpeed );
			animator.SetTrigger("DoFlap");
			didFlap = false;
		}
		
		if(GetComponent<Rigidbody2D>().velocity.y > 0) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else {
			float angle = Mathf.Lerp (0, -90, (-GetComponent<Rigidbody2D>().velocity.y / 3f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Application.LoadLevel ("Menu");
	}
}
