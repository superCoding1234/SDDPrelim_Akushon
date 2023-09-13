using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Slider loadingBar;
    [SerializeField] private TextMeshProUGUI tipDisplay;
    [SerializeField] private string[] tips;
    public void StartPressed()
    {
        StartCoroutine(AsyncLoadScene());
    }

    public void QuitPressed()
    {
        Application.Quit();
    }

    private IEnumerator AsyncLoadScene()
    {
        tipDisplay.text = tips[Random.Range(0, tips.Length)];
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        operation.allowSceneActivation = false;
        while (operation.progress < 0.9f)
        {
            loadingBar.value = operation.progress/0.9f;
            
            yield return null;
        }
        FindFirstObjectByType<AudioManager>().Stop("MainMenuMusic");
        FindFirstObjectByType<AudioManager>().Play("CharacterSelectionMusic");
        operation.allowSceneActivation = true;
    }
}