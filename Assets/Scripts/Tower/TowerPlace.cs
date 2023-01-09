using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Collider))]
public class TowerPlace : MonoBehaviour
{
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _greenMaterial;

    private MeshRenderer _renderer;
    public bool IsFree {get; private set;} = true;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _renderer.material = _defaultMaterial;
    }

    public void ShowPlace()
    {
        if (IsFree == true)
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
        IsFree = false;
    }

    public void Release()
    {
        IsFree = true;
    }
}
