using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {
    

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.transform.name == "Agent")
                {
                    Debug.Log("this is the agent");
                    GetComponent<NavAgentController>().enabled = true;
                }
            }
        }
	}
}
