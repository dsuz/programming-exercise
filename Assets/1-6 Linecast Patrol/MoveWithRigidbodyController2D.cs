﻿using UnityEngine;

/// <summary>
/// 壁を検出したり、床のないところを検出して移動を制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class MoveWithRigidbodyController2D : MonoBehaviour
{
    /// <summary>移動速度</summary>
    [SerializeField] float _moveSpeed = 1f;
    /// <summary>壁を検出するための line のオフセット</summary>
    [SerializeField] Vector2 _lineForWall = Vector2.right;
    /// <summary>壁のレイヤー（レイヤーはオブジェクトに設定されている）</summary>
    [SerializeField] LayerMask _wallLayer = 0;
    /// <summary>床を検出するための line のオフセット</summary>
    [SerializeField] Vector2 _lineForGround = new Vector2(1f, -1f);
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
        Vector2 start = this.transform.position;   // start は「LineCast の始点」である
        Debug.DrawLine(start, start + _lineForWall);  // 検出するセンサーとなる Line を Scene に描く
        // 壁の検出を試みる
        RaycastHit2D hit = Physics2D.Linecast(start, start + _lineForWall, _wallLayer);    // hit には line の衝突情報が入っている
        Vector2 velo = Vector2.zero; // velo は速度のベクトル

        if (!hit.collider)  // hit.collider は「ray が衝突した collider」が入っている。ray が何にもぶつからなかったら null である。
        {
            // 何も検出しなかったら方向を決める
            velo = Vector2.right * _moveSpeed;
        }

        velo.y = _rb.velocity.y;    // 落下については現在の値を保持する
        _rb.velocity = velo;        // 速度ベクトルをセットする
    }

    /// <summary>
    /// 課題4:
    /// 前方に壁を検出するまで右に移動し、壁を検出したら左に移動する処理を書け。
    /// 左に移動している時にも前方に壁を検出したら方向転換して右に移動させよ。
    /// </summary>
    void MoveWithTurn()
    {
        Vector2 start = this.transform.position;
        Debug.DrawLine(start, start + _lineForWall);
        RaycastHit2D hit = Physics2D.Linecast(start, start + _lineForWall, _wallLayer);
        Vector2 velo = Vector2.zero;    // velo は速度ベクトル

        if (hit.collider)
        {
            Debug.Log("Hit Wall");
        }

        velo = _moveDirection.normalized * _moveSpeed;
        velo.y = _rb.velocity.y;
        _rb.velocity = velo;
    }

    /// <summary>
    /// 例題: 床を検出している間は右移動し、床がないことを検出したら停止する処理を書け。
    /// </summary>
    void MoveOnFloorWithStop()
    {
        Vector2 start = this.transform.position;
        Debug.DrawLine(start, start + _lineForGround);    // ray を Scene 上に描く
        // 床の検出を試みる
        RaycastHit2D hit = Physics2D.Linecast(start, start + _lineForGround, _groundLayer);
        Vector2 velo = Vector2.zero; // velo は速度ベクトル

        if (hit.collider)
        {
            // 床を検出したら速度ベクトルを計算する
            velo = Vector2.right * _moveSpeed;
        }

        velo.y = _rb.velocity.y;    // 落下については現在の値を保持する
        _rb.velocity = velo;        // 速度ベクトルをセットする
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