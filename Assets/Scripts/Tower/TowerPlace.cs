using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Collider))]
public class TowerPlace : MonoBehaviour
{
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _greenMaterial;

    private MeshRenderer _renderer;
    private bool _isFree = true;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _renderer.material = _defaultMaterial;
    }

    public void ShowPlace()
    {
        if (_isFree == true)
        {
            _renderer.material = _greenMaterial;
        }
    }

    public void EndShowPlace()
    {
        _renderer.material = _defaultMaterial;
    }

    public void Reserve()
    {
        _isFree = false;
    }

    public void Release()
    {
        _isFree = true;
    }
}
