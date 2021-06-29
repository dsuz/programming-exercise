using UnityEngine;

/// <summary>
/// 砲弾 (Shell) を制御するコンポーネント
/// </summary>
public class ShellController : MonoBehaviour
{
    /// <summary>発射する速度</summary>
    [SerializeField] float m_initialSpeed = 5f;
    /// <summary>爆発エフェクトとなるプレハブ</summary>
    [SerializeField] GameObject m_effectPrefab = default;

    void Start()
    {
        // Rigidbody を取得して発射する
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = this.transform.up * m_initialSpeed;
    }

    void Update()
    {
        // 下に落ちたら自分自身を破棄する
        if (this.transform.position.y < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Shell")
        {
            Instantiate(m_effectPrefab, this.transform.position, collision.transform.rotation);
            
        }

        Destroy(this.gameObject);
    }
}
