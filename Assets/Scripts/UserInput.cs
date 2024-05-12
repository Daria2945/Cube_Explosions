using UnityEngine;

[RequireComponent(typeof(Exploder))]
public class UserInput : MonoBehaviour
{
    private Exploder _exploder;
    private Cloner _cloner;
    private Rigidbody _obgect;

    private void Start()
    {
        _cloner = GetComponent<Cloner>();
        _exploder = GetComponent<Exploder>();
        _obgect = GetComponent<Rigidbody>();
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
            Destroy(_obgect.gameObject);
        }
    }
}