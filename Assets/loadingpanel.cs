
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider loadingBar;
    public TMP_Text loadingText;

    public void StartLoading()
    {
        loadingPanel.SetActive(true);
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        AsyncOperation operation =
            SceneManager.LoadSceneAsync("gamepllay");

        operation.allowSceneActivation = false;

        while (operation.progress < 0.9f)
        {
            float progress = operation.progress / 0.9f;

            loadingBar.value = progress;
            loadingText.text =
                "Loading... " + Mathf.RoundToInt(progress * 100) + "%";

            yield return null;
        }

        loadingBar.value = 1f;
        loadingText.text = "Loading... 100%";

        yield return new WaitForSeconds(0.5f);

        operation.allowSceneActivation = true;
    }
}

