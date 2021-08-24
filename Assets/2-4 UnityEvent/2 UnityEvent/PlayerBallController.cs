using UnityEngine;

/// <summary>
/// キー入力で Rigidbody を動かす。
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBallController : MonoBehaviour
{
    [SerializeField] float m_moveSpeed = 3f;
    Rigidbody2D m_rb = default;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = m_rb.velocity;
        velocity.x = h * m_moveSpeed;
        m_rb.velocity = velocity;
    }
}
