using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pleb : MonoBehaviour
{
    public bool selected = false;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

    public void Selected(bool b)
    {
        selected = b;

        if (selected)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
