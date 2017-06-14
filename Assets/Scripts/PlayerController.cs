using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour {

	private Transform player;
	private Rigidbody2D rigidBody;
	private Transform camera;
	public float maxSpeed;

	// Use this for initialization
	void Start () {
		player = GetComponent<Transform> ();
		rigidBody = GetComponent<Rigidbody2D> ();
		camera = Camera.main.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		// change this to cross-platform input
		/*if (Input.GetKey (KeyCode.W)) {
			float x, y;
			y = 12.5f * Time.deltaTime * Mathf.Sin (player.rotation.eulerAngles.z * Mathf.Deg2Rad);
			x = 12.5f * Time.deltaTime * Mathf.Cos (player.rotation.eulerAngles.z * Mathf.Deg2Rad);
			Vector3 move = new Vector3 (x, y, 0);

			player.Translate (move, Space.World);
			Camera.main.transform.Translate (move, Space.World);
		}*/

		/*float x, y;
		y = (CrossPlatformInputManager.GetAxis ("move_v") * maxSpeed * Time.deltaTime);// * Mathf.Sin (player.rotation.eulerAngles.z * Mathf.Deg2Rad);
		x = (CrossPlatformInputManager.GetAxis ("move_h") * maxSpeed * Time.deltaTime);// * Mathf.Cos (player.rotation.eulerAngles.z * Mathf.Deg2Rad);
		Vector3 move = new Vector3 (x, y, 0);

		player.Translate (move, Space.World);*/
		//Camera.main.transform.Translate (move, Space.World);

		// change this to cross-platform input
		/*if (Input.GetKey (KeyCode.Q)) {
			player.Rotate (new Vector3 (0, 0, 180f * Time.deltaTime), Space.Self);
		} else if (Input.GetKey (KeyCode.E)) {
			player.Rotate (new Vector3 (0, 0, -180f * Time.deltaTime), Space.Self);
		}*/

		float xAim, yAim;
		xAim = CrossPlatformInputManager.GetAxis ("aim_h");
		yAim = CrossPlatformInputManager.GetAxis ("aim_v");

		if (xAim != 0 && yAim != 0) {
			Vector3 pos = new Vector3 (player.position.x + xAim, player.position.y + yAim, 0);
			//zRot = Mathf.Atan (yAim / xAim) * Mathf.Rad2Deg;
			//player.rotation = Quaternion.Euler (new Vector3 (0, 0, zRot - 90));
			player.right = pos - player.position;
		}
	}

	void FixedUpdate() {
		
		float x, y;
		y = (CrossPlatformInputManager.GetAxis ("move_v") * maxSpeed);//* Time.fixedDeltaTime);
		x = (CrossPlatformInputManager.GetAxis ("move_h") * maxSpeed);// * Time.fixedDeltaTime);
		Vector2 move = new Vector3 (x, y);

		//player.Translate (move, Space.World);
		rigidBody.velocity = Vector2.ClampMagnitude(move, maxSpeed);
		camera.position = new Vector3 (player.position.x, player.position.y, -10);
	}
}
