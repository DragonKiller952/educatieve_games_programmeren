using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Tutorial;
    public GameObject Loading;
    public Slider loadingBar;
    // Start is called before the first frame update
    public void StartGame()
    {
        StartCoroutine(StartGameAsynchronously("Main_scene"));
        //SceneManager.LoadScene("Main_scene");
    }
    public void OpenTutorial()
    {
        Tutorial.SetActive(true);
    }

    public void CloseTutorial()
    {
        Tutorial.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator StartGameAsynchronously(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        Loading.SetActive(true);
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }
    }
}
