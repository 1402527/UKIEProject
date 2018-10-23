using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pleb : MonoBehaviour
{
    public bool selected = false;

    public List<Vector3> patrol_positions;

    int current_position;

    NavMeshAgent agent;

    public float speed;

    GameObject sphere;

    // Use this for initialization
    void Start ()
    {
        GetComponent<Renderer>().material.color = Color.black;

        current_position = 0;

        Transform[] children = GetComponentsInChildren<Transform>();

        foreach (Transform t in children)
        {
            if (t.tag == "Route")
            {
                patrol_positions.Add(t.position);
                Destroy(t.gameObject);
            }
            else if(t.tag == "PlebSphere")
            {
                sphere = t.gameObject;
                sphere.SetActive(false);
            }
            
        }

        agent = GetComponent<NavMeshAgent>();
        agent.destination = patrol_positions[current_position];
        agent.speed = speed;
    }

    void NextPosition()
    {  
        current_position++;
        if (current_position >= patrol_positions.Count)
        {
            current_position = 0;
        }
       
        GetComponent<NavMeshAgent>().destination = patrol_positions[current_position];
    }

    public void Convert()
    {
        sphere.SetActive(true);
    }

    public void Selected(bool b)
    {
        selected = b;

        if (selected)
        {
            GetComponent<Renderer>().material.color = Color.blue;
            agent.speed = 0.0f;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.black;
            agent.speed = speed;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (agent.remainingDistance < 0.2f)
        {
            NextPosition();
        }
    }
}
