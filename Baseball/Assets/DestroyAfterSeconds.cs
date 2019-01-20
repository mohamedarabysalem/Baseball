using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour {

	public float lifetime = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime <= 0f) {
			Destroy (gameObject);
		}
	}
}
