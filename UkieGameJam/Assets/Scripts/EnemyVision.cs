using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{

    public GameObject enemy;
    public Transform infront;

	// Use this for initialization
	void Start ()
    {
        
	}
    
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "NPC")
        {
            RaycastHit hit;

            Vector3 dir = col.transform.position - enemy.GetComponent<EnemyController>().enemy.transform.position;

            if (Physics.Raycast(enemy.GetComponent<EnemyController>().enemy.transform.position, dir * 10.0f, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "NPC")
                {
                    enemy.GetComponent<EnemyController>().TargetSpotted(col.gameObject);
                }

            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
