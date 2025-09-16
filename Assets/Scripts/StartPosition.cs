using UnityEngine;
public class startPosition : MonoBehaviour
{
    // Referência ao ponto inicial do player
    public Transform _startPoint;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se colidiu com um inimigo (tag "Enemy")
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Volta para a posição inicial
            transform.position = _startPoint.position;
        }
    }
}