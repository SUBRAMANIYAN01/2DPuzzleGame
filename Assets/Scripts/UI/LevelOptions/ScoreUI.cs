using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUI : MonoBehaviour
{

    public static ScoreUI Instance {get;private set;}
    [SerializeField]private TextMeshProUGUI Scoretext;

    private int ScoreNumber=0;

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
        UpdateUI();
    }
 public void AddScore(int amount = 1)
    {
        ScoreNumber += amount;
        UpdateUI();
    }

    // Called on restart / new level
    public void ResetScore()
    {
        ScoreNumber = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (Scoretext != null)
        {

            Scoretext.text = $"SCORE : {ScoreNumber}";

            }
    }
}
