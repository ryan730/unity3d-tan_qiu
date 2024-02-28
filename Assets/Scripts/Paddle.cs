using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	public float xMax;
	public float xMin;
	//滑板移动的速度
	public float speed;

	//小球的预制体
	public GameObject ballPrefab;

	//吃道具的声音
	public AudioSource itemAudio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GM.instance.isPassedLevel){
			return;	
		}
		//获取横向的移动位移  -[-1,1]
		float xx = Input.GetAxisRaw ("Horizontal");
		if (xx != 0) {
			Vector3 pos = transform.position;
			pos.x += xx * Time.deltaTime * speed;
			//限定一个属性在一定的范围内，
			//当pos.x<xMin  pos.x =xMin
			//当pos.x>xMax  pos.x = xMax
			pos.x = Mathf.Clamp (pos.x,xMin,xMax);
			transform.position = pos;
		}
	}

	void OnCollisionEnter(Collision other){
		
		Item item = other.gameObject.GetComponent<Item> ();
		if (item != null) {
			if (GM.instance.isPlaying) {
				if (item.currType == Item.Item_Type.Life) {
					GM.instance.ChangeLives (1);
				} else if (item.currType == Item.Item_Type.Many) {
					for (int i = 0; i < item.manyNum; i++) {
						GameObject ball = Instantiate (ballPrefab);
						Vector3 pos = transform.position;
						pos.y = Ball.RESET_Y;
						ball.transform.position = pos;
						ball.GetComponent<Ball> ().StartMove ();
					}
				}
				itemAudio.Play ();
			}
			Destroy (other.gameObject);
		}




	}
}
