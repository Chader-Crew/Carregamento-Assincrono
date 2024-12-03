using System.Collections;
using UnityEngine;

public class ResourceLoader : MonoBehaviour
{
    public string resourceName;
    private GameObject loadedResource;

    public void LoadResourceAsync()
    {
        StartCoroutine(LoadResourceCoroutine());
    }

    private IEnumerator LoadResourceCoroutine()
    {
        ResourceRequest request = Resources.LoadAsync<GameObject>(resourceName);
        yield return request;

        if (request.asset != null)
        {
            loadedResource = Instantiate(request.asset as GameObject);
            Debug.Log($"{resourceName} carregou");
        }
        else
        {
            Debug.LogError($"Falha ao carregar: {resourceName}");
        }
    }
}