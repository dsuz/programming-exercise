using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// フレームレートを変更するコンポーネント
/// </summary>
public class FramerateController : MonoBehaviour
{
    /// <summary>
    /// フレームレートを変更する
    /// </summary>
    public void ChangeFps(InputField fps)
    {
        ChangeFps(fps.text);
    }

    /// <summary>
    /// フレームレートを変更する
    /// </summary>
    public void ChangeFps(string fps)
    {
        int i = 0;

        if (int.TryParse(fps, out i))
        {
            Application.targetFrameRate = i;
        }
    }

    /// <summary>
    /// フレームレートを変更する
    /// </summary>
    public void ChangeFps(int fps)
    {
        Application.targetFrameRate = fps;
    }
}
