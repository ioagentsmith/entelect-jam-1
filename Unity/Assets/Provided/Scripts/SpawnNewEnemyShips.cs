using UnityEngine;
using System.Collections;

public class SpawnNewEnemyShips : MonoBehaviour {

	public Transform enemyShip;
	public float delay = 0.0f;

	private float timeElapsed = 0.0f;

	BoxCollider2D boxCollider;
	float negX;
	float posX;
	float negY;
	float posY;

	Vector2 size;
	Vector3 centerPoint;
	Vector3 worldPos;

	float top;
	float btm;
	float left;
	float right;

	Vector3 topLeft;
	Vector3 topRight;
	Vector3 btmLeft;
	Vector3 btmRight;

	// Use this for initialization
	void Start () {
		Debug.Log("Building spawner");
		boxCollider = GetComponent<BoxCollider2D>();	

		size = boxCollider.size;
		centerPoint = new Vector3( boxCollider.offset.x, boxCollider.offset.y, 0f);
		worldPos = transform.TransformPoint ( boxCollider.offset );

		top = worldPos.y + (size.y / 2f);
		btm = worldPos.y - (size.y / 2f);
		left = worldPos.x - (size.x / 2f);
		right = worldPos.x + (size.x /2f);

		topLeft = new Vector2( left, top);
		topRight = new Vector2( right, top);
		btmLeft = new Vector2( left, btm);
		btmRight = new Vector2( right, btm); 

		Debug.Log("Spawner built");
	}
	
	// Update is called once per frame
	void Update() {
		timeElapsed += Time.deltaTime;
		Debug.Log ("Spawn = " + timeElapsed);

		if (timeElapsed >= delay) {
			Debug.Log ("Trying to spawn new enemy ships");
			int enemyCount = GameObject.FindGameObjectsWithTag ("Enemy").Length;
			Debug.Log ("enemyCount " + enemyCount);
			if (enemyCount < 1) {
				for (int i = 0; i < 10; i++) {
					float newXPos = Random.Range (left, right);
					float newYPos = Random.Range (top, btm);
					Instantiate (enemyShip, new Vector2 (newXPos, newYPos), Quaternion.identity);
				}
			}

			timeElapsed = 0f;
		}
	}
}
