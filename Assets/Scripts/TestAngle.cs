using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAngle : MonoBehaviour {
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			rb.velocity = Vector3.zero;
			rb.position = Vector3.zero;
		}
		if (Input.GetKeyDown (KeyCode.Keypad0)) {
			Debug.Log ("右上 第一象限 小角度的情况");
			//一个小角度的单位向量的速度
			rb.velocity = new Vector3 (1f,0.1f,0).normalized;

			//根据反正弦函数，求出角度 
			//弧度角度互换  2PI = 360
			float angle = Mathf.Asin (rb.velocity.y/1) * Mathf.Rad2Deg;

			Debug.Log ("第一象限小角度 ： "+angle);

		}

		if (Input.GetKeyDown (KeyCode.Keypad1)) {
			Debug.Log ("右上 第一象限 大角度的情况");
			//一个小角度的单位向量的速度
			rb.velocity = new Vector3 (0.1f,1f,0).normalized;

			//根据反正弦函数，求出角度 
			//弧度角度互换  2PI = 360
			float angle = Mathf.Asin (rb.velocity.y/1) * Mathf.Rad2Deg;

			Debug.Log ("第一象限大角度 ： "+angle);

		}

		if (Input.GetKeyDown (KeyCode.Keypad2)) {
			Debug.Log ("左上 第二象限 小角度的情况");
			//一个小角度的单位向量的速度
			rb.velocity = new Vector3 (-1f,0.1f,0).normalized;

			//根据反正弦函数，求出角度 
			//弧度角度互换  2PI = 360
			float angle = Mathf.Asin (rb.velocity.y/1) * Mathf.Rad2Deg;

			Debug.Log ("第二象限小角度 ： "+angle);

		}
		if (Input.GetKeyDown (KeyCode.Keypad3)) {
			Debug.Log ("左上 第二象限 大角度的情况");
			//一个小角度的单位向量的速度
			rb.velocity = new Vector3 (-0.1f,1f,0).normalized;

			//根据反正弦函数，求出角度 
			//弧度角度互换  2PI = 360
			float angle = Mathf.Asin (rb.velocity.y/1) * Mathf.Rad2Deg;

			Debug.Log ("第二象限大角度 ： "+angle);

		}
		if (Input.GetKeyDown (KeyCode.Keypad4)) {
			Debug.Log ("左下 第三象限 小角度的情况");
			//一个小角度的单位向量的速度
			rb.velocity = new Vector3 (-1f,-0.1f,0).normalized;

			//根据反正弦函数，求出角度 
			//弧度角度互换  2PI = 360
			float angle = Mathf.Asin (rb.velocity.y/1) * Mathf.Rad2Deg;

			Debug.Log ("第三象限 小角度的情况 ： "+angle);

		}
		if (Input.GetKeyDown (KeyCode.Keypad5)) {
			Debug.Log ("左下 第三象限 大角度的情况");
			//一个小角度的单位向量的速度
			rb.velocity = new Vector3 (-0.1f,-1f,0).normalized;

			//根据反正弦函数，求出角度 
			//弧度角度互换  2PI = 360
			float angle = Mathf.Asin (rb.velocity.y/1) * Mathf.Rad2Deg;

			Debug.Log ("第三象限 大角度的情况 ： "+angle);

		}
		if (Input.GetKeyDown (KeyCode.Keypad6)) {
			Debug.Log ("右下 第四象限 小角度的情况");
			//一个小角度的单位向量的速度
			rb.velocity = new Vector3 (1f,-0.1f,0).normalized;

			//根据反正弦函数，求出角度 
			//弧度角度互换  2PI = 360
			float angle = Mathf.Asin (rb.velocity.y/1) * Mathf.Rad2Deg;

			Debug.Log ("第四象限 小角度的情况 ： "+angle);

		}

		if (Input.GetKeyDown (KeyCode.Keypad7)) {
			Debug.Log ("右下 第四象限 大角度的情况");
			//一个小角度的单位向量的速度
			rb.velocity = new Vector3 (0.1f,-1f,0).normalized;

			//根据反正弦函数，求出角度 
			//弧度角度互换  2PI = 360
			float angle = Mathf.Asin (rb.velocity.y/1) * Mathf.Rad2Deg;

			Debug.Log ("第四象限 大角度的情况 ： "+angle);

		}
	}
}
