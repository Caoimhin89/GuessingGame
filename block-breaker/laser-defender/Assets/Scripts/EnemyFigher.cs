using UnityEngine;
using System.Collections;

public class EnemyFigher : MonoBehaviour {
	public float health = 200;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Projectile beam = collider.gameObject.GetComponent<Projectile>();
		if(beam) {
			health -= beam.GetDamage ();
			beam.Hit ();
			if(health <= 0) {
				Destroy (gameObject);
			}
			print ("ZAAAAP!!");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
