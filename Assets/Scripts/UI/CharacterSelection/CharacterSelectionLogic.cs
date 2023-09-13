using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionLogic : MonoBehaviour
{
    [SerializeField] private GameObject cutsceneBackground, currentBackground, text1, text2, text3, text4;
    [SerializeField] private Button[] p1Controls, p2Controls;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) p1Controls[0].onClick.Invoke();
        else if(Input.GetKeyDown(KeyCode.S)) p1Controls[1].onClick.Invoke();
        else if(Input.GetKeyDown(KeyCode.D)) p1Controls[2].onClick.Invoke();
        else if(Input.GetKeyDown(KeyCode.A)) p1Controls[3].onClick.Invoke();
        else if(Input.GetKeyDown(KeyCode.LeftShift)) p1Controls[4].onClick.Invoke();
        if (Input.GetKeyDown(KeyCode.UpArrow)) p2Controls[0].onClick.Invoke();
        else if(Input.GetKeyDown(KeyCode.DownArrow)) p2Controls[1].onClick.Invoke();
        else if(Input.GetKeyDown(KeyCode.RightArrow)) p2Controls[2].onClick.Invoke();
        else if(Input.GetKeyDown(KeyCode.LeftArrow)) p2Controls[3].onClick.Invoke();
        else if(Input.GetKeyDown(KeyCode.RightShift)) p2Controls[4].onClick.Invoke();
    }

    public void StartCutsceneCoroutine()
    {
        StartCoroutine(StartCutscene());
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
        FindFirstObjectByType<AudioManager>().Play("BattleMusic");
        operation.allowSceneActivation = true;

    }
}