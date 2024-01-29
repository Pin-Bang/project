using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private PlayerController player1Controller;
    private PlayerController player2Controller;

    private LevelEffect[] player1LevelEffect;
    private LevelEffect[] player2LevelEffect;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Input Manager Enabled");
        player1Controller = player1.GetComponent<PlayerController>();
        player2Controller = player2.GetComponent<PlayerController>();
        player1LevelEffect = player1.GetComponents<LevelEffect>();
        player2LevelEffect = player2.GetComponents<LevelEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        float player1_angular = -Input.GetAxis("p1h");
        float player2_angular = -Input.GetAxis("p2h");

        player1Controller.SetAngularSpeed(player1_angular);
        player2Controller.SetAngularSpeed(player2_angular);

        float player1_value = Input.GetAxis("p1v");
        float player2_value = Input.GetAxis("p2v");

        foreach (var effect in player1LevelEffect)
        {
            effect.SetValue(player1_value);
        }

        foreach (var effect in player2LevelEffect)
        {
            effect.SetValue(player2_value);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            SceneController.JumpToRandomLevel();
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            SceneController.JumpToInitScene();
        }

#if UNITY_EDITOR
        if(Input.GetKey(KeyCode.B))
        {
            SceneController.RestartCurrentScene();
        }
#endif
    }
}
