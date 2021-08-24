using UnityEngine;

public class Elevator : MonoBehaviour
{
    Animator m_anim = default;
    AudioSource m_audio = default;
    /// <summary>上にあるのか、下に居るのか</summary>
    bool m_isUp = false;
    /// <summary>動作中フラグ</summary>
    bool m_isMoving = false;

    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_audio = GetComponent<AudioSource>();
    }

    public void Move()
    {
        if (m_isMoving) return;
        m_isMoving = true;
        m_audio.Play();

        if (m_isUp)
        {
            m_anim.Play("Down");
        }
        else
        {
            m_anim.Play("Up");
        }

        m_isUp = !m_isUp;
    }

    /// <summary>
    /// 動作中フラグを倒す。アニメーションイベントから呼ぶ。
    /// </summary>
    void EndMove()
    {
        m_isMoving = false;
    }
}
