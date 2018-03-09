using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour {
	public List<GameObject> buildables = new List<GameObject>();
	public List<Building> builtObjects = new List<Building>();

	public int stoneBuilding = 0,
		woodBuilding = 0,
		foodBuilding = 0;
}
