using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour {

    public Button thisButton;
    
    void Start()
    {
        Button btn = thisButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("button pressed");
        SceneManager.LoadScene(1);
    }
}
