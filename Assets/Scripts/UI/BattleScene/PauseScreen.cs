using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    private PlayerController1 pc1;
    private PlayerController2 pc2;
    [SerializeField] private GameObject pauseMenu;
    public bool pauseState;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private TextMeshProUGUI tipDisplay;
    [SerializeField] private string[] tips;
    private bool hasUnpaused;

    private void Start()
    {
        pc1 = FindAnyObjectByType<PlayerController1>();
        pc2 = FindAnyObjectByType<PlayerController2>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) pauseState = !pauseState;
        pauseMenu.SetActive(pauseState);
        if (pauseState)
        {
            hasUnpaused = false;
            pc1.pi1.PlayerMovement.Disable();
            pc1.pi1.Ability.Disable();
            pc2.pi2.PlayerMovement.Disable();
            pc2.pi2.Ability.Disable();
        }
        else if (!(pauseState || hasUnpaused))
        {
            pc1.pi1.PlayerMovement.Enable();
            pc1.pi1.Ability.Enable();
            pc2.pi2.PlayerMovement.Enable();
            pc2.pi2.Ability.Enable();
            hasUnpaused = true;
        }
    }

    public void UnPause()
    {
        pauseState = false;
    }

    public void QuitPressed()
    {
        StartCoroutine(AysncQuitPressed());
    }

    private IEnumerator AysncQuitPressed()
    {
        tipDisplay.text = tips[Random.Range(0, tips.Length)];
        AsyncOperation operation = SceneManager.LoadSceneAsync(0);
        operation.allowSceneActivation = false;
        while (operation.progress < 0.9f)
        {
            loadingBar.value = operation.progress/0.9f;
            
            yield return null;
        }
        FindFirstObjectByType<AudioManager>().Stop("BattleMusic");
        FindFirstObjectByType<AudioManager>().Stop("BattleMusicMix");
        operation.allowSceneActivation = true;
    }
}