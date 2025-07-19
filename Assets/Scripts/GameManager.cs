using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    //PickupPanel
    
    public Text timeText;
    public Text crystalText;
    public Text greenKeyText;
    public Text redKeyText;
    public Text goldenKeyText;
    public Image snowflake;

    //inGamePanel
    public Text useInfo;

    //InfoPanel
    public GameObject infoPanel;
    public Text infoText;
    public Text reloadText;

    public int timeToEnd;
    public int points;
    public float speedModifier=1f;

    public int redKey;
    public int greenKey;
    public int goldenKey;

    bool gamePaused = false;
    public bool win = false;

    AudioSource soundSource;

    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip winClip;
    public AudioClip loseClip;

    public MusicManager musicManager;   


    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        InvokeRepeating(nameof(Stopper), 1f, 1f);
        soundSource = GetComponent<AudioSource>();
        musicManager = GetComponentInChildren<MusicManager>();
        infoPanel.SetActive(false);
        snowflake.enabled = false;
        timeText.text = timeToEnd.ToString();
        useInfo.text = "";
        infoText.text = "Pause";
        crystalText.text = points.ToString();
        redKeyText.text = redKey.ToString();
        greenKeyText.text = greenKey.ToString();
        goldenKeyText.text = goldenKey.ToString();
        
    }
    public void AddTime(int time)
    {
        timeToEnd += time;
        timeText.text = timeToEnd.ToString();
        Debug.Log("Time to end: " + timeToEnd + "s");
    }
    public void AddPoints(int point)
    {
        crystalText.text = points.ToString();
        points += point;
        Debug.Log("Points: " + points);
    }

    public void AddKey(KeyType color)
    {
       if(color == KeyType.Red)
        {
            redKey++;
            Debug.Log("Red Key: " + redKey);
        }
        else if (color == KeyType.Green)
        {
            greenKey++;
            Debug.Log("Green Key: " + greenKey);
        }
        else if (color == KeyType.Golden)
        {
            goldenKey++;
            Debug.Log("Golden Key: " + goldenKey);
        }
       greenKeyText.text = greenKey.ToString();
        redKeyText.text = redKey.ToString();
        goldenKeyText.text = goldenKey.ToString();  


    }
    public void FreezeTime(int freeze)
    {
        snowflake.enabled = true;
        CancelInvoke(nameof(Stopper));
        InvokeRepeating(nameof(Stopper), freeze, 1f);   
    }
    public void ResetSpeed()
    {
        speedModifier = 1f;
    }
    public void SetSpeedModifier(float value, int duration)
    {
        speedModifier = value;
        Invoke(nameof(ResetSpeed), duration);
    }
    private void Update()
    {
        PauseCheck();
        ReloadCheck();
    }
    void Stopper()
    {
        
        timeToEnd --;
        timeText.text = timeToEnd.ToString();
        snowflake.enabled = false;
        Debug.Log("Time to end: " + timeToEnd+"s");
        if (timeToEnd <= 0)
        {
            EndGame();
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void EndGame()
    {
        CancelInvoke(nameof(Stopper));
        Time.timeScale = 0f;
        infoPanel.SetActive(true);
        if (win)
        {
            Debug.Log("You Win! Reload?");
            infoText.text = "You Win!";
            reloadText.text = "Reload?";
            PlayAudioClip(winClip);
        }
        else
        {
            Debug.Log("You Lose! Reload?");
            infoText.text = "You Lose!";
            reloadText.text = "Reload?";
            PlayAudioClip(loseClip);
        }
    }
    void ReloadCheck()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }
        void PauseCheck() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        infoPanel.SetActive(true);
        Debug.Log("Game Paused");
        musicManager.OnPauseGame();
        PlayAudioClip(pauseClip);
        gamePaused = true;
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        infoPanel.SetActive(false);
        Debug.Log("Game Resumed");
        musicManager.OnResumeGame();
        PlayAudioClip(resumeClip);
        gamePaused = false;
        Time.timeScale = 1f;
    }
    public void PlayAudioClip(AudioClip _clip)
    {
        soundSource.clip = _clip;
        soundSource.Play();
    }
}
