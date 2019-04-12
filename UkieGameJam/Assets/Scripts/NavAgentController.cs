using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentController : MonoBehaviour
{

    private Transform target;
    private NavMeshAgent agent;

    public GameObject this_parent;

    public Transform agent_prefab;

    LineRenderer line;

    public Transform min, max;

    //public bool selected = false;

    public Color base_colour;

    private void Start()
    {
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.grey);
        line = GetComponent<LineRenderer>();
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

            line.positionCount = path.corners.Length;

            line.SetPositions(path.corners);
        }
    }

    public void AddParent(GameObject parent)
    {
        this_parent = parent;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.grey);
    }

    public void Selected(bool selected)
    {
        if(selected)
        {
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
        }
        else
        {
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.grey);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pleb")
        {
            if (other.GetComponent<Pleb>().selected == true)
            {
                other.GetComponent<Pleb>().Convert();
                //Transform temp = Instantiate(agent_prefab, other.transform.position, Quaternion.identity, NPCparent.transform);
                //temp.GetComponent<NavAgentController>().AddParent(NPCparent);
                //Destroy(other.gameObject);
            }
        }
        else if(other.tag == "Enemy")
        {
            Debug.Log("lol");

            if (other.gameObject.GetComponent<LilEnemyScript>() != null)
            {
                other.gameObject.GetComponent<LilEnemyScript>().Captured();
            }

            this_parent.SendMessage("Remove", this.gameObject);
            Destroy(this.gameObject);
        }

    }

    private void Update()
    {
        //if(agent.remainingDistance < 0.1f)
        //{
       //     line.positionCount = 0;
        //}

        //Vector3 pos = new Vector3((transform.position.x - min.position.x) / (max.position.x - min.position.x), 0.0f, (transform.position.z - min.position.z) / (max.position.z - min.position.z));
        //Debug.Log(pos);

    }
}
