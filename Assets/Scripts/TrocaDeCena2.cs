using UnityEngine;
using UnityEngine.SceneManagement;
public class transiçãoCena : MonoBehaviour
{
    [Header("Config. Interação da Chave")]
    private bool        _Key = false;
    private bool        _tocarPrey = false;

    // Método para ser chamado quando a chave for coletada
    public void CollectKey()
    {
        _Key = true;
    }
    
    // Detecta colisão com o objeto "prey"
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("prey"))
        {
            _tocarPrey = true;
            TryTransition();
        }
    }

    void TryTransition()
    {
        if (_Key && _tocarPrey)
        {
            
            SceneManager.LoadScene("Parte2da2");
        }
    }
}