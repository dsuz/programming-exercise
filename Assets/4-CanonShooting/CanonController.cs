using UnityEngine;

/// <summary>
/// 砲台 (Canon) を制御するコンポーネント
/// </summary>
public class CanonController : MonoBehaviour
{
    /// <summary>砲弾として生成するプレハブ</summary>
    [SerializeField] GameObject m_shellPrefab = default;
    /// <summary>照準（砲台の向く方向）となるオブジェクト</summary>
    [SerializeField] Transform m_crosshair = default;
    /// <summary>砲口を指定する</summary>
    [SerializeField] Transform m_muzzle = default;
    AudioSource m_audio = default;

    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 照準の方向に砲台を向ける
        Vector2 dir = m_crosshair.transform.position - this.transform.position;
        this.transform.up = dir;

        if (Input.GetButtonDown("Fire1"))
        {
            m_audio.Play();
            Instantiate(m_shellPrefab, m_muzzle.position, this.transform.rotation);
        }
    }
}
