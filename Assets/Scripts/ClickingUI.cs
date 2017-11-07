using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickingUI : MonoBehaviour {
    public static ClickingUI Instance = new ClickingUI();
    public MeshRenderer mostRecent;
    public MeshRenderer wireframe;
    public GameObject previousObject;
    public GameObject builderUnit;
    public Vector3 placement;
    public GameObject building;
    public GameObject unit;
    public Canvas spawnUnit;
    public Canvas spawnBuilding;
    public bool isClickingButton;
    public Vector3 buildPlace = Vector3.zero;
    public int uiMode; //0=none, 1=buildings, 2=units
	// Use this for initialization
	void Start () {
        Instance = this;
        uiMode = 0;
	}
	
	// Update is called once per frame
	void Update () {

       // Debug.Log(uiMode);

        Ray placementRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        float rayDist = 10000f;

        Debug.DrawRay(placementRay.origin, placementRay.direction, Color.yellow);


        RaycastHit placementRayHit = new RaycastHit();

        if (!isClickingButton)
        {
            if (Physics.Raycast(placementRay, out placementRayHit, rayDist))
            {
                if (placementRayHit.transform.name == "Ground")
                {
                    placement = placementRayHit.point;
                }



            }
            if (Input.GetMouseButtonDown(0))
            {
                Ray shootRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                float maxRayDist = 10000f;

                Debug.DrawRay(shootRay.origin, shootRay.direction, Color.yellow);

               

                RaycastHit shootRayHit = new RaycastHit();

                if (Physics.Raycast(shootRay, out shootRayHit, maxRayDist))
                {
                    if (shootRayHit.transform.gameObject != previousObject)
                    {
                        if (previousObject!=null&&previousObject.tag == "Unit")
                        {
                            SpencersnavAgent unitMove = previousObject.GetComponent<SpencersnavAgent>();
                            unitMove.canMove = false;
                        }
                    }
                        //   Debug.Log("Is Not A Button");
                        if (shootRayHit.transform.childCount > 0)
                        {
                            wireframe = shootRayHit.transform.GetChild(0).GetComponentInChildren<MeshRenderer>();
                        }
                        if (shootRayHit.transform.childCount == 0)
                        {
                            wireframe = shootRayHit.transform.GetComponent<MeshRenderer>();
                        }
                        if (previousObject != null)
                        {
                            if (previousObject.transform.childCount > 0)
                            {
                                if (previousObject.transform.GetChild(0).name == "Wireframe")
                                {
                                    if (wireframe != mostRecent && mostRecent != null)
                                    {

                                        mostRecent.enabled = false;
                                        uiMode = 0;

                                    }
                                }
                            }
                        }
                        mostRecent = wireframe;
                        previousObject = shootRayHit.transform.gameObject;
                        if (shootRayHit.transform.childCount > 0)
                        {
                            if (shootRayHit.transform.GetChild(0).name == "Wireframe")
                            {
                                wireframe.enabled = true;
                                if (shootRayHit.transform.tag == "Building")
                                {
                                  
                                    uiMode = 1;
                                }
                                if (shootRayHit.transform.tag == "Unit")
                                {
                                 
                                    uiMode = 2;
                                }
                            }
                        }

                    }
                
            }
        }
        //UIMODES
        if (uiMode == 0)
        {
            if (spawnUnit.enabled == true)
            {
                spawnUnit.enabled = false;
            }
            if (spawnBuilding.enabled == true)
            {
                spawnBuilding.enabled = false;
            }
            
        }
        if (uiMode == 1)
        {
            if (buildPlace != Vector3.zero)
            {
                SpencersnavAgent unitMove = builderUnit.GetComponent<SpencersnavAgent>();
                unitMove.chosen = true;
            }
                spawnBuilding.enabled = false;
                spawnUnit.enabled = true;
            
            if (Input.GetKeyDown(KeyCode.U))
            {
               
                //spawnUnit.interactable = true;
                CreateUnit(previousObject);
                
            }
        }
        if (uiMode == 2)
        {
            if (spawnBuilding.enabled == false)
            {
                spawnBuilding.enabled = true;
            }
            spawnUnit.enabled = false;
            SpencersnavAgent unitMove = previousObject.GetComponent<SpencersnavAgent>();
            unitMove.canMove = true;
            builderUnit = previousObject;
            if (Input.GetKeyDown(KeyCode.B))
            {
                CreateBuilding();
            }
        }
    }
    public void CreateUnit(GameObject currentlySelected)
    {
        Vector2 unitPlacement2D = Random.insideUnitCircle.normalized;
        Vector3 unitPlacement3D = new Vector3(unitPlacement2D.x, 0.0f, unitPlacement2D.y) * 1.5f;
        GameObject madeUnit = Instantiate(unit, currentlySelected.transform.position + unitPlacement3D, Quaternion.identity);
        Vector3 temp = madeUnit.transform.position;
        temp.y = 0.5f;
        madeUnit.transform.position = temp;
    }
    public void CreateBuilding()
    {
        Instantiate(building, placement, Quaternion.identity);
    }

   
}
