using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public string tutorial;
    public string Menu;
    public GameObject pauseUI;
    private bool isPaused = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartTutorial()
    {
        // Reiniciar a cena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void MenuStart()
    {
        SceneManager.LoadScene(Menu);
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0f; // Pausa o tempo do jogo
        isPaused = true;
        pauseUI.SetActive(true); // Ativa a interface de pausa ou menu de pausa
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Retoma o tempo do jogo
        isPaused = false;
        pauseUI.SetActive(false); // Desativa a interface de pausa ou menu de pausa
    }
}
