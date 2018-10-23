using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretEnemyVision : MonoBehaviour
{

    public GameObject enemy;
    Light torch;
    // Use this for initialization
    void Start()
    {
        torch = GetComponent<Light>();
    }

    public void Chasing(State state)
    {
        switch (state)
        {
            case State.SEARCH:
                torch.color = Color.cyan;
                break;
            case State.CHASE:
                torch.color = Color.red;
                break;
            case State.LOOK:
                torch.color = Color.yellow;
                break;
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "NPC")
        {
            RaycastHit hit;

            Vector3 dir = col.transform.position - enemy.GetComponent<SecretEnemyController>().enemy.transform.position;

            if (Physics.Raycast(enemy.GetComponent<SecretEnemyController>().enemy.transform.position, dir * 10.0f, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "NPC")
                {
                    enemy.GetComponent<SecretEnemyController>().TargetSpotted(col.gameObject);
                }

            }
        }
    }
}
