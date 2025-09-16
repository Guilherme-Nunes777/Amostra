using System.Collections;

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Propiedades do Ch�o
    [Header("Config. do Chão")]
    public float                _chaoDestruido; 
    public float                _chaoTamanho;
    public float                _chaoVelocidade;
    public GameObject           _chaoPrefab;

    [Header("Config. De Obstáculo Morcego")]
    public float                _ObstaculoTempoMorcego;
    public GameObject           _ObstaculoPrefabMorcego;

    [Header("Config. De Obstáculo Árvore")]
    public float                _ObstaculoTempoArvore;
    public GameObject           _ObstaculoPrefabArvore;

    [Header("Config. De Obstáculo Lobo")]
    public float                _ObstaculoTempoLobo;
    public GameObject           _ObstaculoPrefabLobo;

    [Header("Config. UI")]
    public int                  _vidasPlayer;
    public Text                 _txtVida;
    public Text                 _txtMetros;


    [Header("Controle de Distância")]
    public int _metrosPercorridos = 0;

    [Header("Config. Geral")]
    public float _ObstaculoVelocidade = 5f; //cong. geral da velocidade dos inimigos/obstaculos


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawObstaculoMorcego());
        StartCoroutine(SpawObstaculoArvore());
        StartCoroutine(SpawObstaculoLobo());
        InvokeRepeating("DistanciaPercorrida", 0f, 0.2f);
    }
    // Update is called once per frame
  void Update()
    {
        // Verifica se as vidas chegaram a zero
        if (_vidasPlayer <= 0)
        {
            SceneManager.LoadScene("Parte2da1");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Parte1");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("menu");
        }
    }

    IEnumerator SpawObstaculoMorcego()
    {
        while (true)
        {
            yield return new WaitForSeconds(_ObstaculoTempoMorcego);
            Vector3 posMorcego = new Vector3(10f, -2f, 0f);
            Instantiate(_ObstaculoPrefabMorcego, posMorcego, Quaternion.identity);
        }
    }

    IEnumerator SpawObstaculoArvore()
    {
        while (true)
        {
            yield return new WaitForSeconds(_ObstaculoTempoArvore);
            Vector3 posArvore = new Vector3(10f, -2.1f, 0f);
            Instantiate(_ObstaculoPrefabArvore, posArvore, Quaternion.identity);
        }
    }

    IEnumerator SpawObstaculoLobo()
    {
        while (true)
        {
            yield return new WaitForSeconds(_ObstaculoTempoLobo);
            Vector3 posLobo = new Vector3(10f, -2.3f, 0f);
            Instantiate(_ObstaculoPrefabLobo, posLobo, Quaternion.identity);
        }
    }

    void DistanciaPercorrida()
    {
        _metrosPercorridos++; // _metrosPercorridos = _metrosPercorridos + 1;
        _txtMetros.text = _metrosPercorridos.ToString() + " m";
    }

}
