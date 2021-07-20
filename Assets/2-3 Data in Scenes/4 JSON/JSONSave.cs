using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// JSON 形式に変換（シリアライズ、シリアル化）して PlayerPrefs に保存する
/// </summary>
public class JSONSave : MonoBehaviour
{
    [SerializeField] InputField m_nameInput = default;
    [SerializeField] InputField m_levelInput = default;
    [SerializeField] InputField m_maxHpInput = default;
    [SerializeField] InputField m_hpInput = default;

    public void Save()
    {
        // インスタンスを作る
        int level = int.Parse(m_levelInput.text);
        int maxHp = int.Parse(m_maxHpInput.text);
        int hp = int.Parse(m_hpInput.text);
        SaveData saveData = new SaveData(m_nameInput.text, level, maxHp, hp);

        // インスタンス変数を JSON にシリアル化する
        string json = JsonUtility.ToJson(saveData);
        Debug.Log($"JSON: {json}");

        // PlayerPrefs に保存する
        PlayerPrefs.SetString("SaveData", json);
    }
}
