using UnityEngine;
using UnityEngine.SceneManagement;

public  static class Loading 
{
    public enum Scene
    {
        GameScene,
        Loadingscene,
        MainMenu
    }
    private static Scene Target;

     public static void Load(Scene TargetScene)
    {
        Loading.Target = TargetScene;
        SceneManager.LoadScene(Scene.Loadingscene.ToString());
    }

    public static void Loadercallback()
    {
        SceneManager.LoadScene(Target.ToString());
    }
}
