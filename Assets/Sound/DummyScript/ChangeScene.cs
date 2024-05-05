using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadOtherScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
