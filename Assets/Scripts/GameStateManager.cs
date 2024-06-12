using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [Tooltip("Our current Scrolls")]
    [SerializeField]
    int CurrentScrolls = 0;

    [Tooltip("How many attemps the player have")]
    [SerializeField]
    int Lives;

    [Tooltip("Reference to the playyer controller")]
    [SerializeField]
    PlayerCntrl player;

    private static GameStateManager instance;

    public static GameStateManager Instance
    {
        get { return instance; }
    }
    public int GetLives()
    {
        return Lives;
    }
    public int GetCurrentScrolls()
    {
        return CurrentScrolls;
    }
   
    void Start()
    {
        CurrentScrolls = 0;
        PlayerPrefs.SetInt("TotalScrolls", 0);
        if (instance != null)
        {
            //destroy the duplicate.
            GameObject.Destroy(this.gameObject);
        }
        else
        {

            instance = this;
            //make sire we ersist between levels
            DontDestroyOnLoad(this.gameObject);
        }
        if (player == null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");
            if (temp != null)
            {
                //if we have an object tagged player get that reference!
                player = temp.GetComponent<PlayerCntrl>();
                if (player == null)
                {
                    Debug.LogWarning("Player is missing playerController");
                }
            }
            else
            {
                Debug.LogWarning("Player is missing!!");
            }
        }
    }
    /// <summary>
    /// Cakked when a player loses or gains lives
    /// </summary>
    /// <param name="deltaChange">change in lives Value</param>
    public void ChangeLives(int deltaChange)
    {
        Lives += deltaChange;

    }
    public void OnDeath()
    {
        ChangeLives(-1);

        if (Lives < 0)
        {
            //Game Over!
            Debug.Log("No more lives'");
            Lives = 3;
            CurrentScrolls = 0;
            SceneManager.LoadScene("GameOver");
        }
    }
    internal void ChangeScrolls(int ScrollValue)
    {
        CurrentScrolls += ScrollValue;
        PlayerPrefs.SetInt("TotalScrolls", CurrentScrolls);
    }
    internal void LevelWON()
    {
        CurrentScrolls = 0;
        Lives = 3;
        SceneManager.LoadScene("Congo");
    }
}
