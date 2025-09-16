using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private string nomeDaParteDoJogo;
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDaParteDoJogo);
    }
}
