using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReloadScene();
        }
    }
    //Reloads scene for a new match
    private void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
