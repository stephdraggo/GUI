using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GUI1
{
    [AddComponentMenu("GUI/Load Level Async")]
    public class LoadLevel : MonoBehaviour
    {
        public GameObject loadingPanel;
        public Image loadingBar;
        public Text loadingText;

        public void LoadSceneAsync(int sceneIndex)
        {
            loadingPanel.SetActive(true);

            StartCoroutine(LoadAsynchronously(sceneIndex));
        }

        IEnumerator LoadAsynchronously(int sceneIndex)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

            while (!operation.isDone)
            {

                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                loadingBar.fillAmount = progress;
                loadingText.text = Mathf.Round(progress * 100).ToString() + "%";

                yield return null;
            }
        }
    }
}