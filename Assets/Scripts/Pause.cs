using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject gamePause;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        gamePause.SetActive(true);
    }
}
