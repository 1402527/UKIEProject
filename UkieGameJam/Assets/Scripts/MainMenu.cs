using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Image credits;
    bool credits_b = false;

	public void StartButton()
    {
        //SceneManager.LoadScene("level_main");
        Debug.Log("Clisck");
    }

    public void Credits()
    {
        credits_b = !credits_b;
        credits.enabled = credits_b;
    }
}
