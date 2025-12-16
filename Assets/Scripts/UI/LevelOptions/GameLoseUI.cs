using UnityEngine;
using UnityEngine.UI;

public class GameLoseUI : MonoBehaviour
{
    [SerializeField]private GameObject GameLose_UI;
    [SerializeField]private Button RestartAllButton;
    [SerializeField]private Button QuitButton;

    void Start()
    {
        Hide();
        RestartAllButton.onClick.AddListener(()=>Restartlevel());
        QuitButton.onClick.AddListener(()=>GAMEMANAGER.Instance.QuitGame());
        GAMEMANAGER.Instance.OnGameLose+=GAMEMANAGER_GameLose;
    }

    void Restartlevel()
    {
        Hide();
        GAMEMANAGER.Instance.RestartAllLevel();

    }
    void Hide()
    {
        GameLose_UI.SetActive(false);

    }
    void Show()
    {
        GameLose_UI.SetActive(true);
    }
    void GAMEMANAGER_GameLose(object sender,System.EventArgs e)
    {
        Show();
    }
}
