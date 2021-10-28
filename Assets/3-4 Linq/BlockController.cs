using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text _text = default;
    string _label = "";

    /// <summary>
    /// これをセットするとオブジェクトの上のラベルに番号が表示される。
    /// </summary>
    public string Label
    {
        get { return _label; }
        set
        {
            _label = value;
            _text.text = _label.ToString();
        }
    }

    void Start()
    {
        this.Label = Random.Range(0, 10).ToString();
    }
}
