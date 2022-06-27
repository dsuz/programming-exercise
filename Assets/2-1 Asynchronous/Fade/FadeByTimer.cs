using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 「タイマー」を使ってフェードアウトを実現するコンポーネント
/// 適当なオブジェクトに追加して使う
/// </summary>
public class FadeByTimer : MonoBehaviour
{
    /// <summary>フェード用 Image</summary>
    [SerializeField] Image _fadeImage = default;
    /// <summary>フェードアウト完了までにかかる時間（秒）/summary>
    [SerializeField] float _fadeTime = 1;
    /// <summary>フェードアウトが完了したら鳴らす音/summary>
    [SerializeField] AudioClip _buzzer = default;
    float _timer = 0;
    /// <summary>true の時フェード中を表すフラグ</summary>
    bool _fade = false;

    void Update()
    {
        if (_fade)
        {
            // Image から Color を取得し、時間の進行に合わせたアルファを設定して Image に戻す
            _timer += Time.deltaTime;
            Color c = _fadeImage.color;
            c.a = _timer / _fadeTime;
            _fadeImage.color = c;

            if (_timer > _fadeTime)
            {
                // フェード完了
                OnFadeFinished();
            }
        }
    }

    /// <summary>
    /// フェードアウトを開始する
    /// </summary>
    public void Fade()
    {
        _fade = true;
        Debug.Log("Fade 開始");
    }

    /// <summary>
    /// フェードアウトが終わった時に呼び出す
    /// </summary>
    void OnFadeFinished()
    {
        _fade = false;
        Debug.Log("Fade 完了");
        AudioSource.PlayClipAtPoint(_buzzer, Camera.main.transform.position);
    }
}
