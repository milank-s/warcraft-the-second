﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

	//it might make sense to make this class static. If the player needs to regularly access its functions/values
	//otherwise looks good
	
	public int gold;
	public int wood;
	public int oil;
	public int food;

	public int foodRate = 1;
	public int totalMen = 5;

//	public float timerCount = 0f;

	// Use this for initialization
	void Start () {

		gold = 800;
		wood = 400;
		oil = 0;
		food = 5;

	//	InvokeRepeating ("addFood", 5, 5);

	}
	
	// Update is called once per frame
	void Update () {

		//timerCount += Time.deltaTime;
		
	}

	public void AddGold (){

		gold += 25;

	}

	public void AddWood (){

		wood += 25;

	}

	public void AddOil (){

		oil += 25;

	}

	public void AddFood (){

		//if (food < totalMen) {
			food += foodRate;
		//}
	}

	public void AddFarm (){

		foodRate += 1;

	}

	public void AddOrc (){

		if (totalMen < food) {
			totalMen += 1;
		}

	}

	public void AddLargerOrc (){

		if ((totalMen + 1) < food) {
			totalMen += 2;
		}

	}

}
