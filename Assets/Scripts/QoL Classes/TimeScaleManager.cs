using UnityEngine;

public class TimeScaleManager : MonoBehaviour
{
    public bool player1, player2;
    private float originalTimeScale;
    [SerializeField] private float slowTime;
    [SerializeField] private PauseScreen ps;
    private void Start()
    {
        originalTimeScale = Time.timeScale;
    }
    
    private void Update()
    {
        if (ps.pauseState) Time.timeScale = 0;
        else if (player1 || player2) Time.timeScale = 0.25f;
        else Time.timeScale = 1;
    }
}