using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("Playground", LoadSceneMode.Additive);        
    }
}
