using UnityEngine;

/// <summary>
/// 壁を検出したり、床のないところを検出して移動を制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class MoveWithRigidbodyController2D : MonoBehaviour
{
    /// <summary>移動速度</summary>
    [SerializeField] float m_moveSpeed = 1f;
    /// <summary>壁を検出するための ray のベクトル</summary>
    [SerializeField] Vector2 m_rayForWall = Vector2.zero;
    /// <summary>壁のレイヤー（レイヤーはオブジェクトに設定されている）</summary>
    [SerializeField] LayerMask m_wallLayer = 0;
    /// <summary>床を検出するための ray のベクトル</summary>
    [SerializeField] Vector2 m_rayForGround = Vector2.zero;
    /// <summary>床のレイヤー</summary>
    [SerializeField] LayerMask m_groundLayer = 0;
    Rigidbody2D m_rb = default;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();                     // 例題
        // MoveWithTurn();          // 課題4
        // MoveOnFloorWithStop();   // 例題
        // MoveOnFloorWithTurn();   // 課題5
        // MoveOnFloor();           // 課題6
    }

    /// <summary>
    /// 例題: 前方に壁を検出するまで右に移動し、壁を検出したら停止する処理を書け。
    /// </summary>
    void Move()
    {
        Vector2 origin = this.transform.position;   // origin は「raycast の始点」である
        Debug.DrawLine(origin, origin + m_rayForWall);  // ray（光線）を Scene 上に描く
        // Raycast して壁の検出を試みる
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, m_rayForWall, m_rayForWall.magnitude, m_wallLayer);   // hit には ray の衝突情報が入っている
        Vector2 dir = Vector2.zero; // dir は速度ベクトル

        if (!hit.collider)  // hit.collider は「ray が衝突した collider」が入っている。ray が何にもぶつからなかったら null である。
        {
            // 何も検出しなかったら速度ベクトルを計算する
            dir = Vector2.right * m_moveSpeed;
        }

        dir.y = m_rb.velocity.y;    // 落下については現在の値を採用する
        m_rb.velocity = dir;    // 速度ベクトルをセットする
    }

    /// <summary>
    /// 課題4:
    /// 前方に壁を検出するまで右に移動し、壁を検出したら左に移動する処理を書け。
    /// 左に移動している時にも前方に壁を検出したら方向転換して右に移動させよ。
    /// </summary>
    void MoveWithTurn()
    {

    }

    /// <summary>
    /// 例題: 床を検出している間は右移動し、床がないことを検出したら停止する処理を書け。
    /// </summary>
    void MoveOnFloorWithStop()
    {
        Vector2 origin = this.transform.position;
        Debug.DrawLine(origin, origin + m_rayForGround);    // ray を Scene 上に描く
        // Raycast して床の検出を試みる
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, m_rayForGround, m_rayForGround.magnitude, m_groundLayer);
        Vector2 dir = Vector2.zero; // dir は速度ベクトル

        if (hit.collider)
        {
            // 床を検出したら速度ベクトルを計算する
            dir = Vector2.right * m_moveSpeed;
        }
        dir.y = m_rb.velocity.y;    // 落下については現在の値を採用する
        m_rb.velocity = dir;    // 速度ベクトルをセットする
    }

    /// <summary>
    /// 課題5:
    /// 前方に床を検出している間は右移動し、床が検出できない時は方向転換して左に移動する処理を書け。
    /// 左に移動している時にも前方に床がないことを検出したら方向転換して右に移動させよ。
    /// </summary>
    void MoveOnFloorWithTurn()
    {

    }

    /// <summary>
    /// 課題6:
    /// 「前方に壁を検出した時」と「前方に床がない時」に方向転換する処理を書け。
    /// </summary>
    void MoveOnFloor()
    {

    }
}