using UnityEngine;
using UnityEngine.Rendering;

public class ObstaculoController : MonoBehaviour
{

    private Rigidbody2D         ObstaculoRB;

    private GameController      _GameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ObstaculoRB = GetComponent<Rigidbody2D>();
        //ObstaculoRB.linearVelocity = new Vector2(-5f, 0); 

        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveObjeto();
    }

    void MoveObjeto()
    {
        transform.Translate(Vector2.left * _GameController._ObstaculoVelocidade * Time.smoothDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _GameController._vidasPlayer--; //_GameController._vidasPlayer = _GameController._vidasPlayer - 1; 
            if (_GameController._vidasPlayer <= 0)
            {
                Debug.Log("Fim do jogo");
                _GameController._txtVida.text = "0";
            }
            else
            {
                _GameController._txtVida.text = _GameController._vidasPlayer.ToString();
                Debug.Log("Perdeu uma vida!");
            }
        }
    }

}
