using UnityEngine;

public class SpaceShipController2D : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    Rigidbody2D _rb = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(h, 0);
        _rb.velocity = dir.normalized * _speed;
    }
}
