using UnityEngine;

/// <summary>
/// オブジェクトを指定したターゲットに移動させるコンポーネント
/// </summary>
public class MoveToController : MonoBehaviour
{
    /// <summary>移動先を示すアンカーポイント</summary>
    [Tooltip("移動先ターゲットとなるオブジェクト")]  // このように書くと Inspector に説明を表示できる
    [SerializeField] Transform[] m_targets = default;
    /// <summary>移動速度</summary>
    [Tooltip("オブジェクトの移動速度")]
    [SerializeField] float m_moveSpeed = 1f;
    /// <summary>ターゲットにこの距離まで近づいたら「到達した」と判断する距離（単位:メートル）</summary>
    [Tooltip("ターゲットに到達したと認識する距離")]
    [SerializeField] float m_stoppingDistance = 0.05f;
    /// <summary>次のターゲットに到達するまでのタイムリミット（秒）</summary>
    [SerializeField] float m_timeLimitToNextTarget = 1f;
    int m_currentTargetIndex = 0;
    float m_timer = 0;

    void Update()
    {
        // MoveToTarget0();    // 例題
        // Patrol();        // 課題1
        PatrolWithChangeTargetByTimeout();   // 課題2
        // PatrolWithChangeTargetByCollision(); // 課題3
    }

    /// <summary>
    /// 例題: m_targets[0] にアサインしたオブジェクトの位置まで移動する処理を書け。
    /// </summary>
    void MoveToTarget0()
    {
        // 自分自身とターゲットの距離を求める
        float distance = Vector2.Distance(this.transform.position, m_targets[0].position);

        if (distance > m_stoppingDistance)  // ターゲットに到達するまで処理する
        {
            Vector3 dir = (m_targets[0].transform.position - this.transform.position).normalized * m_moveSpeed; // 移動方向のベクトルを求める
            this.transform.Translate(dir * Time.deltaTime); // Update の中で移動する場合は、Time.deltaTime をかけることによりどの環境でも同じ速さで移動させることができる
        }
    }

    /// <summary>
    /// 課題1:
    /// m_targets[] にアサインした任意の数 n のオブジェクトを巡回移動する処理を書け。
    /// 例）
    /// m_targets[0] に到達したら次は m_targets[1] に向かう
    /// m_targets[1] に到達したら次は m_targets[2] に向かう
    /// m_targets[2] に到達したら次は m_targets[3] に向かう
    /// ...
    /// m_targets[n] に到達したら次は m_targets[0] に向かう
    /// </summary>
    void Patrol()
    {
        float distance = Vector2.Distance(this.transform.position, m_targets[m_currentTargetIndex].position);

        if (distance > m_stoppingDistance)
        {
            Vector3 dir = (m_targets[m_currentTargetIndex].transform.position - this.transform.position).normalized * m_moveSpeed;
            this.transform.Translate(dir * Time.deltaTime);
        }
        else
        {
            m_currentTargetIndex = (m_currentTargetIndex + 1) % m_targets.Length;
        }
    }

    /// <summary>
    /// 課題2:
    /// m_targets[] にアサインした任意の数 n のオブジェクトを巡回移動する処理を書け。
    /// ただし、制限時間をメンバ変数として設定し、制限時間内に次のオブジェクトに到達しなかった場合は配列の次の要素のオブジェクトに移動先を切り替えよ。
    /// 例）
    /// m_targets[1] に制限時間内に到達しなかったら、その時点で m_targets[2] に向かう
    /// m_targets[2] に制限時間内に到達したら、m_targets[3] に向かう
    /// </summary>
    void PatrolWithChangeTargetByTimeout()
    {
        float distance = Vector2.Distance(this.transform.position, m_targets[m_currentTargetIndex].position);
        m_timer += Time.deltaTime;

        if (distance < m_stoppingDistance || m_timer > m_timeLimitToNextTarget)
        {
            m_currentTargetIndex = (m_currentTargetIndex + 1) % m_targets.Length;
            m_timer = 0;
        }
        else
        {
            Vector3 dir = (m_targets[m_currentTargetIndex].transform.position - this.transform.position).normalized * m_moveSpeed;
            this.transform.Translate(dir * Time.deltaTime);
        }
    }

    /// <summary>
    /// 課題3:
    /// m_targets[] にアサインした任意の数 n のオブジェクトを巡回移動する処理を書け。
    /// ただし、移動中に壁にぶつかった場合は、配列の次の要素のオブジェクトに移動先を切り替えよ。
    /// 例）
    /// m_targets[1] に移動中に何かにぶつかったら、その時点で m_targets[2] に向かう
    /// </summary>
    void PatrolWithChangeTargetByCollision()
    {

    }
}
