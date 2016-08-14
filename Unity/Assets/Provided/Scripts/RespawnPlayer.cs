using UnityEngine;
using System.Collections;

public class RespawnPlayer : MonoBehaviour {

	public Transform player;
	public float delay = 0.0f;

	private float timeElapsed = 0.0f;

	BoxCollider2D boxCollider;

	Vector2 size;
	Vector2 centerPoint;
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
		Debug.Log("Building player spawner");
		boxCollider = GetComponent<BoxCollider2D>();	

		size = boxCollider.size;
		centerPoint = new Vector2( boxCollider.offset.x, boxCollider.offset.y);
		worldPos = transform.TransformPoint ( boxCollider.offset );

		top = worldPos.y + (size.y / 2f);
		btm = worldPos.y - (size.y / 2f);
		left = worldPos.x - (size.x / 2f);
		right = worldPos.x + (size.x /2f);

		topLeft = new Vector2( left, top);
		topRight = new Vector2( right, top);
		btmLeft = new Vector2( left, btm);
		btmRight = new Vector2( right, btm); 

		Debug.Log("Player Spawner built");
	}

	// Update is called once per frame
	void Update() {
		timeElapsed += Time.deltaTime;
		Debug.Log ("Spawn = " + timeElapsed);

		if (timeElapsed >= delay) {
			Debug.Log ("Trying to spawn new player ships");
			int playerCount = GameObject.FindGameObjectsWithTag ("Player").Length;
			Debug.Log ("playerCount " + playerCount);
			if (playerCount < 1) {
				float newXPos = Random.Range (left, right);
				float newYPos = Random.Range (top, btm);
				Instantiate (player, new Vector2 (newXPos, newYPos), Quaternion.identity);
			}

			timeElapsed = 0f;
		}
	}
}
