﻿using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 発射台を制御するコンポーネント。
/// 発射台に接触している Rigidbody を上に打ち上げる。
/// </summary>
public class Launcher : MonoBehaviour
{
    /// <summary>接触しているコライダー</summary>
    Collider2D _touchingCollider;

    /// <summary>
    /// 接触している Rigidbody を打ち上げる。
    /// </summary>
    /// <param name="power">打ち上げる力</param>
    public void Launch(float power)
    {
        var rb = _touchingCollider?.GetComponent<Rigidbody2D>();
        rb?.AddForce(Vector2.up * power, ForceMode2D.Impulse);
    }    

    void OnCollisionEnter2D(Collision2D collision)
    {
        _touchingCollider = collision.collider;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        _touchingCollider = null;
    }
}
