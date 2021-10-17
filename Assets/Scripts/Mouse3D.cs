using System;
using UnityEngine;

public class Mouse3D : MonoBehaviour
{

    [SerializeField]
    private LayerMask mouseColliderLayerMask = new LayerMask();

    public static Mouse3D Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out RaycastHit rayCastHit, 999f, mouseColliderLayerMask))
        {
            transform.position = rayCastHit.point;
        }
    }

    public static Vector3 GetMouserWorldPosition() => Instance.GetMouserWorldPosition_Instance();

    private Vector3 GetMouserWorldPosition_Instance()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out RaycastHit rayCastHit,999f, mouseColliderLayerMask))
        {
            return rayCastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
