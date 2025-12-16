using UnityEngine;
using UnityEngine.UI;

public class Options_UI : MonoBehaviour
{
    [SerializeField]private GameObject Pause_UI;
    [SerializeField]private Button PauseButton;
    [SerializeField]private Button RetryButton;
     [SerializeField]private Button RestartButton;
    [SerializeField]private Button QuitButton;
    bool _ISPAUSED;

    void Start()
    {
        Hide();
        PauseButton.onClick.AddListener(()=>checkPause());
        RestartButton.onClick.AddListener(()=>Resetalllevel());
        RetryButton.onClick.AddListener(()=>Resetlevel());
        QuitButton.onClick.AddListener(()=>QuitLevel());
    }



    void checkPause()
    {
        if (!_ISPAUSED)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    void Resetlevel()
    {
        Hide();
        LEVELMANAGER.Instance.RestartLevel();
        ScoreUI.Instance.ResetScore();
        
    }
    void Resetalllevel()
    {
        Hide();
        ScoreUI.Instance.ResetScore();
        GAMEMANAGER.Instance.RestartAllLevel();

    }


    void QuitLevel()
    {
        GAMEMANAGER.Instance.QuitGame();
    }

    void Hide()
    {
        
        Pause_UI.SetActive(false);
        _ISPAUSED=false;
    }
    void Show()
    {
        
        Pause_UI.SetActive(true);
        _ISPAUSED=true;
        

    }
}
