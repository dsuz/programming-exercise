using UnityEngine;

/// <summary>
/// オブジェクトをドラッグできるようにするコンポーネント
/// </summary>
public class DragManager : MonoBehaviour
{
    /// <summary>ドラッグできるオブジェクトがいるレイヤー</summary>
    [SerializeField] LayerMask _layerOfDraggableObjects = default;
    /// <summary>ドラッグして移動できる範囲を表すレイヤー</summary>
    [SerializeField] LayerMask _layerOfGround = default;
    [SerializeField] float _rayDistance = 100f;
    /// <summary>ドラッグしているオブジェクト</summary>
    Transform _target = default;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(ray, out hit, _rayDistance, _layerOfDraggableObjects))
            {
                _target = hit.collider.gameObject.transform;
            }
        }
        else if (Input.GetButton("Fire1"))
        {
            if (_target && Physics.Raycast(ray, out hit, _rayDistance, _layerOfGround))
            {
                _target.position = hit.point;
            }
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            _target = null;
        }
    }
}
