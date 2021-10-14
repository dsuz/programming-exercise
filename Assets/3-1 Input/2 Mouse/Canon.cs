using UnityEngine;

public class Canon : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        Vector3 dir = pos - this.transform.position;
        this.transform.right = dir;
    }
}
