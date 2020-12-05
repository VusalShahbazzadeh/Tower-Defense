using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    //Made for buttons
    public void LoadScene(int index) => SceneManager.LoadScene(index);

    public void Quit() => Application.Quit();
}
