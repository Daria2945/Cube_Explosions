using UnityEngine;

[RequireComponent(typeof(Exploder))]
[RequireComponent(typeof(Cloner))]
[RequireComponent(typeof(Rigidbody))]
public class UserInput : MonoBehaviour
{
    private Exploder _exploder;
    private Cloner _cloner;
    private Rigidbody _selectedObgect;

    private void Start()
    {
        _cloner = GetComponent<Cloner>();
        _exploder = GetComponent<Exploder>();
        _selectedObgect = GetComponent<Rigidbody>();
    }

    private void OnMouseUpAsButton()
    {
        if (_cloner.CanClone)
        {
            _cloner.Clone();
            _exploder.BlowUp();
        }
        else
        {
            Destroy(_selectedObgect.gameObject);
        }
    }
}