using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject player;

	void Update() {
		Vector3 pos = player.transform.position;
		pos.x += 3.632f;
		pos.y += 6.85f;
		pos.z += -3.62f;
		transform.position = pos;
	}
}
