using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Death2 : MonoBehaviour
{
    private PlayerController2 pc;
    private TextMeshProUGUI score;
    private int count;

    private void Start()
    {
        pc = GetComponent<PlayerController2>();
        score = pc.score;
    }
    public void SubUpdate()
    {
        if(pc.currentHealth <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SubOnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KO")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);if (!collision.gameObject.CompareTag("KO")) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        score.text = (++count).ToString();
    }
}
