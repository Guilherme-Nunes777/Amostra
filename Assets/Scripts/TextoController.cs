using UnityEngine;
using UnityEngine.UI;

public class TextoController : MonoBehaviour
{
    [Header("Config. Texto")]
    public Text         _Texto;                 // Texto a controlar
    public float        _tempoParaSumir = 1f;   // Tempo em segundos para o texto sumir

    private float       _tempoDecorrido = 0f;

    void Update()
    {
        if (_Texto != null && _Texto.gameObject.activeSelf)
        {
            _tempoDecorrido += Time.deltaTime;

            if (_tempoDecorrido >= _tempoParaSumir)
            {
                _Texto.gameObject.SetActive(false);
            }
        }
    }
}
