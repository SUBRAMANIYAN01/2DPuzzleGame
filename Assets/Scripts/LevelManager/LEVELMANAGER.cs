using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class LEVELMANAGER : MonoBehaviour
{
   public static LEVELMANAGER Instance{get;private set;}
   public event EventHandler OnleveCompleted;

    
    

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
    public int TotalLevel=5;
     private int currentLevelIndex = 0;
     public LEVELS_SO[] levels;
    [SerializeField]private TextMeshProUGUI CurrentLevelUI;
   
    

    void Start()
    {
        LoadLevel(0);
        
    }
    public void LoadLevel(int CurrentLevel)
    {
       
        if (CurrentLevel > levels.Length-1)
        {
            GAMEMANAGER.Instance.GameOver();
            return;

        }
        currentLevelIndex=CurrentLevel;
        GRIDMANAGER.Instance.currentLevel=levels[currentLevelIndex];
        GRIDMANAGER.Instance.Generatetiles();
        CurrentLevelUI.text = "LEVEL " + (currentLevelIndex + 1);

    }
    public void LevelCompleted()
    {
    OnleveCompleted?.Invoke(this,EventArgs.Empty);
       
       
    }
    public void Loadnextlevel()
    {
        LoadLevel(currentLevelIndex+1);
    }
    public void RestartLevel()
    {
        
        LoadLevel(currentLevelIndex); 
    }


}
