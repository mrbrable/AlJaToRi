using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
	
	public int id;
	public int level = 1;
	public float yRot = 0;
	public int connectedGridId;
	public bool placed = false;

	public GameObject prefab;

	public void UpgradeBuilding(){
		//TODO Upgrade Building
	}
}
