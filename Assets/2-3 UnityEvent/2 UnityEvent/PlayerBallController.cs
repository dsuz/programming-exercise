using UnityEngine;

/// <summary>
/// キー入力で Rigidbody を動かす。
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBallController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3f;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = _rb.velocity;
        velocity.x = h * _moveSpeed;
        _rb.velocity = velocity;
    }
}
