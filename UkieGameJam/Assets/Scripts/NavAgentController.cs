using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentController : MonoBehaviour {

    private Transform target;
    private NavMeshAgent agent;

    GameObject NPCparent;

    public Transform agent_prefab;

    //public bool selected = false;

    public Color base_colour;

    private void Start()
    {
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
    }

    public void Move(Vector3 point)
    {
        //GetComponent<Renderer>().material.color = base_colour;

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

    public void AddParent(GameObject parent)
    {
        NPCparent = parent;
        GetComponent<Renderer>().material.color = base_colour;
    }

    public void Selected(bool selected)
    {
        if(selected)
        {
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
        }
        else
        {
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pleb")
        {
            if (other.GetComponent<Pleb>().selected == true)
            {
                Transform temp = Instantiate(agent_prefab, other.transform.position, Quaternion.identity, NPCparent.transform);
                temp.GetComponent<NavAgentController>().AddParent(NPCparent);
                Destroy(other.gameObject);
            }
        }
    }
}
