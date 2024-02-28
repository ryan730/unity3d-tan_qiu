using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	//道具类型
	public enum Item_Type{
		Life,		//生命道具
		Many		//多球道具
	}
	//多球道具生成球的数量
	public int manyNum;
	public Item_Type currType;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
