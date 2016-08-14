using UnityEngine;
using System.Collections;

public class DestroyShipOffScreen : MonoBehaviour {

	public float delay = 0.0f;
	private float timeSinceCreation = 0.0f;
	private Renderer objectRenderer;

	// Use this for initialization
	void Start () {
		objectRenderer = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {
		timeSinceCreation += Time.deltaTime;
		//Debug.Log(objectRenderer.isVisible);
		Debug.Log("Destroy = " + timeSinceCreation);
		//Debug.Log(delay);

		if (timeSinceCreation >= delay && !objectRenderer.isVisible) {
			Destroy(gameObject);
			timeSinceCreation = 0f;
		}
	}
}