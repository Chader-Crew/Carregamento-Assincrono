using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public static SceneLoader Instance;
    public GameObject loadingScreen; // Tela ou barra de carregamento
    public UnityEngine.UI.Slider progressBar;
    public GameObject[] easterEggs;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadAsync(sceneName));
    }

    private IEnumerator LoadAsync(string sceneName)
    {
        loadingScreen.SetActive(true);
        var operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progress;

            if (operation.progress >= 0.9f)
            {
                // Libera a cena ao pressionar uma tecla ou automaticamente após certo tempo
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

        StartCoroutine(LoadEasterEggs());

        loadingScreen.SetActive(false);
    }

    private IEnumerator LoadEasterEggs()
    {
        foreach (var egg in easterEggs)
        {
            yield return new WaitForSeconds(0.5f); // Simula o carregamento
            Instantiate(egg);
            Debug.Log($"{egg.name} carregado como easter egg.");
        }
    }
}

