using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

    [SerializeField]
    private LayerMask clickablesLayer;

    public List<GameObject> selectedObjects;

    void Start()
    {
        selectedObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetMouseButtonDown(1))
        {
           // if (selectedObjects.Count > 0)
            //{
                foreach (GameObject obj in selectedObjects)
                {
                    obj.GetComponent<ClickOn>().currentlySelected = false;
                    obj.GetComponent<ClickOn>().ClickMe();
                }
                selectedObjects.Clear();
            //}
        }


		if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, clickablesLayer))
            {
                ClickOn clickOnScript = rayHit.collider.GetComponent<ClickOn>();

                Debug.Log("hello");
                if (selectedObjects.Count > 0)
                {
                    foreach (GameObject obj in selectedObjects)
                    {
                        obj.GetComponent<ClickOn>().currentlySelected = false;
                        obj.GetComponent<ClickOn>().ClickMe();
                    }
                    selectedObjects.Clear();
                }

               
                selectedObjects.Add(rayHit.collider.gameObject);
                clickOnScript.currentlySelected = true;
                clickOnScript.ClickMe();
                

            }
           
            
        }
	}
}
