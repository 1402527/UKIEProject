using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentController : MonoBehaviour {

    private Transform target;
    private NavMeshAgent agent;

    public bool selected = false;

    public void Move(Vector3 point)
    {
        agent = GetComponent<NavMeshAgent>();
        NavMeshPath path = new NavMeshPath();

        agent.CalculatePath(point, path);

        // Ichecks if the path is reachable
        if (path.status != NavMeshPathStatus.PathPartial)
        {
            // Move agent to position
            GetComponent<NavMeshAgent>().SetDestination(point);
        }
    }

    public void Selected(bool selected)
    {
        if(selected)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

	// Update is called once per frame
	void Update ()
    {
		//if(Input.GetMouseButtonDown(0))
  //      {
  //          agent = GetComponent<NavMeshAgent>();
  //          NavMeshPath path = new NavMeshPath();

  //          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
  //          RaycastHit hitInfo;
            
  //          if (Physics.Raycast(ray, out hitInfo))
  //          {
  //              // Checks if the mouse is clicking on a building or unclickable surface
  //              if (hitInfo.transform.tag != "NonClickable")
  //              {
                    
  //                  agent.CalculatePath(hitInfo.point, path);
                    
  //                  // Ichecks if the path is reachable
  //                  if (path.status != NavMeshPathStatus.PathPartial)
  //                  {
  //                      // Move agent to position
  //                      GetComponent<NavMeshAgent>().SetDestination(hitInfo.point);
  //                  }
  //              }
  //          }
            
  //      }
	}
}
