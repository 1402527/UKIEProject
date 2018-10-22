using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

    public List<GameObject> convertedNpcList;

    // Update is called once per frame
    void Update()
    {
        ConvertNPC();
    }

    public void ConvertNPC()
    {
        RaycastHit hit = new RaycastHit();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "NPC")
        {
            hit.collider.gameObject.GetComponent<ConversionNPC>().controlState = ConversionNPC.npcSelected.isSelected;
            if (hit.collider.gameObject.GetComponent<ConversionNPC>().currentState == ConversionNPC.npcState.npcUnconverted)
            {
                hit.collider.gameObject.GetComponent<ConversionNPC>().Converted();
                
                convertedNpcList.Add(hit.collider.gameObject); 
            }
            
        }

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "NPC" && hit.collider.gameObject.GetComponent<ConversionNPC>().controlState == ConversionNPC.npcSelected.isSelected)
        {
          
            hit.collider.gameObject.GetComponent<NavAgentController>().enabled = true;
        }

        if (Input.GetMouseButtonDown(1) && Physics.Raycast(ray, out hit))
        {
            hit.collider.gameObject.GetComponent<ConversionNPC>().controlState = ConversionNPC.npcSelected.isUnselected;
            hit.collider.gameObject.GetComponent<NavAgentController>().enabled = false;
        }
       

        }

}
