using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//public enum State { SEARCH, CHASE, LOST, BACK, LOOK };

public class SecretEnemyController : MonoBehaviour
{

    public State current_state;

    public GameObject enemy;
    public GameObject enemy_parent;

    Transform target;

    public List<Vector3> patrol_positions;
    int current_position;

    NavMeshAgent agent;

    public float reverse_chance = 0.5f;
    bool reversed = false;

    public float look_around_chance = 0.5f;

    public float turn_speed = 5.0f;
    public float speed;

    public Light spotlight;
    public BoxCollider currentCollider;
    public Renderer capsule;
    public Material surprise;
    float duration = 50.0f;
    bool playerSeen = true;
    Vector3 newSize;
    Vector3 newCenter;


    // Use this for initialization
    void Start()
    {
        current_position = 0;

        current_state = State.SEARCH;

        Transform[] children = GetComponentsInChildren<Transform>();

        foreach (Transform t in children)
        {
            if (t.tag == "Route")
            {
                patrol_positions.Add(t.position);
            }
            else if (t.tag == "Enemy")
            {
                enemy = t.gameObject;
            }
            else if (t.tag == "EnemyParent")
            {
                enemy_parent = t.gameObject;
            }
        }

        agent = enemy.GetComponent<NavMeshAgent>();

        agent.speed = speed;

        agent.destination = patrol_positions[current_position];

        spotlight = enemy_parent.GetComponent<Light>();

        capsule = enemy.GetComponent<MeshRenderer>();

        currentCollider = enemy_parent.GetComponent<BoxCollider>();

        newSize = new Vector3(5.0f, 1.0f, 50.0f);
        newCenter = new Vector3(0.0f, 0.0f,25.0f);
    }

    IEnumerator LookAround()
    {
        current_state = State.LOOK;
        float vel = agent.speed;

        agent.speed = 0.0f;

        yield return new WaitForSeconds(4.0f);

        agent.speed = speed;

        //if(current_state == State.CHASE)
        //{
        //    agent.destination = patrol_positions[current_position];
        //    current_state = State.SEARCH;

        //    Debug.Log(agent.remainingDistance);
        //}

        current_state = State.SEARCH;

        yield return null;
    }
    void NextPosition()
    {
        if (Random.Range(0.0f, 1.0f) < reverse_chance)
        {
            reversed = !reversed;
        }

        if (reversed)
        {
            current_position--;
            if (current_position < 0)
            {
                current_position = patrol_positions.Count - 1;
            }
        }
        else
        {
            current_position++;
            if (current_position >= patrol_positions.Count)
            {
                current_position = 0;
            }
        }

        enemy.GetComponent<NavMeshAgent>().destination = patrol_positions[current_position];

        if (Random.Range(0.0f, 1.0f) <= look_around_chance)
        {
            StartCoroutine(LookAround());
            //current_state = State.LOOK;
        }
    }

    public void TargetSpotted(GameObject target_loc)
    {
        Debug.Log("Enemy Spotted");
        spotlight.enabled = true;
        //capsule.material = surprise;

        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        capsule.material.Lerp(capsule.material, surprise, lerp);

        if (playerSeen == true)
        {
            StartCoroutine(revealWait(target_loc));
        }
        else
        {
            target = target_loc.transform;

            current_state = State.CHASE;
            agent.destination = target.position;
            enemy.transform.LookAt(target);
        }
        //anim.enabled = false;

       
    }

    // Update is called once per frame
    void Update()
    {
        enemy_parent.GetComponent<EnemyVision>().Chasing(current_state);
        switch (current_state)
        {
            case State.SEARCH:
                if (agent.remainingDistance < 0.2f)
                {
                    NextPosition();
                }
                break;
            case State.CHASE:
                if (agent.remainingDistance < 0.2f)
                {
                    StartCoroutine(LookAround());
                    playerSeen = false;
                    //current_state = State.LOOK;
                }
                break;
            case State.LOOK:
                enemy.transform.Rotate(Vector3.up * Time.deltaTime * 90.0f, Space.World);

                break;
            case State.BACK:
                break;

        }

    }

    public void Captured()
    {
        StartCoroutine(LookAround());
    }

    IEnumerator revealWait(GameObject target_loc)
    {
        print(Time.time);
        agent.speed = 0.0f;
        currentCollider.size = newSize;
        currentCollider.center = newCenter;

        yield return new WaitForSeconds(1);

        playerSeen = false;

        agent.speed = 3.5f;

        target = target_loc.transform;

        current_state = State.CHASE;
        agent.destination = target.position;
        enemy.transform.LookAt(target);
      

        print(Time.time);
    }
}