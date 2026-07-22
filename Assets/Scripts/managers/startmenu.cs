using UnityEngine;
using UnityEngine.SceneManagement;
public class startmenu : MonoBehaviour
{
    private const string Scene = "gamescene";

    public void scenechange()
    {
        SceneManager.LoadScene(Scene);
    }

    public void quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
