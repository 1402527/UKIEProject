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

    GameObject plebParent;

    bool convert = false;
    bool bored = false;

    public float boredom_wait = 5.0f;
    public float boredom_time = 10.0f;
    public Vector3 sphere_size = new Vector3(12.0f, 1.0f, 12.0f);

    float t = 0.0f;

    // Use this for initialization
    void Start ()
    {
        plebParent = transform.parent.gameObject;

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
                sphere.transform.localScale = Vector3.zero;
            }
            
        }

        agent = GetComponent<NavMeshAgent>();
        agent.destination = patrol_positions[current_position];

        speed = Random.Range(2.0f, 5.0f);

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
        if (!convert)
        {
            sphere.transform.localScale = sphere_size;
            Selected(false);
            plebParent.SendMessage("Converted");
            convert = true;
            GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(Timer());
        }
    }

    public void Selected(bool b)
    {
        selected = b;

        if (selected && !convert)
        {
            GetComponent<Renderer>().material.color = Color.blue;
            agent.speed = 0.0f;
        }
        else
        {
            if (convert)
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.black;
            }
            agent.speed = speed;
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(boredom_wait);

        t = 0.0f;

        convert = false;

        plebParent.SendMessage("Remove");
        GetComponent<Renderer>().material.color = Color.black;

        while (t <= 1.1f && convert == false)
        {
            sphere.transform.localScale = Vector3.Lerp(sphere_size, Vector3.zero, t);

            t += Time.deltaTime / boredom_time;

            yield return null;
        }

        

        yield return null;
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
