using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string tutorial;

    public GameObject controlPanel;
    public GameObject creditPanel;
    public GameObject playerPanel;
    public GameObject tutorialPanel;
    public GameObject tutorialPanel2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
       SceneManager.LoadScene(tutorial);
        Time.timeScale = 1f;

    }

    public void QuitGame()
    {
        //Editor Unity
        //UnityEditor.EditorApplication.isPlaying = false;
        //Jogo Compilado
        Application.Quit();
    }

    public void ControlPainel()
    {
        controlPanel.SetActive (true);
    }

    public void ControlPainelReturn()
    {
        controlPanel.SetActive (false);
    }

    public void CreditPainel()
    {
        creditPanel.SetActive (true);
    }

    public void CreditPainelReturn()
    {
        creditPanel.SetActive(false);
    }

    public void PlayerPainel()
    {
        tutorialPanel.SetActive(true);
    }

    public void NextTutorial()
    {
        tutorialPanel.SetActive(false);
        tutorialPanel2.SetActive(true);
    }

    public void PlayerPainelReturn()
    {
        playerPanel.SetActive(false);
        tutorialPanel2.SetActive(false);
    }
}
