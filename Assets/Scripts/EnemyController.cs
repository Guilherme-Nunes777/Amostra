using UnityEngine;

public class enemyControl : MonoBehaviour
{
    private CapsuleCollider2D   _collider;
    private Animator            _anim;
    private bool                _goRight;

    public int                  _speed;

    public Transform            _a;
    public Transform            _b;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_goRight == true)
        {
            if (Vector2.Distance(transform.position, _b.position) < 0.1f)
            {
                _goRight = false;
            }

            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            transform.position = Vector2.MoveTowards(transform.position, _b.position, _speed * Time.deltaTime);
        }

        else
        {
            if (Vector2.Distance(transform.position, _a.position) < 0.1f)
            {
                _goRight = true;
            }

            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            transform.position = Vector2.MoveTowards(transform.position, _a.position, _speed * Time.deltaTime);
        }
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Define a posição inicial do player (exemplo: (0,0,0))
            collision.gameObject.transform.position = Vector3.zero;
        }
    }*/
}
