using UnityEngine;
using System.Collections;

public class EnemyShipMovementBehaviour : MonoBehaviour {

	public float speed = 10.0f;

	Rigidbody2D body;

	bool isWrappingX = false;
	bool isWrappingY = false;

	float x;
	float y;

	private Renderer objectRenderer;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		objectRenderer = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {

		if (objectRenderer.isVisible && Random.Range (0f, 1000f) < 20f) {

			float slidingX = Random.Range (-1f, 1f);
			float slidingY = Random.Range (-1f, 1f);

			x = 10f * speed * 3f * slidingX;    
			y = 10f * speed * 4f * slidingY;

			body.AddForce(new Vector2(x, y));
		}

		ScreenWrap();
	}

	void ScreenWrap()
	{
		var isVisible = objectRenderer.isVisible;

		if(isVisible)
		{
			isWrappingX = false;
			isWrappingY = false;
			return;
		}

		if(isWrappingX && isWrappingY) {
			return;
		}

		var cam = Camera.main;
		var viewportPosition = cam.WorldToViewportPoint(transform.position);
		var newPosition = transform.position;

		if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
		{
			newPosition.x = -newPosition.x;

			isWrappingX = true;
		}

		if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
		{
			newPosition.y = -newPosition.y;

			isWrappingY = true;
		}

		transform.position = newPosition;
	}
}
