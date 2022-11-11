using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InfimaGames.LowPolyShooterPack;
using UnityEngine.SceneManagement;
using TMPro;

public class game_over_menu : MonoBehaviour
{ 
    public GameObject Loading;
    public Slider loadingBar;
    public TextMeshProUGUI Score;

    public void Update()
    {
        Score.text = "Score: " + transform.parent.GetComponent<Character>().GetScoreCurrent();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }

    // Start is called before the first frame update
    public void RestartGame()
    {
        StartCoroutine(StartGameAsynchronously("Main_scene"));
        //SceneManager.LoadScene("Main_scene");
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
