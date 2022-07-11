using UnityEngine;

public class Elevator : MonoBehaviour
{
    Animator _anim = default;
    AudioSource _audio = default;
    /// <summary>上にあるのか、下に居るのか</summary>
    bool _isUp = false;
    /// <summary>動作中フラグ</summary>
    bool _isMoving = false;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    public void Move()
    {
        if (_isMoving) return;
        _isMoving = true;
        _audio.Play();

        if (_isUp)
        {
            _anim.Play("Down");
        }
        else
        {
            _anim.Play("Up");
        }

        _isUp = !_isUp;
    }

    /// <summary>
    /// 動作中フラグを倒す。アニメーションイベントから呼ぶ。
    /// </summary>
    void EndMove()
    {
        _isMoving = false;
    }
}
