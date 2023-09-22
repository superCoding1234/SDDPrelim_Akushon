using TMPro;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject deathCutscene;
    [SerializeField] private TextMeshProUGUI deathMessage;
    private PlayerController1 pc1;
    private PlayerController2 pc2;
    private bool playingDeathCutscene;
    private void Start()
    {
        pc1 = FindFirstObjectByType<PlayerController1>();
        pc2 = FindFirstObjectByType<PlayerController2>();
    }
    
    private void Update()
    {
        if (pc1.isDead && !playingDeathCutscene)
        {
            pc2.pi2.PlayerMovement.Disable();
            pc2.pi2.Ability.Disable();
            deathMessage.text = "Player 1 has died! Press space to continue...";
            deathMessage.gameObject.SetActive(true);
        }
        else if (pc2.isDead && !playingDeathCutscene)
        {
            pc1.pi1.PlayerMovement.Disable();
            pc1.pi1.Ability.Disable();
            deathMessage.text = "Player 2 has died! Press space to continue...";
            deathMessage.gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("player1Score") == 3 || PlayerPrefs.GetInt("player2Score") == 3)
        {
            playingDeathCutscene = true;
            FindFirstObjectByType<AudioManager>().Play("DeathMusic");
            PlayerPrefs.DeleteKey("player1Score");
            PlayerPrefs.DeleteKey("player2Score");
            deathMessage.text = "Press space to skip and restart...";
            deathMessage.gameObject.SetActive(true);
            deathCutscene.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) FindFirstObjectByType<AudioManager>().Stop("DeathMusic");
    }
}