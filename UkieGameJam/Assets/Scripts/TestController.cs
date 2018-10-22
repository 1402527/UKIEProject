using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

    public List<GameObject> convertedNpcList;

    GameObject selectedNPC;
    GameObject selectedPleb;

    // Update is called once per frame
    void Update()
    {
        ConvertNPC();
    }

    void Deselect()
    {
        if (selectedNPC != null)
        {
            selectedNPC.GetComponent<NavAgentController>().Selected(false);
        }
        selectedNPC = null;
    }

    void DeselectPleb()
    {
        if (selectedPleb != null)
        {
            selectedPleb.GetComponent<Pleb>().Selected(false);
        }
        selectedPleb = null;
    }

    public void ConvertNPC()
    {
        RaycastHit hit = new RaycastHit();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.tag == "NPC")
            {
                Deselect();
                DeselectPleb();
                selectedNPC = hit.collider.gameObject;
                selectedNPC.GetComponent<NavAgentController>().Selected(true);
            }
            else if(hit.collider.gameObject.tag == "Pleb")
            {
                DeselectPleb();
                
                if (selectedNPC != null)
                {
                    selectedPleb = hit.collider.gameObject;
                    hit.collider.gameObject.GetComponent<Pleb>().Selected(true);
                    selectedNPC.GetComponent<NavAgentController>().Move(hit.point);
                    //Deselect();
                }
            }
            else if (hit.collider.gameObject.tag != "NonClickable" && selectedNPC != null)
            {
                selectedNPC.GetComponent<NavAgentController>().Move(hit.point);
                //Deselect();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Deselect();
        }
    }
}
