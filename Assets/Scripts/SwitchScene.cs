using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public string SwitchTo = "Main";

    public void onButtonClick()
    {
        SceneManager.LoadScene(SwitchTo);
    }
}