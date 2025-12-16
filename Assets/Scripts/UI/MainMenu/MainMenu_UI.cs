using UnityEngine;
using UnityEngine.UI;

public class MainMenu_UI : MonoBehaviour
{
    [SerializeField]private Button StartButton;
    [SerializeField]private Button QuitButton;

    void Start()
    {
        StartButton.onClick.AddListener(()=>{
          Loading.Load(Loading.Scene.GameScene); 
        });

        QuitButton.onClick.AddListener(() =>
        {
           Application.Quit(); 
        });
    }
}
