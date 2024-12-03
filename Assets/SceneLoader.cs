using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadScreenOverlay;
    public void LoadScene(string sceneName)
    {
        loadScreenOverlay.SetActive(true);
        SceneManager.LoadSceneAsync(sceneName);
        SceneManager.
    }
}
