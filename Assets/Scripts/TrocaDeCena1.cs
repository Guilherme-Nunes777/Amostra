using UnityEngine;
using UnityEngine.SceneManagement;
public class TrocarCena : MonoBehaviour
{
    [Header("Config. Transição de Cena")]
    public float        _delay = 25f; // tempo em segundos antes de mudar a cena
    public string       _nextSceneName = "Parte1";
    void Start()
    {
        Invoke("LoadNextScene", _delay);
    }
    void LoadNextScene()
    {
        SceneManager.LoadScene(_nextSceneName);
    }
}