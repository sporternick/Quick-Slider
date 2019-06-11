using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void ResetGame()
    {
        SceneManager.LoadScene("main menu");
    }
}
