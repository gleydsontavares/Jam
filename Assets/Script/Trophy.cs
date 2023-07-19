using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trophy : MonoBehaviour
{
    public float pauseDuration = 5f;
    public GameObject victoryWindow;
    public string menuSceneName = "Menu";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenVictoryWindow();
        }
    }

    private void OpenVictoryWindow()
    {
        victoryWindow.SetActive(true);
        StartCoroutine(LoadMenuAfterPause());
    }

    private IEnumerator LoadMenuAfterPause()
    {
        yield return new WaitForSeconds(pauseDuration);

        SceneManager.LoadScene(menuSceneName);
    }
}