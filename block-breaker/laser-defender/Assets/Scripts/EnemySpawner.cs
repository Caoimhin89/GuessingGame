using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float speed = 5.5f;
	public float width = 10.0f;
	public float height = 5.0f;
	private float minX;
	private float maxX;
	private bool moveRight;

	// Use this for initialization
	void Start () {
		moveRight = true;
		foreach(Transform child in transform) {
			GameObject enemy = (GameObject)Instantiate(enemyPrefab, child.transform.position, Quaternion.identity);
			enemy.transform.parent = child;

			float distance = transform.position.z - Camera.main.transform.position.z;
			Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
			Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
			minX = leftMost.x;
			maxX = rightMost.x;
		}
	}

	public void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {
		float rightEdgeOfFormation = transform.position.x + (width/2);
		float leftEdgeOfFormation = transform.position.x - (width/2);

		if(moveRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
			if(rightEdgeOfFormation >= maxX) {
				moveRight = false;
			}
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
			if(leftEdgeOfFormation <= minX) {
					moveRight = true;
				}
		}

	}
}
