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
    [SerializeField] Image _fadeImage = default;
    /// <summary>フェードアウト完了までにかかる時間（秒）/summary>
    [SerializeField] float _fadeTime = 1;
    float _timer = 0;

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
            _timer += Time.deltaTime;
            Color c = _fadeImage.color; // 現在の Image の色を取得する
            c.a = _timer / _fadeTime;   // 色のアルファを 1 に近づけていく
            // TODO: 色を Image にセットする

            // _fadeTime が経過したら処理は終了する
            if (_timer > _fadeTime)
            {
                Debug.Log("コルーチンによる Fade 完了");
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
