using UnityEngine;
using System.Collections;

public class EnemyFigher : MonoBehaviour {
	public float health = 200f;
	public GameObject projectile;
	public float projectileSpeed = 10.0f;
	public float rateOfFire = 0.2f;
	public float fire;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Projectile beam = collider.gameObject.GetComponent<Projectile>();
		if(collider.gameObject.GetComponent<Projectile>().CompareTag("PlayerLaser")) {
			health -= beam.GetDamage ();
			beam.Hit ();
			if(health <= 0) {
				Destroy (gameObject);
			}
			print ("ZAAAAP!!");
		}
	}

	void Attack() {
		GameObject beam = (GameObject) Instantiate(projectile, transform.position, Quaternion.identity);
		beam.rigidbody2D.velocity = new Vector3(0, -projectileSpeed, 0);
	}
	// Update is called once per frame
	void Update () {
		fire = Random.Range(0, 100);
		if(fire <= 2) {
			Attack ();
		}
	}
}
