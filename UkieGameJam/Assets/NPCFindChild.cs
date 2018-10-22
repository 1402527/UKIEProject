using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFindChild : MonoBehaviour {

    public List<GameObject> totalNPCs;

    // Use this for initializatio

    void Start()
    {

        Transform[] npcChildren = GetComponentsInChildren<Transform>();

        foreach (Transform g in npcChildren)
        {
            if (g.tag == "NPC")
            {
                totalNPCs.Add(g.gameObject);
            }


        }
    }
}
