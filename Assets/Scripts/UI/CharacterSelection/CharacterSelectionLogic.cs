using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionLogic : MonoBehaviour
{
    [SerializeField] private GameObject cutsceneBackground, currentBackground, text1, text2, text3, text4;

    private bool trigger;

    private void Update()
    {
        if (PlayerPrefs.HasKey("player1Character") == false || PlayerPrefs.HasKey("player2Character") == false) return;
        if (trigger) return;
        StartCoroutine(StartCutscene());
        trigger = true;
    }

    private IEnumerator StartCutscene()
    {
        FindFirstObjectByType<AudioManager>().Stop("CharacterSelectionMusic");
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        operation.allowSceneActivation = false;
        cutsceneBackground.SetActive(true);
        currentBackground.SetActive(false);
        yield return new WaitUntil(() =>
            !FindFirstObjectByType<AudioManager>().IsPlaying("ViperSuper") &&
            !FindFirstObjectByType<AudioManager>().IsPlaying("SovaSuper") &&
            !FindFirstObjectByType<AudioManager>().IsPlaying("GeckoSuper"));
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        text1.SetActive(true);
        yield return new WaitForSeconds(4f);
        text2.SetActive(true);
        yield return new WaitForSeconds(2f);
        text1.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(2f);
        text3.SetActive(true);
        yield return new WaitForSeconds(2f);
        text2.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(2f);
        text4.SetActive(true);
        yield return new WaitForSeconds(4f);
        yield return new WaitUntil(() => !GetComponent<AudioSource>().isPlaying);
        operation.allowSceneActivation = true;
    }
}