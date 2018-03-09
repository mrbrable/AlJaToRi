using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Build : MonoBehaviour {

	public Button[] buildBtn;

	[Header("Building Info")]
		private Buildings buildings;

		Building curBuilding;
		Price price;
		Resources resources;

		int buildingID = 4;

	[Header("GridElement")]
		public GridElement curSelGridElement;
		public GridElement curHovGridElement;
		public GridElement[] grid;	//Alle Gridelemente (Spielfeld)

		private Ray ray;
		private RaycastHit mouseHit;

	[Header("Colors")]
		public Color colOnHover = Color.white;
		public Color colOnOccupied = Color.red;
		private Color colOnNormal;

	public void Awake(){
		colOnNormal = grid[0].GetComponentInChildren<MeshRenderer>().material.color;

		createButton();

		buildings = GetComponent<Buildings>();
		price = GetComponent<Price>();
		resources = GetComponent<Resources>();
	}
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		changeGridColor();
		moveBuilding(buildingID);
	}

	public void changeGridColor(){
		if(Physics.Raycast(ray, out mouseHit)){
			GridElement gridElement = mouseHit.transform.GetComponent<GridElement>();
		
			foreach(GridElement g in grid){
				g.GetComponent<MeshRenderer>().material.color = colOnNormal;

				if(gridElement == g && g.occupied){
					g.GetComponent<MeshRenderer>().material.color = colOnOccupied;
				}else if(gridElement == g){
					g.GetComponent<MeshRenderer>().material.color = colOnHover;
				}
			}

			curHovGridElement = gridElement;
		}
	}

	void createButton(){
		buildBtn[0] = buildBtn[0].GetComponent<Button>();
		buildBtn[0].onClick.AddListener(delegate{ButtonHandler(0);});

		buildBtn[1] = buildBtn[1].GetComponent<Button>();
		buildBtn[1].onClick.AddListener(delegate{ButtonHandler(1);});

		buildBtn[2] = buildBtn[2].GetComponent<Button>();
		buildBtn[2].onClick.AddListener(delegate{ButtonHandler(2);});

		buildBtn[3] = buildBtn[3].GetComponent<Button>();
		buildBtn[3].onClick.AddListener(delegate{ButtonHandler(3);});
	}

	public void ButtonHandler(int id){

		if(price.checkPrice(id)){
			buildingID = id;

			price.payPrice(id);
			
			curBuilding = GetComponent<Building>();
				curBuilding.id = id;
			
			curBuilding.prefab = GetComponent<GameObject>();
				curBuilding.prefab = Instantiate(buildings.buildables[id]);
		}
	}

	public void moveBuilding(int id){	
		if(buildingID < 4){
			curBuilding.prefab.transform.position = mouseHit.point;
			buildBuilding();
		}
	}

	void buildBuilding(){
		if(Input.GetMouseButtonDown(0) && curHovGridElement && !curHovGridElement.occupied){
			curSelGridElement = curHovGridElement;

			curBuilding.prefab.transform.position = curSelGridElement.transform.position;
				curBuilding.connectedGridId = curSelGridElement.gridId;
				curBuilding.placed = true;
			
			curHovGridElement.occupied = true;
			
			buildings.builtObjects.Add(curBuilding);

			price.placed[curBuilding.id]++;
			resources.resourceBuildings[curBuilding.id]++;
			price.refreshPrice();
			
			buildingID = 4;

			curSelGridElement = null;
		}
	}
}
