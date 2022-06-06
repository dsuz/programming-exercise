using UnityEngine;

/// <summary>
/// 壁を検出したり、床のないところを検出して移動を制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class MoveWithRigidbodyController2D : MonoBehaviour
{
    /// <summary>移動速度</summary>
    [SerializeField] float _moveSpeed = 1f;
    /// <summary>壁を検出するための ray のベクトル</summary>
    [SerializeField] Vector2 _rayForWall = Vector2.right * 0.6f;
    /// <summary>壁のレイヤー（レイヤーはオブジェクトに設定されている）</summary>
    [SerializeField] LayerMask _wallLayer = 0;
    /// <summary>床を検出するための ray のベクトル</summary>
    [SerializeField] Vector2 _rayForGround = new Vector2(0.65f, -0.6f);
    /// <summary>床のレイヤー</summary>
    [SerializeField] LayerMask _groundLayer = 0;
    /// <summary>移動方向</summary>
    Vector2 _moveDirection = Vector2.right;
    Rigidbody2D _rb = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move();                     // 例題
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
        Debug.DrawLine(origin, origin + _rayForWall);  // ray（光線）を Scene 上に描く
        // Raycast して壁の検出を試みる
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, _rayForWall, _rayForWall.magnitude, _wallLayer);   // hit には ray の衝突情報が入っている
        Vector2 dir = Vector2.zero; // dir は速度ベクトル

        if (!hit.collider)  // hit.collider は「ray が衝突した collider」が入っている。ray が何にもぶつからなかったら null である。
        {
            // 何も検出しなかったら速度ベクトルを計算する
            dir = Vector2.right * _moveSpeed;
        }

        dir.y = _rb.velocity.y;    // 落下については現在の値を採用する
        _rb.velocity = dir;    // 速度ベクトルをセットする
    }

    /// <summary>
    /// 課題4:
    /// 前方に壁を検出するまで右に移動し、壁を検出したら左に移動する処理を書け。
    /// 左に移動している時にも前方に壁を検出したら方向転換して右に移動させよ。
    /// </summary>
    void MoveWithTurn()
    {
        Vector2 origin = this.transform.position;
        Debug.DrawLine(origin, origin + _rayForWall);
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, _rayForWall, _rayForWall.magnitude, _wallLayer);
        Vector2 dir = Vector2.zero;

        if (hit.collider)
        {
            _moveDirection = new Vector2(-1 * _moveDirection.x, _moveDirection.y);
            _rayForWall = new Vector2(-1 * _rayForWall.x, _rayForWall.y);
        }

        dir = _moveDirection.normalized * _moveSpeed;
        dir.y = _rb.velocity.y;
        _rb.velocity = dir;
    }

    /// <summary>
    /// 例題: 床を検出している間は右移動し、床がないことを検出したら停止する処理を書け。
    /// </summary>
    void MoveOnFloorWithStop()
    {
        Vector2 origin = this.transform.position;
        Debug.DrawLine(origin, origin + _rayForGround);    // ray を Scene 上に描く
        // Raycast して床の検出を試みる
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, _rayForGround, _rayForGround.magnitude, _groundLayer);
        Vector2 dir = Vector2.zero; // dir は速度ベクトル

        if (hit.collider)
        {
            // 床を検出したら速度ベクトルを計算する
            dir = Vector2.right * _moveSpeed;
        }
        dir.y = _rb.velocity.y;    // 落下については現在の値を採用する
        _rb.velocity = dir;    // 速度ベクトルをセットする
    }

    /// <summary>
    /// 課題5:
    /// 前方に床を検出している間は右移動し、床が検出できない時は方向転換して左に移動する処理を書け。
    /// 左に移動している時にも前方に床がないことを検出したら方向転換して右に移動させよ。
    /// </summary>
    void MoveOnFloorWithTurn()
    {
        Vector2 origin = this.transform.position;
        Debug.DrawLine(origin, origin + _rayForGround);
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, _rayForGround, _rayForGround.magnitude, _groundLayer);
        Vector2 dir = Vector2.zero;

        if (hit.collider == null)
        {
            _moveDirection = new Vector2(-1 * _moveDirection.x, _moveDirection.y);
            _rayForGround = new Vector2(-1 * _rayForGround.x, _rayForGround.y);
        }

        dir = _moveDirection.normalized * _moveSpeed;
        dir.y = _rb.velocity.y;
        _rb.velocity = dir;
    }

    /// <summary>
    /// 課題6:
    /// 「前方に壁を検出した時」と「前方に床がない時」に方向転換する処理を書け。
    /// </summary>
    void MoveOnFloor()
    {
        Vector2 origin = this.transform.position;
        Debug.DrawLine(origin, origin + _rayForGround, Color.red);
        Debug.DrawLine(origin, origin + _rayForWall, Color.blue);
        RaycastHit2D hitForWall = Physics2D.Raycast(this.transform.position, _rayForWall, _rayForWall.magnitude, _wallLayer);
        RaycastHit2D hitForGround = Physics2D.Raycast(this.transform.position, _rayForGround, _rayForGround.magnitude, _groundLayer);
        Vector2 dir = Vector2.zero;

        if (hitForWall.collider != null || hitForGround.collider == null)
        {
            _moveDirection = new Vector2(-1 * _moveDirection.x, _moveDirection.y);
            _rayForGround = new Vector2(-1 * _rayForGround.x, _rayForGround.y);
            _rayForWall = new Vector2(-1 * _rayForWall.x, _rayForWall.y);
        }

        dir = _moveDirection.normalized * _moveSpeed;
        dir.y = _rb.velocity.y;
        _rb.velocity = dir;
    }
}