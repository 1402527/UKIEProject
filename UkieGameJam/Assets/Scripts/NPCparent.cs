using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCparent : MonoBehaviour
{
    public List<GameObject> totalNPCs;
    public List<GameObject> lamps;
    List<float> pos_x;
    List<float> pos_z;

    public GameObject fog;
    Material fog_mat;

    public Transform fog_plane_zero;
    public Transform fog_plane_one;

    Vector3 max;
    Vector3 min;

    

    // Use this for initializatio
    void Start()
    {
        fog_mat = fog.GetComponent<Renderer>().material;

        min = fog_plane_zero.position;
        max = fog_plane_one.position;

        Transform[] npcChildren = GetComponentsInChildren<Transform>();

        foreach (Transform g in npcChildren)
        {
            if (g.tag == "NPC")
            {
                totalNPCs.Add(g.gameObject);
                g.gameObject.GetComponent<NavAgentController>().AddParent(this.gameObject);
            }
        }

        pos_x = new List<float>();
        pos_z = new List<float>();

        UpdateShaderArrays();

        Debug.Log(pos_x.Count);

        fog_mat.SetInt("pos_count", pos_x.Count);

    }

    public void Remove(GameObject ded)
    {
        totalNPCs.Remove(ded);
        if(totalNPCs.Count == 0)
        {
            Debug.Log("You Lose");
            SceneManager.LoadScene(0);
        }
    }

    void UpdateShaderArrays()
    {
        pos_x.Clear();
        pos_z.Clear();

        foreach (GameObject g in totalNPCs)
        {
            Vector3 pos = new Vector3((g.transform.position.x - min.x) / (max.x - min.x), 0.0f, (g.transform.position.z - min.z) / (max.z - min.z));

            pos_x.Add(pos.x);
            pos_z.Add(pos.z);
        }

        foreach (GameObject g in lamps)
        {
            Vector3 pos = new Vector3((g.transform.position.x - min.x) / (max.x - min.x), 0.0f, (g.transform.position.z - min.z) / (max.z - min.z));

            pos_x.Add(pos.x);
            pos_z.Add(pos.z);
        }

        fog_mat.SetFloatArray("pos_x", pos_x);
        fog_mat.SetFloatArray("pos_z", pos_z);
       
    }

    public void Update()
    {

        UpdateShaderArrays();

    }
}
