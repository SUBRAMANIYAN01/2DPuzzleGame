using UnityEngine;
using UnityEngine.UI;

public class GameOver_UI : MonoBehaviour
{
    [SerializeField]private GameObject GameOverUI;
    [SerializeField]private Button RestartAllButton;
    [SerializeField]private Button QuitButton;

    void Start()
    {
        Hide();
        RestartAllButton.onClick.AddListener(()=>Restartlevel());
        QuitButton.onClick.AddListener(()=>GAMEMANAGER.Instance.QuitGame());
        GAMEMANAGER.Instance.OnGameOver+=GAMEMANAGER_Gameover;
    }

    void Restartlevel()
    {
        Hide();
        GAMEMANAGER.Instance.RestartAllLevel();

    }
    void Hide()
    {
        GameOverUI.SetActive(false);

    }
    void Show()
    {
        GameOverUI.SetActive(true);
    }
    void GAMEMANAGER_Gameover(object sender,System.EventArgs e)
    {
        Show();
    }
}
