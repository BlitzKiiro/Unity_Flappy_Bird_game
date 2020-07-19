using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject GameOverCanvas;
    public GameObject PauseResumeCanvas;
    public GameObject pausemenu;
    public GameObject pipespawner;
    public GameObject Bird;
    public AnimationCurve bird_start;
    public GameObject bg_music;
    public AudioSource gmover_music;
    public SpriteRenderer bg_img;
    public GameObject resumebutton;
    public GameObject pausebutton;
    public GameObject ResumeCounter;
    public GameObject tabtoplay;
    public float time_counter;
    private static bool inc ;
    private static bool strt ;
    public Text current_score;
    public Text best_score;
    public SpriteRenderer medal;
    public Sprite gold;
    public Sprite silver;
    public Sprite Bronze;
    public Sprite tin;

    // Start is called before the first frame update
    void Start()
    {
        inc = false;
        strt = false;
        Time.timeScale = 1;
        pipespawner.SetActive(false);
       
    }
    private void Update()
    {
        if ( time_counter > 1) {
            Color tmp = bg_img.color;
            if ( inc )
            {
                tmp.a += 1/60f;
                if (tmp.a == 1) 
                {
                    inc = false;
                }
            }
            else
            {
                tmp.a -= 1/60f;
                if (tmp.a < 0.1 )
                {
                    inc = true;
                }
            }
            bg_img.color = tmp;
            time_counter = 0;
        }
        time_counter += Time.deltaTime;
        if ( strt == false )
        {
            Bird.transform.position = new Vector3(
                Bird.transform.position.x, 
                bird_start.Evaluate((Time.time % bird_start.length)),
                Bird.transform.position.z
                );
            tabtoplay.transform.position = new Vector3(
                tabtoplay.transform.position.x,
                bird_start.Evaluate((Time.time % bird_start.length)),
                tabtoplay.transform.position.z
                );

        }

    }
    public void GameOver()
    {
        GameOverCanvas.SetActive(true);
        PauseResumeCanvas.SetActive(false);
        Time.timeScale = 0;
        bg_music.SetActive(false);
        gmover_music.Play();
        if ( score.points > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score.points);
            PlayerPrefs.Save();
        }
        current_score.text = score.points.ToString();
        best_score.text = PlayerPrefs.GetInt("HighScore").ToString();
        if (score.points < 500) medal.sprite = tin;
        else if (score.points >= 500 && score.points < 1000) medal.sprite = Bronze;
        else if (score.points >= 1000 && score.points < 1500) medal.sprite = silver;
        else if (score.points >= 1000 && score.points < 1500) medal.sprite = silver;
        else if (score.points >= 1500 ) medal.sprite = gold;

    }
    public void Reply()
    {
        strt = false;
        SceneManager.LoadScene(1);
        
    }
    private void OnMouseDown()
    {
        pipespawner.SetActive(true);
        Bird.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        strt = true;
        tabtoplay.SetActive(false);
    }
    public void pause()
    {
        Time.timeScale = 0;
        pausemenu.SetActive(true);
        pausebutton.SetActive(false);
        resumebutton.SetActive(true);

    }
    public void resume()
    {
      
        StartCoroutine(co_resume());
        
    }
    IEnumerator co_resume()
    {
        pausemenu.SetActive(false);
        pausebutton.SetActive(true);
        resumebutton.SetActive(false);
        ResumeCounter.SetActive(true);
        for ( int i = 3; i > 0; i-- )
        {
            ResumeCounter.GetComponent<Text>().text = i.ToString();
            yield return new WaitForSecondsRealtime(0.5f);
        }
        ResumeCounter.SetActive(false);
        Time.timeScale = 1;
    }
    public void goToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
