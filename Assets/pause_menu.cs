using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InfimaGames.LowPolyShooterPack;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    public GameObject tutorial;

    public void ContinueGame()
    {

        Debug.Log("continue game");

        GameObject player = transform.parent.gameObject;
        Debug.Log(player.name);
        player.GetComponent<Character>().FromPause();
    }

    public void OpenTutorial()
    {

        Debug.Log("open tutorial");

        tutorial.SetActive(true);
    }

    public void CloseTutorial()
    {

        Debug.Log("close tutorial");

        tutorial.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }
}
