using System;
using UnityEngine;

public class GAMEMANAGER : MonoBehaviour
{
   
    public static GAMEMANAGER Instance {get;private set;}
   

   
    void Awake()
    {
        if (Instance == null)
        {
            Instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
         
    }

    
    void Start()
    {
       
    }


    private int startlevelindex=0;
     public event EventHandler OnGameOver;
     public event EventHandler OnGameLose;

  
    
    public void RestartAllLevel()
    {
            LEVELMANAGER.Instance.LoadLevel(startlevelindex);
            ScoreUI.Instance.ResetScore();
           
            
    }
    public void GameOver()
    {
        OnGameOver?.Invoke(this,EventArgs.Empty);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Gamelose()
    {
        OnGameLose?.Invoke(this,EventArgs.Empty);
    }
  
}
