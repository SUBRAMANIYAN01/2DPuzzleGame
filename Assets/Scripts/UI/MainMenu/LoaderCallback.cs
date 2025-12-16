using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
 private bool isFristupdate = true;
    private void Update()
    {
        if (isFristupdate)
        {
            isFristupdate = false;
            Loading.Loadercallback();
        }
    }
}
