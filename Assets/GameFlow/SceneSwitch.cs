using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public void Switch(int sceneID)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneID);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
