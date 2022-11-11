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
        //Keep updating the score on the screen while it is not shown
        Score.text = "Score: " + transform.parent.GetComponent<Character>().GetScoreCurrent();
    }

    /// <summary>
    /// Opens the scene containing the main menu
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }

    /// <summary>
    /// Restarts the game by opening the game scene with a loading bar
    /// </summary>
    public void RestartGame()
    {
        StartCoroutine(StartGameAsynchronously("Main_scene"));
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
