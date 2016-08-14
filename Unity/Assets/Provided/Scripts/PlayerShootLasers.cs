using UnityEngine;
using System.Collections;

public class PlayerShootLasers : MonoBehaviour {

    public Transform shot;
    public float energyCostPerShot = 10.0f;
    public float energyPerSecond = 20.0f;

    private Transform leftGun;
    private Transform rightGun;
    private float energy = 0.0f;


	public float speed = 10.0f;

	void Start () {
        leftGun = transform.FindChild("LeftGun");
        rightGun = transform.FindChild("RightGun");
        energy = energyCostPerShot;
	}
	
	void Update () {
	    if (energy < energyCostPerShot) {
            energy += Time.deltaTime * energyPerSecond;
            return;
        }

        if (Input.GetButton("Fire1")) {
            energy -= energyCostPerShot;

			Transform bolt1 = Instantiate(shot, leftGun.position, Quaternion.identity) as Transform;
			Transform bolt2 = Instantiate(shot, rightGun.position, Quaternion.identity) as Transform;
			bolt1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speed * 3f));
			bolt2.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speed * 3f));
        }

		if (Input.GetButton("Fire1")) {

		}
    }
}
