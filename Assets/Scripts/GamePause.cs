using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class GamePause : MonoBehaviour
{
    [SerializeField]
    private GameObject gamePause;
    public void Quit()
    {
        Time.timeScale = 1f;
        Debug.Log("APPLICATION QUIT!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        gamePause.SetActive(false);
    }
}
