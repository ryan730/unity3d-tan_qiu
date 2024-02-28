using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody rb;
	//球的速度
	public float speed;

	public Transform paddle;

	public const float RESET_Y = -5F;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
		paddle = GameObject.FindObjectOfType<Paddle> ().transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GM.instance.isPlaying) {
			Vector3 pos = transform.position;
			pos.x = paddle.position.x;
			pos.y = RESET_Y;
			transform.position = pos;
		}
		if (GM.instance.isPassedLevel) {
			return;
		}
		//当摁下鼠标左键的时候，让球飞出去
//		if (Input.GetMouseButtonDown (0) && !GM.instance.isPlaying) {
		if (Input.GetKeyDown(KeyCode.Space) && !GM.instance.isPlaying) {			
			GM.instance.isPlaying = true;
			StartMove ();
		}


		//临时测试的挂
		if (Input.GetKey (KeyCode.Keypad0)) {
			Vector3 pos = paddle.position;
			pos.x = transform.position.x;
			paddle.position = pos;
		}

		//查看小球的速度
		Debug.Log ("小球的速度是： "+rb.velocity.magnitude);

	}
	//小球开始移动
	public void StartMove(){
		int angle = GetRandomAngle ();
		Vector3 speedNormalized = new Vector3 (1f, Mathf.Tan(angle * Mathf.Deg2Rad), 0).normalized;
		rb.velocity = speedNormalized * speed;
	}
	//随机产生一个角度
	int GetRandomAngle(){
		int angle = Random.Range (10,170);
		if (angle > 80 && angle < 100) {
			angle = GetRandomAngle ();
		}
		return angle;
	}
	/// <summary>
	/// 碰撞结束以后，速度大小重置，
	/// 对方向进行约束，解决角度过大过小引起游戏死循环的Bug
	/// </summary>
	/// <param name="other">Other.</param>
	void OnCollisionExit(Collision other){
		if (GM.instance.isPlaying) {
			Vector3 sp = rb.velocity.normalized;
			float angle = Mathf.Asin (sp.y / 1) * Mathf.Rad2Deg;

			//角度是正的的情况，角度过小
			if (angle >= 0 && angle < 10) {
				//第一象限
				if (sp.x > 0) {
					float yy = Mathf.Tan (10 * Mathf.Deg2Rad);
					Vector3 newVelocity = new Vector3 (1f, yy, 0).normalized;
					sp = newVelocity;
				} else {  //第二象限
					float yy = Mathf.Tan (10 * Mathf.Deg2Rad);
					Vector3 newVelocity = new Vector3 (-1f, yy, 0).normalized;
					sp = newVelocity;
				}
			} else if (angle > 80 && angle <= 90) {//角度是正的的情况，角度过大
				//第一象限
				if (sp.x > 0) {
					float yy = Mathf.Tan (80 * Mathf.Deg2Rad);
					Vector3 newVelocity = new Vector3 (1f, yy, 0).normalized;
					sp = newVelocity;
				} else {  //第二象限
					float yy = Mathf.Tan (80 * Mathf.Deg2Rad);
					Vector3 newVelocity = new Vector3 (-1f, yy, 0).normalized;
					sp = newVelocity;
				}
			}else if (angle <= 0 && angle > -10) {//角度是负的的情况，角度过小
				//第四象限
				if (sp.x > 0) {
					float yy = Mathf.Tan (-10 * Mathf.Deg2Rad);
					Vector3 newVelocity = new Vector3 (1f, yy, 0).normalized;
					sp = newVelocity;
				} else {  //第三象限
					float yy = Mathf.Tan (-10 * Mathf.Deg2Rad);
					Vector3 newVelocity = new Vector3 (-1f, yy, 0).normalized;
					sp = newVelocity;
				}
			} else if (angle < -80 && angle >= -90) {//角度是负的的情况，角度过大
				//第四象限
				if (sp.x > 0) {
					float yy = Mathf.Tan (-80 * Mathf.Deg2Rad);
					Vector3 newVelocity = new Vector3 (1f, yy, 0).normalized;
					sp = newVelocity;
				} else {  //第三象限
					float yy = Mathf.Tan (-80 * Mathf.Deg2Rad);
					Vector3 newVelocity = new Vector3 (-1f, yy, 0).normalized;
					sp = newVelocity;
				}
			}

			//a* b = |a|*|b|*Cos(M)

			rb.velocity = sp * speed;
		}
	}

}
