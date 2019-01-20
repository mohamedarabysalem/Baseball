using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float hitDistance = 0.5f;
	public int deflectedBaseballs = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GvrViewer.Instance.Triggered || Input.GetKeyDown("space")) {
			RaycastHit hit;

			if (Physics.Raycast(transform.position, transform.forward, out hit)) {
				if (hit.transform.tag == "Baseball") {
					Baseball baseball = hit.transform.GetComponent<Baseball> ();

					if (baseball.transform.position.z - transform.position.z < hitDistance) {
						bool deflected = baseball.Deflect ();

						if (deflected) {
							deflectedBaseballs++;
						}
					}
				}
			}
		}
	}
}
