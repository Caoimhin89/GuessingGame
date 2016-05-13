using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 5.0f;
	private float minX;
	private float maxX;
	public float padding = 1.0f;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		minX = leftMost.x + padding;
		maxX = rightMost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if(Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		float newX = Mathf.Clamp (transform.position.x, minX, maxX);

		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
