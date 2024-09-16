using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public int sceneToLoad; // Укажите имя сцены, на которую нужно перейти

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
