using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilEnemyScript : MonoBehaviour
{

    public GameObject parent;

	// Use this for initialization
	void Start ()
    {
        parent = transform.parent.gameObject;
	}

    public void Captured()
    {
        Debug.Log("fiwogfo");

        if (parent.GetComponent<EnemyController>() != null)
        {
            parent.GetComponent<EnemyController>().Captured();
        }
        else if (parent.GetComponent<SecretEnemyController>() != null)
        {
            parent.GetComponent<SecretEnemyController>().Captured();
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
