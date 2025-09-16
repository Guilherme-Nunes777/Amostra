using UnityEngine;
using UnityEngine.SceneManagement; // Importar para gerenciar cenas

public class Quadros : MonoBehaviour
{
    [Header("Configurações de Movimento do Fundo e Texto")]
    public GameObject   _Fundo;
    public GameObject   _Quadrinhos;
    public GameObject   _Blum;
    public GameObject   _Parede_1;
    public GameObject   _Parede_2;
    public GameObject   _Parede_3;
    public GameObject   _Contagem;
    public GameObject   _Instru;
    public float velocidade = 5f;
    public float limiteX = 1000f;

    [Header("Configurações de Transição de Cena")]
    public float delayParaTrocarCena = 15f; // tempo em segundos antes de trocar de cena
    public string nomeCenaDestino = "Parte2"; // nome da cena para carregar

    private GameObject[] objetosParaMover;

    void Start()
    {
        objetosParaMover = new GameObject[] {
            _Fundo, _Quadrinhos, _Blum, _Parede_1, _Parede_2, _Parede_3, _Contagem, _Instru
        };

        // Chama o método para trocar de cena após delayParaTrocarCena segundos
        Invoke("TrocarCena", delayParaTrocarCena);
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
    }

    void TrocarCena()
    {
        SceneManager.LoadScene(nomeCenaDestino);
    }
}