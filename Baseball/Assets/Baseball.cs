using UnityEngine;
using System.Collections;

public class Baseball : MonoBehaviour {

	public float speed = 10.5f;
	public Vector3 direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += speed * direction * Time.deltaTime;
	}

	public bool Deflect () {
		if (direction.z < 0) {
			direction = new Vector3 (direction.x, direction.y, -direction.z);
			return true;
		} else {
			return false;
		}
	}
}
