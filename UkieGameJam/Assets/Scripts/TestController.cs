using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

    public List<GameObject> convertedNpcList;

    GameObject selectedNPC;

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

    public void ConvertNPC()
    {
        RaycastHit hit = new RaycastHit();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.tag == "NPC")
            {
                Deselect();
                selectedNPC = hit.collider.gameObject;
                selectedNPC.GetComponent<NavAgentController>().Selected(true);


            }
            else if (hit.collider.gameObject.tag != "NonClickable" && selectedNPC != null)
            {
                selectedNPC.GetComponent<NavAgentController>().Move(hit.point);
                Deselect();
            }


            //selectedNPC.GetComponent<ConversionNPC>().

           

            //selectedNPC.GetComponent<ConversionNPC>().controlState = ConversionNPC.npcSelected.isSelected;
            //if (selectedNPC.GetComponent<ConversionNPC>().currentState == ConversionNPC.npcState.npcUnconverted)
            //{
            //    selectedNPC.GetComponent<ConversionNPC>().Converted();
                
            //    convertedNpcList.Add(selectedNPC); 
            //}
            //if (selectedNPC.GetComponent<ConversionNPC>().controlState == ConversionNPC.npcSelected.isSelected)
            //{

            //    selectedNPC.GetComponent<NavAgentController>().enabled = true;
            //}
        }

        

        if (Input.GetMouseButtonDown(1))// && Physics.Raycast(ray, out hit))
        {
            Deselect();

            //selectedNPC.GetComponent<ConversionNPC>().controlState = ConversionNPC.npcSelected.isUnselected;
            //selectedNPC.GetComponent<NavAgentController>().enabled = false;
        }
       

    }

}
