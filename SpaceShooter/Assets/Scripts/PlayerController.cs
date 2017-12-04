 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public GameObject projectile;
	public float speed;
	public float projectileSpeed = 10;
	float xmin = -8;
	float xmax = 8;
	public float padding = 1f;
	public float firingRate = 0.2f;


	// Use this for initialization
	void Start () {
		//laser = GetComponent<Rigidbody2D> ();

		speed = 15f;
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;

	}
	
	// Update is called once per frame
	void Update () {

		Movement ();

	}

	void Fire (){
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0); 
	}


	void Movement (){

		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.000001f, firingRate);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
			beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);

		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}else if (Input.GetKey (KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		} 
		//restrict the player to the gamespace 
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

	}
}