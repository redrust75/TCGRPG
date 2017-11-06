using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    GameObject prefab;
	// Use this for initialization
	void Start () {
		prefab = Resources.Load("projectile") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			GameObject projectile = Instantiate(prefab) as GameObject;
			projectile.transform.position += transform.forward * 2;
			Rigidbody rb = projectile.GetComponent<Rigidbody>();
			rb.velocity = transform.forward * 40;
		}
		
	}
}
