using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Config. Player")]
    public float _speed = 5f;
    public float _jumpForce = 650f;

    private bool _isGrounded = true;
    private Rigidbody2D _rig;
    private Animator _anim;

    public string _isGroundedBool = "eChao";

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Permite pular somente se estiver no chão
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Movimento horizontal constante
        transform.Translate(new Vector3(_speed * Time.fixedDeltaTime, 0, 0));

        // Atualiza parâmetro da animação
        if (_anim != null)
            _anim.SetBool(_isGroundedBool, _isGrounded);
    }

    void Jump()
    {
        _rig.linearVelocity = new Vector2(_rig.linearVelocity.x, 0);
        _rig.AddForce(new Vector2(0, _jumpForce));
        _isGrounded = false;

        if (_anim != null)
            _anim.SetBool(_isGroundedBool, false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;

            if (_anim != null)
                _anim.SetBool(_isGroundedBool, true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;

            if (_anim != null)
                _anim.SetBool(_isGroundedBool, false);
        }
    }
}