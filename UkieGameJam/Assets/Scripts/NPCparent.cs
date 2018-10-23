using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCparent : MonoBehaviour
{

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
                g.gameObject.GetComponent<NavAgentController>().AddParent(this.gameObject);
            }
        }
    }

    public void Remove(GameObject ded)
    {
        totalNPCs.Remove(ded);

    }
}
