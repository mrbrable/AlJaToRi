using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour {

	Price price;

	public int[] resourceBuildings;

	[Header("UI Reference")]
		public Text resourcesText;
		
		public double 	wood,
				 		stone,
						food;

	void Awake(){
		initializeVariables();
	}

	void Update () {

		wood += resourceBuildings[0] * Time.deltaTime;
		stone += resourceBuildings[1] * Time.deltaTime;
		food += resourceBuildings[2] * Time.deltaTime;

		SetResourcesText();
	}

	void initializeVariables(){
		price = GetComponent<Price>();

		resourceBuildings = new int[4];

		wood = 100;
		stone = 100;
		food = 100;
	}

	void SetResourcesText(){
		resourcesText.text = "Holz: " + wood.ToString("F1") + " | " 
							+ "Stein: " + stone.ToString("F1") + " | "
							+ "Nahrung: " + food.ToString("F1");
	}
}
