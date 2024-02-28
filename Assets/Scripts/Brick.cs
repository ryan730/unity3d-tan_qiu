using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	//砖块的类型
	public enum Brick_Type
	{
		Normal,  //普通类型
		NoBreak,		//不能被打破的
		Prop_Life,		//生命道具
		Prop_Many		//多球道具
	}
	//道具预制体
	public GameObject itemPrefab;
	public Brick_Type currType;

	//打到砖块的声音
	public AudioSource brickAudio;
	//击中砖块的时候的特效
	public GameObject brickParticlePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//当发生碰撞的时候，销毁自己
	void OnCollisionEnter(Collision other){	
		if (currType == Brick_Type.NoBreak) {
			return;
		} else if (currType == Brick_Type.Prop_Life || currType == Brick_Type.Prop_Many) {
			GameObject item = Instantiate (itemPrefab);
			Vector3 pos = transform.position;
			pos.z -= 0.5f;
			item.transform.position = pos;
		}
		GameObject particle = Instantiate (brickParticlePrefab);
		Vector3 pos1 = transform.position;
		pos1.z -= 0.4f;
		particle.transform.position = pos1;
		brickAudio.Play ();
		this.enabled = false;
		GM.instance.CheckLevelPassed ();
		Destroy (gameObject);
	}
}
