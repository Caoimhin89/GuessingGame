using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float health = 300f;
	public float speed = 5.0f;
	private float minX;
	private float maxX;
	public float padding = 1.0f;
	public GameObject projectile;
	public float projectileSpeed;
	public float rateOfFire = 0.2f;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		minX = leftMost.x + padding;
		maxX = rightMost.x - padding;
	}

	void Fire() {
		GameObject beam = (GameObject) Instantiate(projectile, transform.position, Quaternion.identity);
		beam.rigidbody2D.velocity = new Vector3(0, projectileSpeed, 0);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Projectile enemyLaser = collider.gameObject.GetComponent<Projectile>();
		if(collider.gameObject.GetComponent<Projectile>().CompareTag("EnemyLaser")) {
			print ("Ouch!!");
			health -= enemyLaser.GetDamage();
			enemyLaser.Hit();
			if(health <= 0) {
				Destroy (gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Fire", 0.000001f, rateOfFire);
		}
		if(Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");
		}
		if(Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if(Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		float newX = Mathf.Clamp (transform.position.x, minX, maxX);

		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
