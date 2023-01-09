using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class DrawRadius : MonoBehaviour
{
    [SerializeField] private int _segments = 50;
    [SerializeField] private MeshRenderer _meshRenderer;
    
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _segments + 1;
    }

    public void ShowRadius(float radius)
    {
        _lineRenderer.enabled = true;
        _meshRenderer.enabled = true;

        float x;
        float y;
        float z;

        float angle = 20f;

        for (int i = 0; i < (_segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            _lineRenderer.SetPosition(i, new Vector3(x, transform.position.y, z));

            angle += (360f / _segments);
        }
    }

    public void EndShow()
    {
        _lineRenderer.enabled = false;
        _meshRenderer.enabled = false;
    }
}