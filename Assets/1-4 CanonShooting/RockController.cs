using UnityEngine;

/// <summary>
/// 落ちてくる岩を制御するコンポーネント
/// 砲弾に当たると消える
/// </summary>
public class RockController : MonoBehaviour
{
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
        if (collision.gameObject.tag == "Shell")
        {
            // 自分自身を破棄する
            Destroy(this.gameObject);
        }
    }
}
