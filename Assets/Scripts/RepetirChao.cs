using Unity.VisualScripting;
using UnityEngine;

public class RepetirChao : MonoBehaviour
{
    private GameController _gameController;

    public bool _chaoInstanciado = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameController = FindAnyObjectByType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(_chaoInstanciado == false)
        {
            if(transform.position.x < 0)
            {
                _chaoInstanciado = true;
                GameObject ObjetoTemporarioChao = Instantiate(_gameController._chaoPrefab);
                ObjetoTemporarioChao.transform.position = new Vector3(transform.position.x + _gameController._chaoTamanho, transform.position.y);

                Debug.Log("O ch�o foi instaciado");
            }
        }*/
    }

    private void FixedUpdate()
    {
        MoveChao();
    }

    void MoveChao()
    {
        transform.Translate(Vector2.left * _gameController._chaoVelocidade * Time.deltaTime);
    }


}
