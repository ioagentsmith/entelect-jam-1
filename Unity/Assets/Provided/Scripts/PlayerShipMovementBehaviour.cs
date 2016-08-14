using UnityEngine;
using System.Collections;

public class PlayerShipMovementBehaviour : MonoBehaviour {

    public float speed = 10.0f;

    Rigidbody2D body;

	private Renderer objectRenderer;

	bool isWrappingX = false;
	bool isWrappingY = false;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
		objectRenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal") * speed * 4f;    
		float y = Input.GetAxis ("Vertical") * speed * 3f;

		body.AddForce(new Vector2(x, y));

		ScreenWrap();
	}

	void ScreenWrap()
	{
		var isVisible = objectRenderer.isVisible;

		if (isVisible)
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
