using UnityEngine;

public class ObstaculoMovimento : MonoBehaviour
{
    private GameController _gameController;

    void Start()
    {
        _gameController = FindAnyObjectByType(typeof(GameController)) as GameController;
    }

    void Update()
    {
        // Move para a esquerda
        transform.Translate(Vector2.left * _gameController._ObstaculoVelocidade * Time.deltaTime);

        // Destrói quando sai da tela
        if (transform.position.x < -15f) // ajuste conforme tamanho da câmera
        {
            Destroy(gameObject);
        }
    }
}
