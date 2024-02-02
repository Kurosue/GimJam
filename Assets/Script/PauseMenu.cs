using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject[] objek;
    [SerializeField] objdrag[] Objdrag = new objdrag[4];

    void Awake() {
        for (int i = 0; i < objek.Length; i++){
            Objdrag[i] = objek[i].GetComponent<objdrag>();
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        for (int i = 0; i <objek.Length; i++){
            Objdrag[i].enabled = false;
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        for (int i = 0; i <objek.Length; i++){
            Objdrag[i].enabled = true;
        }
    }
    public void Settings()
    {

    }
    public void Menu()
    {

    }
}
