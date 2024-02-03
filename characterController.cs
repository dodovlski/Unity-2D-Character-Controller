using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 1.0f;
    [SerializeField] private GameObject camera;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Vector3 charPos;
    private Rigidbody2D r2d;
    private int num;


    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>(); // caching r2d
        _animator = GetComponent<Animator>();
        charPos = transform.position;
        num = 1;
    }

    private void Update()
    {
        charPos = new Vector3(charPos.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, charPos.y);
        transform.position = charPos;
        if (Input.GetAxis("Horizontal") == 0.0f)
            _animator.SetFloat("speed", 0.0f);
        else
            _animator.SetFloat("speed", 1.0f);

        if (Input.GetAxis("Horizontal") > 0.01f)
            _spriteRenderer.flipX = false;

        else if (Input.GetAxis("Horizontal") < -0.01f) _spriteRenderer.flipX = true;

        r2d.velocity = new Vector2(speed, 0f);
        num = 3;
        Debug.Log("Update" + num);
    }

    private void FixedUpdate()
    {
        num = 2;
    }


    private void LateUpdate()
    {
        num = 4;
    }
}