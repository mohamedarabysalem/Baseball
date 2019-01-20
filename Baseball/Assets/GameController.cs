using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Player player;
	public GameObject baseballPrefab;
	public TextMesh gameText;
	public float baseballThrowInterval = 1f;
	public float baseballThrowRadius = 1f;

	public float gameTimer = 20f;
	private float gameOverTimer = 3f;

	private float baseballTimer = -3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		baseballTimer += Time.deltaTime;

		if (baseballTimer < 0f) {
			int countdown = Mathf.CeilToInt (-baseballTimer);
			gameText.text = "Get ready!\n" + countdown;
		} else {
			gameTimer -= Time.deltaTime;

			gameText.text = "Game timer: " + Mathf.CeilToInt(gameTimer) + "\nDeflected balls: " + player.deflectedBaseballs;
		}

		if (gameTimer <= 0f) {
			gameText.text = "Game over!\nYour score: " + player.deflectedBaseballs;

			gameOverTimer -= Time.deltaTime;
			if (gameOverTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		}

		if (baseballTimer > baseballThrowInterval && gameTimer > 0f) {
			baseballTimer = 0f;

			GameObject baseballObject = Instantiate (baseballPrefab);
			baseballObject.transform.position = transform.position;

			float randomAngle = Random.Range (0f, 2f * Mathf.PI);

			Vector3 targetPosition = new Vector3 (
				player.transform.position.x + Mathf.Cos(randomAngle) * baseballThrowRadius,
				player.transform.position.y + Mathf.Sin(randomAngle) * baseballThrowRadius,
				player.transform.position.z
			);

			Baseball baseball = baseballObject.GetComponent<Baseball> ();
			baseball.direction = (targetPosition - baseballObject.transform.position).normalized;
		}
	}
}
