using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	public GameObject deathParticlePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other){
		//如果道具掉在地上，删掉
		Item item = other.gameObject.GetComponent<Item> ();
		if (item != null) {
			Destroy (other.gameObject);
		} else {
			//是否是最后一个球，是的话，GameOver，否则，直接删掉
			if (GM.instance.IsLastBall) {
				GM.instance.GameOver ();
			} else {
				Destroy (other.gameObject);
			}
			GameObject particle = Instantiate (deathParticlePrefab);
			particle.transform.position = other.transform.position;
		}
	}
}
