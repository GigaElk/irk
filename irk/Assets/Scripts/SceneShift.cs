using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneShift : MonoBehaviour
{
    public string SwitchTo = "";
    public LoadSceneMode mode = LoadSceneMode.Single;

    public void LoadScene()
    {
        SceneManager.LoadScene(SwitchTo, mode);
    }
}
