using UnityEngine;
using System.Collections;

public class Bird_Movement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public float flapSpeed    = 100f;
	public float forwardSpeed = 1f;
	public Animator oscurecedor;
	public Animator canvas;
	public GameObject puntuacion;
	
	bool didFlap = false;
	
	Animator animator;
	
	public bool dead = false;
	float deathCooldown;
	
	public bool godMode = false;
	
	// Use this for initialization
	void Start () {
		puntuacion.SetActive (true);
		animator = transform.GetComponentInChildren<Animator>();
		
		if(animator == null) {
			Debug.LogError("Didn't find animator!");
		}
	}
	
	// Do Graphic & Input updates here
	void Update() {
		if(dead) {
			puntuacion.SetActive (false);
			oscurecedor.Play("Oscurecer");
			canvas.Play("SlideDownCanvas");
			/*deathCooldown -= Time.deltaTime;
			
			if(deathCooldown <= 0) {
			}*/
		}
		else {
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
				didFlap = true;
			}
		}
	}
	
	
	// Do physics engine updates here
	void FixedUpdate () {
		
		if(dead)
			return;
		
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
		if(godMode)
			return;
		
		animator.SetTrigger("Death");
		dead = true;
		deathCooldown = 0.5f;
	}
}
