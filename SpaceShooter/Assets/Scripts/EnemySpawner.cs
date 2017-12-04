using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width =  10f;
	public float height = 5f;
	private bool movingRight = false;
	public float speed = 5f;
	public float xmax;
	public float xmin;


	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z -  Camera.main.transform.position.z;
		Vector3 leftboundary = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceToCamera));
		Vector3 rightboundary = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distanceToCamera));
		xmax = rightboundary.x;
		xmin = leftboundary.x;

		foreach( Transform child in transform){
						GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
						enemy.transform.parent = child;
					}
			}

	public void OnDrawGizmos () {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}

	void Update () {
		if (movingRight) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);
		if (leftEdgeOfFormation < xmin || rightEdgeOfFormation > xmax) {
			movingRight = !movingRight;
		}

			
	}



}

