using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public CanvasGroup faderCanvasGroup;
	public float fadeDuration = 1f;
	public string startingSceneName = "Menu_Main";

	private bool isFading;

	private IEnumerator Start()
	{
		faderCanvasGroup.alpha = 1f;

		yield return StartCoroutine (LoadSceneAndSetActive(startingSceneName));

		StartCoroutine (Fade(0));
	}

	public void FadeAndLoadScene (string sceneName)
	{
		if(!isFading)
		{
			StartCoroutine(FadeAndSwitchScenes(sceneName));
		}
	}

	private IEnumerator FadeAndSwitchScenes (string sceneName)
	{
		yield return StartCoroutine(Fade(1f));

		yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

		yield return StartCoroutine (LoadSceneAndSetActive(sceneName));

		yield return StartCoroutine(Fade(0f));
	}

	private IEnumerator LoadSceneAndSetActive (string sceneName)
	{
		yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

		Scene newlyLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
		SceneManager.SetActiveScene(newlyLoadedScene);
	}

	private IEnumerator Fade (float finalAplha)
	{
		isFading = true;
		faderCanvasGroup.blocksRaycasts = true;

		float fadeSpeed = Mathf.Abs(faderCanvasGroup.alpha - finalAplha) / fadeDuration;

		while (!Mathf.Approximately(faderCanvasGroup.alpha, finalAplha))
		{
			faderCanvasGroup.alpha = 
				Mathf.MoveTowards(faderCanvasGroup.alpha, finalAplha, fadeSpeed * Time.deltaTime);
			yield return null;
		}

		isFading = false;
		faderCanvasGroup.blocksRaycasts = false;
	}
}
