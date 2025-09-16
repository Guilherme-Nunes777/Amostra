using UnityEngine;
using UnityEngine.UI;

public class MoverFundoETexto : MonoBehaviour
{
    [Header("Configurações de Movimento do Fundo e Texto")]
    public GameObject   _Fundo;
    public GameObject   _Quadrinhos;
    public GameObject   _Blum;
    public GameObject   _Parede_1;
    public GameObject   _Parede_2;
    public GameObject   _Parede_3;
    public GameObject   _Parede_4;
    public GameObject   _Parede_5;
    public GameObject   _Contagem;
    public GameObject   _Instru;
    public Text Texto;
    public float velocidade = 5f;
    public float limiteX = 1000f;

    private RectTransform textoRect;
    private GameObject[] objetosParaMover;

    void Start()
    {
        if (Texto != null)
            textoRect = Texto.GetComponent<RectTransform>();

        objetosParaMover = new GameObject[] {
            _Fundo, _Quadrinhos, _Blum, _Parede_1, _Parede_2, _Parede_3, _Parede_4, _Parede_5, _Contagem, _Instru
        };
    }

    void Update()
    {
        float movimento = velocidade * Time.deltaTime;

        // Move objetos do mundo para a esquerda
        foreach (GameObject obj in objetosParaMover)
        {
            if (obj != null && obj.activeSelf)
            {
                obj.transform.Translate(Vector2.left * movimento);

                if (obj.transform.position.x < -limiteX)
                {
                    obj.SetActive(false);
                }
            }
        }

        // Mantém o texto fixo no centro do canvas
        if (textoRect != null && Texto.gameObject.activeSelf)
        {
            textoRect.anchoredPosition = Vector2.zero;
        }
    }
}
