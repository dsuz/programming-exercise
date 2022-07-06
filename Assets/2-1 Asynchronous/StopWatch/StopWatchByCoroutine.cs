using System.Collections;   // IEnumerator を使うため
using UnityEngine;
using UnityEngine.UI;   // Text を使うため

/// <summary>
/// 「コルーチン」を使ってストップウォッチを制御するコンポーネント
/// </summary>
public class StopWatchByCoroutine : MonoBehaviour
{
    /// <summary>時間を表示する Text コンポーネント</summary>
    [SerializeField] Text _stopWatch = default;
    /// <summary>ストップウォッチの計測値</summary>
    float _timer = 0;
    /// <summary>実行中のコルーチン（実行していない時は null）</summary>
    Coroutine _coroutine = null;

    /// <summary>
    /// ストップウォッチが停止していたら計測を開始し、計測中ならば計測を停止する
    /// </summary>
    public void StartPause()
    {
        if (_coroutine == null)    // 停止している時は
        {
            // コルーチンを開始する
            _coroutine = StartCoroutine(StartWorkingRoutine());
        }
        else
        {
            // TODO: 実行中だったら停止する
        }
    }

    /// <summary>
    /// ストップウォッチの計測を開始する
    /// </summary>
    /// <returns></returns>
    IEnumerator StartWorkingRoutine()
    {
        while (true)
        {
            _timer += Time.deltaTime;
            _stopWatch.text = _timer.ToString("F2");
            yield return new WaitForEndOfFrame();   // Update() の処理が終わるまで待つ
        }
    }

    /// <summary>
    /// ストップウォッチのタイマーを 0 にリセットする
    /// </summary>
    public void Reset()
    {
        // TODO: 機能を作る
    }
}
