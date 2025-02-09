using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace MFarm.Transition 
{
    public class TransitionManaga : MonoBehaviour
    {
        public string startSceneName = string.Empty;

        private void OnEnable()
        {
            EventHandler.TransitionEvent += OnTransitionEvent;
        }

        private void OnDisable()
        {
            EventHandler.TransitionEvent -= OnTransitionEvent;
        }

        private void Start()
        {
            StartCoroutine(LoadSceneSetActive(startSceneName));
        }

        private void OnTransitionEvent(string sceneToGo,Vector3 positionToGo)
        {
            StartCoroutine(Transition(sceneToGo, positionToGo));
        }
        private IEnumerator Transition(string sceneName, Vector3 targetPosition)
        {
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

            yield return LoadSceneSetActive(sceneName);
            EventHandler.CallMoveToPosition(targetPosition);
        }

        private IEnumerator LoadSceneSetActive(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);


            Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);

            SceneManager.SetActiveScene(newScene);
        }
    }
}
