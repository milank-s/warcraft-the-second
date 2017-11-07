using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpencersnavAgent : MonoBehaviour {

	//Player controlled unit moves to where mouse is clicked
	
	UnityEngine.AI.NavMeshAgent agent;
    public bool chosen;
    public bool canMove;
	void Start ()
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        canMove = false;
	}

	void Update () 
	{
        if (ClickingUI.Instance.buildPlace == Vector3.zero||!chosen)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (canMove)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 100))
                    {

                        agent.SetDestination(hit.point);


                    }
                }
            }
        }
        else
        {
            agent.SetDestination(ClickingUI.Instance.buildPlace);
            Debug.Log((Mathf.Abs(this.transform.position.magnitude - ClickingUI.Instance.buildPlace.magnitude)));
            if (Mathf.Abs(this.transform.position.magnitude- ClickingUI.Instance.buildPlace.magnitude)<1)
            {
                Debug.Log("MADE IT");
                ClickingUI.Instance.buildPlace = Vector3.zero;
                chosen = false;
            }
        }
        }
}
