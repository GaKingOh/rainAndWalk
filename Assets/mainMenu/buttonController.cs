using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonController : MonoBehaviour
{
    // Start is called before the first frame update
     public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
