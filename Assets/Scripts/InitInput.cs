using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitInput : MonoBehaviour
{
    public static bool showIntro = true;
    public GameObject intro;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            App.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if(showIntro)
            {
                intro.SetActive(true);
                showIntro = false;
            }
            else
            {
                SceneController.JumpToRandomLevel();
            }
        }
    }
}
