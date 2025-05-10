using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int timeToEnd;
    public int points;
    public float speedModifier=1f;

    public int redKey;
    public int greenKey;
    public int goldenKey;

    bool gamePaused = false;
    bool win = false;


    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        InvokeRepeating(nameof(Stopper), 1f, 1f);
    }
    public void AddTime(int time)
    {
        timeToEnd += time;
        Debug.Log("Time to end: " + timeToEnd + "s");
    }
    public void AddPoints(int point)
    {
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

    }
    public void FreezeTime(int freeze)
    {
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
        //Time.timeScale = 0f;
        if (win)
        {
            Debug.Log("You Win! Reload?");
        }
        else
        {
            Debug.Log("You Lose! Reload?");
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
        Debug.Log("Game Paused");
        gamePaused = true;
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        gamePaused = false;
        Time.timeScale = 1f;
    }
}
