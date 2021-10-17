using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet3D : MonoBehaviour
{
    [SerializeField] float _speed = 20f;
    [SerializeField] float _lifeTime = 30f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = this.transform.forward * _speed;
        Destroy(this.gameObject, _lifeTime);
    }
}
