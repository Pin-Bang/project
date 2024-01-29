using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    private static string initScene = "Init";
    private static string[] levelScenes = {
        "Level01",
        "Level01B",
        "Level02",
        "Level02B",
        "Level03",
        "Level03B"
    };

    public static void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void JumpToSceneByName(string sceneName)
    {
        Debug.Log($"Jump To Scene {sceneName}");
        SceneManager.LoadScene(sceneName);
    }

    public static void JumpToSceneById(int sceneId)
    {
        string sceneName = sceneId == 0 ? initScene : levelScenes[sceneId - 1];
        Debug.Log($"Jump To Scene {sceneId}-{sceneName}");
        SceneManager.LoadScene(sceneName);
    }

    public static void JumpToRandomLevel()
    {
        int levelId = Random.Range(1, levelScenes.Length + 1);
        JumpToSceneById(levelId);
    }

    public static void JumpToInitScene()
    {
        SceneManager.LoadScene(initScene);
    }

}
