using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{

    public float speed = 0.1f;
    public float sight_range = 5.0f;

    Material fog_mat;

	// Use this for initialization
	void Start ()
    {
        fog_mat = GetComponent<Renderer>().material;
        fog_mat.SetFloat("sight_range", sight_range);
    }
	
	// Update is called once per frame
	void Update ()
    {
        fog_mat.SetFloat("time", Time.time * speed);

    }
}
