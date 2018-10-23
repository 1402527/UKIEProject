using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class backButton : MonoBehaviour {
    public Button thisButton;
    public GameObject thisScreen;

    void Start()
    {
        Button btn = thisButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("button pressed");
        thisScreen.SetActive(false);
    }

}
