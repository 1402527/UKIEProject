using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlebParent : MonoBehaviour {

    public List<GameObject> totalPlebs;

    public int pleb_count = 0;
    public int converted_count = 0;

    public int converted_target = 5;

    // Use this for initializatio
    void Start()
    {
        Transform[] npcChildren = GetComponentsInChildren<Transform>();

        foreach (Transform g in npcChildren)
        {
            if (g.tag == "Pleb")
            {
                totalPlebs.Add(g.gameObject);
                pleb_count++;
            }
        }
    }

    void Converted()
    {
        converted_count++;

        if(converted_count >= converted_target)
        {
            Debug.Log("WIN");
        }

    }

    public void Remove()
    {
        converted_count--;
        if(converted_count < 0)
        {
            converted_count = 0;
        }
    }
}
