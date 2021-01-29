using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoad : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
