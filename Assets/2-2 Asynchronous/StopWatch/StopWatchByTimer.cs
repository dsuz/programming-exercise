using UnityEngine;
using UnityEngine.UI;   // Text を使うため

/// <summary>
/// 「タイマー」を使ってストップウォッチを制御するコンポーネント
/// </summary>
public class StopWatchByTimer : MonoBehaviour
{
    /// <summary>時間を表示する Text コンポーネント</summary>
    [SerializeField] Text m_stopWatch = default;
    /// <summary>タイマー</summary>
    float m_timer = 0;
    /// <summary>ストップウォッチが計測中かどうかを表すフラグ。true の時は計測中とする。</summary>
    bool m_isWorking = false;

    void Update()
    {
        if (m_isWorking)    // 計測中
        {
            // Time.deltaTime は「前回の Update が完了してから経過した秒数」を取得できる。Time クラスは「時間」に関係した機能を持つクラスである。
            m_timer += Time.deltaTime;
            m_stopWatch.text = m_timer.ToString("F2");
            // ↑ToString() の引数 F2 は 「'F'loat の小数点以下 '2' 桁」に書式指定している（参照: https://dobon.net/vb/dotnet/string/inttostring.html）。
            // ↓のように書式指定をしない場合、非常に見づらくなる。
            // m_stopWatch.text = m_timer.ToString();
        }
    }

    /// <summary>
    /// ストップウォッチが停止していたら計測を開始し、計測中ならば計測を停止する
    /// </summary>
    public void StartPause()
    {
        if (m_isWorking)
        {
            // TODO: 計測中ならばストップウォッチを止める
        }
        else
        {
            // 計測中ではない場合は、計測中フラグを立てる
            m_isWorking = true;
        }
    }

    /// <summary>
    /// ストップウォッチを止めて、タイマーを 0 にする
    /// </summary>
    public void Reset()
    {
        if (m_isWorking)
        {
            m_isWorking = false;
        }

        m_timer = 0;
        m_stopWatch.text = m_timer.ToString("F2");
    }
}
