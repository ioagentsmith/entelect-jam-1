using UnityEngine;
using System.Collections;

public class EnemyBullets : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collider) {
		//if (!collider.gameObject.tag.Equals(this.gameObject.tag)) {
		//	Destroy (collider.gameObject);
		//	Destroy (this.gameObject);
		//}

		if (collider.gameObject.tag.Equals ("Player")) {
			Debug.Log("Kaboom Player!");
			Destroy (collider.gameObject);
			Destroy (this.gameObject);
		}
	}
}
