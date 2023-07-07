using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;

    public void LateUpdate()
    {
        transform.position = (player1.position + player2.position) / 2 + Vector3.back * 10;
        
    }
}
