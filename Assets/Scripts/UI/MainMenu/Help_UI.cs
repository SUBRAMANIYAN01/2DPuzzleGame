using UnityEngine;
using UnityEngine.UI;

public class Help_UI : MonoBehaviour
{
    [SerializeField]private Image Instruction;
    [SerializeField]private Button HelpButton;
    bool _ISHELPRESSED;

    void Start()
    {
        Hide();
        HelpButton.onClick.AddListener(()=>toggleHelp());
    }

    void Hide()
    {
        
            Instruction.enabled=false;
            _ISHELPRESSED=false;
        
    }
    void Show()
    {
        
            Instruction.enabled=true;
            _ISHELPRESSED=true;
        
    }

    void toggleHelp()
    {
        if (!_ISHELPRESSED)
        {
            Show();

        }
        else
        {
            Hide();
        }
    }
}
