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
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            
            yield return null;
        }
    }
}