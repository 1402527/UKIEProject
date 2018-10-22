using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
        else
        {
            myRend.material = red;
        }
	}
}
