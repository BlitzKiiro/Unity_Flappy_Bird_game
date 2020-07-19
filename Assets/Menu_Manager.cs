using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Click;
    public GameObject menu;
    public GameObject high_score;
    public Text points;

    public void startGame()
    {
        StartCoroutine(co_startGame()); 
        
    }
    public void showScore()
    {
        StartCoroutine(co_showScore());
    }
    IEnumerator co_showScore()
    {
        Click.Play();
        yield return new WaitWhile(() => Click.isPlaying);
        menu.SetActive(false);
        high_score.SetActive(true);
        points.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void backToMenu()
    {
        menu.SetActive(true);
        high_score.SetActive(false);
    }
    IEnumerator co_startGame()
    {
        Click.Play();
        yield return new WaitWhile(() => Click.isPlaying);
        SceneManager.LoadScene(1);
    }
}
