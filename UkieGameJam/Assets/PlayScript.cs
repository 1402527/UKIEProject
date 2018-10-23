using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayScript : MonoBehaviour {

    public Button thisButton;
    public GameObject nextTutorial;
    void Start()
    {
        Button btn = thisButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("button pressed");
        nextTutorial.SetActive(true);
    }

}
