using UnityEngine;

public class UIAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        LEVELMANAGER.Instance.OnleveCompleted+=LEVELMANAGER_OnleveCompleted;
    }

    void LEVELMANAGER_OnleveCompleted(object sender,System.EventArgs e)
    {
        PlayAnimation();
    }
    public void PlayAnimation()
    {
        animator.SetTrigger("Play");
    }

      public void OnTransitionFinished()
    {
        LEVELMANAGER.Instance.Loadnextlevel();
    }
}
