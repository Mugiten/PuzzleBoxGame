using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPaused;
    public GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
        isPaused = false; 
    }

    // Update is called once per frame
    void Update()
    {
        changePause();
    }

    void changePause() {
        if (Input.GetButtonDown("Pause")) {
            isPaused = !isPaused;
            if (isPaused) {
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else {
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    public void Resume() {
        isPaused = !isPaused;
    }
}
