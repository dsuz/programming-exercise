using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMove3D : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _jumpSpeed = 1f;
    Rigidbody _rb = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 dir = Vector3.right * h;
        
        if (dir != Vector3.zero)
        {
            this.transform.forward = dir;
        }

        _rb.velocity = dir * _moveSpeed + _rb.velocity.y * Vector3.up;  // Y 軸方向の速度は変えない

        if (Input.GetButtonDown("Jump"))
        {
            Vector3 velocity = _rb.velocity;
            velocity.y = _jumpSpeed;
            _rb.velocity = velocity;
        }
    }
}
