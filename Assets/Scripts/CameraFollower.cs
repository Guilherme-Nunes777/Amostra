using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;      // Referência ao transform do jogador
    public Vector3 offset;        // Distância entre a câmera e o jogador

    void Start()
    {
        if (offset == Vector3.zero && player != null)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
