using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour {




	void OnTriggerEnter(Collider other){

	      if (other.gameObject.CompareTag("Target")){
	         Destroy(other.gameObject);

	      }

	      Destroy(gameObject);

	}

}
