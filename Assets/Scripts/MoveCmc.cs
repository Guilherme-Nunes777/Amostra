using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveQuadros : MonoBehaviour
{
    [Header("Config. GameObjects")]
    public GameObject           _Quadrinhos;                // objeto "quadrinhos"
    public GameObject           _Parede;                    // objeto "parede"


    [Header("Config. Transição da Cena")]
    public float                _tempoParaTrocarCena = 5f; // tempo em segundos para trocar de cena
    public string               _proximaCenaNome;          // nome da próxima cena para carregar
    private float               _tempoDecorrido = 0f;       // contador de tempo
    private bool                _cenaCarregada = false;

    void Update()
    {
        // Conta o tempo para trocar de cena
        _tempoDecorrido += Time.deltaTime;

        if (_tempoDecorrido >= _tempoParaTrocarCena && !_cenaCarregada)
        {
            _cenaCarregada = true;

            if (!string.IsNullOrEmpty(_proximaCenaNome))
            {
                SceneManager.LoadScene(_proximaCenaNome);
            }
            else
            {
                Debug.LogWarning("menu");
            }
        }
    }
}
