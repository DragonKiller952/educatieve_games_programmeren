using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InfimaGames.LowPolyShooterPack;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    public GameObject tutorial;

    /// <summary>
    /// Closes the Pause menu
    /// </summary>
    public void ContinueGame()
    {
        GameObject player = transform.parent.gameObject;
        player.GetComponent<Character>().FromPause();
    }

    /// <summary>
    /// Opens the Tutorial screen given
    /// </summary>
    public void OpenTutorial()
    {
        tutorial.SetActive(true);
    }

    /// <summary>
    /// Closes the Tutorial screen given
    /// </summary>
    public void CloseTutorial()
    {
        tutorial.SetActive(false);
    }

    /// <summary>
    /// Loads the main menu scene
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }
}
