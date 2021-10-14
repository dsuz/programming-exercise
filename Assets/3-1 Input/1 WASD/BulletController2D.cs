using UnityEngine;

public class BulletController2D : MonoBehaviour
{
    [SerializeField] Vector2 _dir = Vector2.up;
    [SerializeField] float _speed = 10f;
    [SerializeField] float _lifeTime = 2f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = _dir.normalized * _speed;
        Destroy(this.gameObject, _lifeTime);
    }
}
