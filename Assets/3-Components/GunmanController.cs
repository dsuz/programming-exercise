using UnityEngine;

/// <summary>
/// ガンマンのキャラクターを操作するコンポーネント
/// </summary>
public class GunmanController : MonoBehaviour
{
    /// <summary>左右移動する力</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float m_jumpPower = 15f;
    /// <summary>色の配列</summary>
    [SerializeField] Color[] m_colors = default;
    /// <summary>弾丸のプレハブ</summary>
    [SerializeField] GameObject m_bulletPrefab = default;
    /// <summary>銃口の位置を設定するオブジェクト</summary>
    [SerializeField] Transform m_muzzle = default;
    /// <summary>入力に応じて左右を反転させるかどうかのフラグ</summary>
    [SerializeField] bool m_flipX = false;
    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;
    /// <summary>m_colors に使う添字</summary>
    int m_colorIndex;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    float m_scaleX;
    /// <summary>最初に出現した座標</summary>
    Vector3 m_initialPosition;
    /// <summary>接地判定変数</summary>
    bool m_isGrounded = false;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        // 初期位置を覚えておく
        m_initialPosition = this.transform.position;
    }

    void Update()
    {
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");

        // 各種入力を受け取る
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("ここにジャンプする処理を書く。");
            if (m_isGrounded)
            {
                this.m_rb.AddForce(Vector2.up * this.m_jumpPower, ForceMode2D.Impulse);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("ここに弾を発射する処理を書く。");
            Instantiate(m_bulletPrefab, this.m_muzzle.position, Quaternion.identity);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("ここに色を切り替える処理を書く。");
            this.m_colorIndex++;
            m_sprite.color = this.m_colors[m_colorIndex % this.m_colors.Length];
        }

        // 下に行きすぎたら初期位置に戻す
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
        }

        // 設定に応じて左右を反転させる
        if (m_flipX)
        {
            FlipX(m_h);
        }
    }

    private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        m_rb.AddForce(Vector2.right * m_h * m_movePower, ForceMode2D.Force);
    }

    /// <summary>
    /// 左右を反転させる
    /// </summary>
    /// <param name="horizontal">水平方向の入力値</param>
    void FlipX(float horizontal)
    {
        /*
         * 左を入力されたらキャラクターを左に向ける。
         * 左右を反転させるには、Transform:Scale:X に -1 を掛ける。
         * Sprite Renderer の Flip:X を操作しても反転する。
         * */
        m_scaleX = this.transform.localScale.x;

        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 足下にトリガーを追加しておくこと。足下のトリガーに地面が接触したら「接地している」とみなす。
        m_isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 足下にトリガーを追加しておくこと。足下のトリガーから地面が離れたら「接地していない」とみなす。
        m_isGrounded = false;
    }
}
