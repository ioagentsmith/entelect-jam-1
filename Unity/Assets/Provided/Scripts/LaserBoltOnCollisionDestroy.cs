using UnityEngine;
using System.Collections;

public class LaserBoltOnCollisionDestroy : MonoBehaviour {

public AudioClip crashSoft;
    public AudioClip crashHard;

    private AudioSource source;
    private float lowPitchRange = 0.75f;
    private float highPitchRange = 1.5f;
    //private float velToVol = 0.2f;
    //private float velocityClipSplit = 10f;

	void Awake () {
    
        source = GetComponent<AudioSource>();
    }
	
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

		if (collider.gameObject.tag.Equals ("Enemy") || collider.gameObject.tag.Equals ("Bullet")) 
		{
				Debug.Log("Kaboom Enemy or Bullet!");
				Destroy (collider.gameObject);
				Destroy (this.gameObject);
				
				source.pitch = Random.Range (lowPitchRange, highPitchRange);

				if (collider.gameObject.tag.Equals ("Enemy"))
					source.PlayOneShot(crashHard, 10f);
				else 
					source.PlayOneShot(crashSoft, 2f);
		}
    }
}
