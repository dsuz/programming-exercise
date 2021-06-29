using UnityEngine;

/// <summary>
/// Star を制御するコンポーネント
/// </summary>
public class StarController : MonoBehaviour
{
    /// <summary>砲弾が当たった時に鳴らす効果音</summary>
    [SerializeField] AudioClip m_getSound = default;

    void Update()
    {
        if (this.transform.position.y < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 砲弾が当たった時
        if (collision.gameObject.tag == "Shell")
        {
            AudioSource.PlayClipAtPoint(m_getSound, this.transform.position);
            // 自分自身を破棄する
            Destroy(this.gameObject);
        }
    }
}
