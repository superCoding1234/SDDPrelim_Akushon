using UnityEngine;

public class TimeScaleManager : MonoBehaviour
{
    public bool player1, player2;
    private float originalTimeScale;
    [SerializeField] private float slowTime;
    private void Start()
    {
        originalTimeScale = Time.timeScale;
    }
    
    private void Update()
    {
        Time.timeScale = (player1 || player2) ? slowTime : originalTimeScale;
    }
}