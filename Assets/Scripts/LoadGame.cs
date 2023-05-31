using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private void OnEnable()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Playground", LoadSceneMode.Single); // This is necessary so we don't have two main cameras, which messes up the interaction script
    }
}
