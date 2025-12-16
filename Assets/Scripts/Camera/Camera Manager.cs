using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float referenceAspect = 9f / 16f;   
    public float referenceSize = 5f;         
    
    void Start()
    {
        Camera cam = GetComponent<Camera>();

        float currentAspect = (float)Screen.width / Screen.height;

        // Scaling  camera size based on aspect ratio difference
        float scale = referenceAspect / currentAspect;

        cam.orthographicSize = referenceSize * scale;
    }
}
