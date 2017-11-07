using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMovement : MonoBehaviour {
    bool placing;
    bool placed;
	// Use this for initialization
	void Start () {
        placing = true;
	}

    // Update is called once per frame
    void Update() {
        if (placing) {
            placed = false;
            ClickingUI.Instance.spawnBuilding.enabled = false;
        Vector3 temp = this.transform.position;
        temp.x = ClickingUI.Instance.placement.x;
        temp.z = ClickingUI.Instance.placement.z;
        temp.y = 0.5f;
            this.transform.position = temp;
        }
       
        if (Input.GetMouseButtonDown(0)&&!placed)
        {
            placing = false;
            ClickingUI.Instance.spawnBuilding.enabled = true;
            ClickingUI.Instance.buildPlace = this.transform.position;
            placed = true;
        }
	}
}
