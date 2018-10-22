using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickOn : MonoBehaviour {
    [SerializeField]
    private Material grey;

    [SerializeField]
    private Material red;

    private MeshRenderer myRend;

    [HideInInspector]
    public bool currentlySelected = false;


    // Use this for initialization
    void Start () {
        myRend = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	public void ClickMe() {
        
        if(currentlySelected == false)
        {
            myRend.material = grey;
            //GetComponent<NavAgentController>().enabled = false;
            GetComponent<NavMeshAgent>().speed = 0.0f;
        }
        else
        {
            myRend.material = red;
           // GetComponent<NavAgentController>().enabled = true;
            GetComponent<NavMeshAgent>().speed = 3.5f;
        }
	}
}
