using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject[] objek;
    [SerializeField] objdrag[] Objdrag = new objdrag[4];
    public bool _pause = false;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        _pause = true;

    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        _pause = false;

    }
    public void Settings()
    {

    }
    public void Menu()
    {

    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
}
