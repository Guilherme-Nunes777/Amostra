using UnityEngine;

public class Key : MonoBehaviour
{   
    [Header("Config. Chave")]
    private PrincessController _playerController;

    void Start()
    {
        // Busca o componente PrincessController no objeto com tag "Player"
        _playerController = GameObject.FindWithTag("Player").GetComponent<PrincessController>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _playerController.CollectKey();
            Destroy(gameObject);
        }
    }
}