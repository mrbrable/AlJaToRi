using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Price : MonoBehaviour {

	public Resources resources;

	public Text[] priceText;

	public int[] wood,
				 stone,
				 food;
	
	public int[] placed;

	void Start () {
		initializeVariables();
	}
	
	void Update () {
	}

	void initializeVariables(){
		resources = GetComponent<Resources>();
		
		wood = new int[4];
		stone = new int[4];
		food = new int[4];

		placed = new int[4];

		for(int i=0; i<4; i++){
			wood[i] = 20;
			stone[i] = 20;
			food[i] = 20;

			placed[i] = 0;
		}
	}

	public void refreshPrice(){
		for(int i=0; i<4; i++){
			wood[i] = 20 * (placed[i] +1);
			stone[i] = 20 * (placed[i] +1);
			food[i] = 20 * (placed[i] +1);
		}

		SetText();
	}

	void SetText(){
		for(int i=0; i<4; i++){
			priceText[i].text = wood[i] + " Ho. | "
							+ stone[i] + " St. | "
							+ food[i] + " Na.";
		}
	}

	public bool checkPrice(int id){
		return wood[id] <= resources.wood
			&& stone[id] <= resources.stone
			&& food[id] <= resources.food;
	}

	public void payPrice(int id){
		resources.wood -= wood[id];
		resources.stone -= stone[id];
		resources.food -= food[id];
	}
}
