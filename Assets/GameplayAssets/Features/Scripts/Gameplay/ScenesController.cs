using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EmptyTheGarage.Feature.Gameplay
{
    public class ScenesController : MonoBehaviour
    {
        [SerializeField]
        protected GameObject loadingUi = default;
        [SerializeField]
        protected Slider progressBar = default;

        protected Coroutine loadSceneCoroutine = default;

        public virtual void LoadSceneByName(ScenesInGame scene)
        {
            loadSceneCoroutine = StartCoroutine(LoadScene((int)scene));
        }

        private IEnumerator LoadScene(int sceneName)
        {
            Debug.Log("Loading...");
            loadingUi.SetActive(true);
            AsyncOperation loadConcreteSceen = SceneManager.LoadSceneAsync(sceneName);
            loadConcreteSceen.allowSceneActivation = false;

            while (!loadConcreteSceen.isDone && isActiveAndEnabled)
            {
                progressBar.value = loadConcreteSceen.progress;

                if (loadConcreteSceen.progress == 0.9f) loadConcreteSceen.allowSceneActivation = true;

                yield return null;
            }
            loadingUi.SetActive(false);

        }

        protected virtual void OnDestroy() => loadSceneCoroutine = null;
    }
}