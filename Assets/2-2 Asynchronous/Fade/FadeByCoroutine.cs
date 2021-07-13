using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 「コルーチン」を使ってフェードアウトを実現するコンポーネント
/// 適当なオブジェクトに追加して使う
/// </summary>
public class FadeByCoroutine : MonoBehaviour
{
    /// <summary>フェード用 Image</summary>
    [SerializeField] Image m_fadeImage = default;
    /// <summary>フェードアウト完了までにかかる時間（秒）/summary>
    [SerializeField] float m_fadeTime = 1;
    float m_timer = 0;

    /// <summary>
    /// フェードアウトを開始する
    /// </summary>
    public void Fade()
    {
        Debug.Log("コルーチンによる Fade 開始");
        StartCoroutine(FadeRoutine());
    }

    IEnumerator FadeRoutine()
    {
        // Image から Color を取得し、時間の進行に合わせたアルファを設定して Image に戻す
        while (true)
        {
            m_timer += Time.deltaTime;
            Color c = m_fadeImage.color;
            c.a = m_timer / m_fadeTime;
            m_fadeImage.color = c;

            if (m_timer > m_fadeTime)
            {
                Debug.Log("コルーチンによる Fade 完了");
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
