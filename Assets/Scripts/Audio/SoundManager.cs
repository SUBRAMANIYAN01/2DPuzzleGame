using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance{get;private set;}
    public SoundClips_SO soundClips_SO;
   
    private void Awake()
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
        TrayManager.Instance.OnSelected+=TrayManager_OnSelected;
        TrayManager.Instance.OnitemsMatched+=TrayManager_onitemMatched;
    }

    void TrayManager_OnSelected(object sender,System.EventArgs e)
    {
        playsound(soundClips_SO.SelectSound,transform.position);
    }
    void TrayManager_onitemMatched(object sender, System.EventArgs e)
    {
        playsound(soundClips_SO.MatchSound,transform.position);
    }

    private float sfxVolume = 1f;
    private void playsound(AudioClip audioClip, Vector3 position, float volumemultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumemultiplier * sfxVolume);
    }
}
