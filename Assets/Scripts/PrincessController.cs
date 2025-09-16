using UnityEngine;
using UnityEngine.SceneManagement;  // Para controle de cenas

public class PrincessController : MonoBehaviour
{
    [Header("Config. Player")]
    public float            _speed = 5f;
    public float            _jumpForce = 800f;

    private Animator        _anim;
    private Rigidbody2D     _rig;

    private bool            _isGrounded = false;
    private bool            _hasKey = false;  // Flag para indicar se a chave foi coletada

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        _anim.SetBool("walk", moveInput != 0);
        _anim.SetBool("jump", !_isGrounded);
    }

    void Jump()
    {
        if (_isGrounded)
        {
            _rig.linearVelocity = new Vector2(_rig.linearVelocity.x, 0);
            _rig.AddForce(new Vector2(0, _jumpForce));
        }
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        _rig.linearVelocity = new Vector2(moveInput * _speed, _rig.linearVelocity.y);

        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isGrounded = false;
        }
    }

    // Método para ser chamado quando a chave for coletada
    public void CollectKey()
    {
        _hasKey = true;
        Debug.Log("Chave coletada!");
    }

    // Detecta colisão com objetos com tag "prey"
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("prey") && _hasKey)
        {
            Debug.Log("Colidiu com prey e tem a chave. Mudando de cena...");
            // Trocar para a próxima cena (exemplo)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}