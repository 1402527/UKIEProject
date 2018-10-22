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
    public npcState currentState;

    // Use this for initialization
    void Start()
    {
        currentState = npcState.npcUnconverted;

        //Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();

    }

    // Update is called once per frame

    public void Converted()
    {
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);
        currentState = npcState.npcConverted;

    }


}
