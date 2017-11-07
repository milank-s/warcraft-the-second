using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
   // public Button button;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      //  Button btn = button.GetComponent<Button>();
      //  btn.onClick.AddListener(TaskOnClick);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        ClickingUI.Instance.isClickingButton = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
       
        ClickingUI.Instance.isClickingButton = false;

    }



   public void CreateUnit()
    {
        ClickingUI.Instance.CreateUnit(ClickingUI.Instance.previousObject);
      //  ClickingUI.Instance.isClickingButton = true;      
    }

    public void CreateBuilding()
    {
        ClickingUI.Instance.CreateBuilding();
    }


}
