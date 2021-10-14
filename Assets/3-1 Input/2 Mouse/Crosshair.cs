using UnityEngine;

public class Crosshair : MonoBehaviour
{
    void OnEnable()
    {
        // マウスカーソルを消すには、以下の行をアンコメントする
        // Cursor.visible = false;
    }

    void OnDisable()
    {
        Cursor.visible = true;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
