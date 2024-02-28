using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏管理类
/// </summary>
public class GM : MonoBehaviour {
	public static GM instance;
	//生命数
	public int liveTimes = 5;

	public Text liveText;
	public GameObject winPanel;
	//游戏是否在运行中
	public bool isPlaying = false;

	private bool _isPassedLevel = false;
	public bool isPassedLevel{
		set{ 
			_isPassedLevel = value;
			if (_isPassedLevel) {
				winPanel.SetActive (true);
				Time.timeScale = 0.25f;
				//延时调用一个方法，参数1：方法的名字，参数2：延时的时间
				Invoke ("WinStep2",0.2f);
			}
		}
		get{ 
			return _isPassedLevel;
		}
	}

	void WinStep2(){
		Time.timeScale = 1f;
		isPlaying = false;
	}

	void Awake(){
		instance = this;
	}
	// Use this for initialization
	void Start () {
		//初始化砖块颜色，随机
		Brick[] allBricks = GameObject.FindObjectsOfType<Brick> ();
		foreach (var item in allBricks) {
			if (item.currType == Brick.Brick_Type.NoBreak) {
				continue;
			}
			item.GetComponent<MeshRenderer> ().material.color = Random.ColorHSV ();
		}
	}
	public void GameOver(){
		if (liveTimes == 0) {
			string sceneName = SceneManager.GetActiveScene ().name;
			SceneManager.LoadScene (sceneName);
		}else{
			ChangeLives (-1);		

			//减掉一条命 liveTimes
			isPlaying = false;
		}
	}
	//是否是最后一个球
	public bool IsLastBall{
		get{ 
			Ball[] allBalls = GameObject.FindObjectsOfType<Ball> ();
			return allBalls.Length == 1;
		}
	}
	/// <summary>
	/// 判定是否通关
	/// </summary>
	public void CheckLevelPassed(){
		Brick[] allBricks = GameObject.FindObjectsOfType<Brick> ();
		bool tempPassedLevel = true;
		foreach (var item in allBricks) {
			if (item.currType == Brick.Brick_Type.NoBreak) {
				continue;
			}
			if (item.enabled == false) {
				continue;
			}
			tempPassedLevel = false;
		}

		isPassedLevel = tempPassedLevel;

	}



	/// <summary>
	/// 生命数发生变化的时候，
	/// 传入的参数是改变多少
	/// </summary>
	/// <param name="step">Step.</param>
	public void ChangeLives(int step){
		liveTimes += step;
		liveText.text = "Live:" + liveTimes;
	}
//	/// <summary>
//	/// 重置小球位置
//	/// </summary>
//	public void ResetBall(){
//		isPlaying = false;
//	}
	// Update is called once per frame
	void Update () {
		if (isPassedLevel) {
			if (Input.GetKeyDown (KeyCode.N)) {
				SceneManager.LoadScene ("Level1");
			}
		}
	}
}
