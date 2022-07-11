using UnityEngine;

public class Elevator : MonoBehaviour
{
    // 動く床を使う時は、以下のように「プレイヤーが "動く床" に乗ったらプレイヤーを "動く床" の子オブジェクトにする」という処理が必要です。
    // 以下の処理をコメントアウトすると、動く床に乗った時にプレイヤーが床にめり込むことがわかるでしょう。

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
