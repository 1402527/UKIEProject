using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversionNPC : MonoBehaviour {

    public Renderer rend;

    public enum npcState
    {
        npcUnconverted,
        npcConverted
    }

    public enum npcSelected
    {
        isSelected,
        isUnselected
    }

    public npcState currentState;
    public npcSelected controlState;

    public bool selected = false;

    // Use this for initialization
    void Start()
    {
        currentState = npcState.npcUnconverted;
        controlState = npcSelected.isUnselected;
        //Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();

    }

    public void ToggleSelected()
    {
        selected = !selected;
    }

    private void Update()
    {
        
    }

    // Update is called once per frame

    public void Converted()
    {
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);
        currentState = npcState.npcConverted;

    }


}
