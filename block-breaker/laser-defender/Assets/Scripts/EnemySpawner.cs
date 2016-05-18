using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float speed = 5.5f;
	public float width = 10.0f;
	public float height = 5.0f;
	public float spawnDelay = 0.5f;
	private float minX;
	private float maxX;
	private bool moveRight;

	// Use this for initialization
	void Start () {
		moveRight = true;
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		minX = leftMost.x;
		maxX = rightMost.x;
		SpawnUntilFull ();
	}

	void SpawnUntilFull() {
		Transform freePosition = NextFreePosition ();
		if(freePosition){
			GameObject enemy = (GameObject)Instantiate(enemyPrefab, freePosition.position, Quaternion.identity);
			enemy.transform.parent = freePosition;
		}
		if(NextFreePosition()){
			Invoke ("SpawnUntilFull", spawnDelay);
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
		if(AllMembersDead()) {
			Debug.Log ("Empty Formation!");
			SpawnUntilFull ();
		}

	}

	Transform NextFreePosition(){
		foreach(Transform childPositionGameObject in transform) {
			if(childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}

	bool AllMembersDead() {
		foreach(Transform childPositionGameObject in transform) {
			if(childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
