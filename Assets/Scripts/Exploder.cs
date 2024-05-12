using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cloner))]
public class Exploder : MonoBehaviour
{
    private Rigidbody _objectToExplode;

    private void Start()
    {
        _objectToExplode = GetComponent<Rigidbody>();
    }

    public void BlowUp()
    {
        float explosionRadius = 50;
        float explosionForse = 250;

        foreach (Rigidbody explodableObgect in GetExplodableObjects(explosionRadius))
            explodableObgect.AddExplosionForce(explosionForse, transform.position, explosionRadius);

        Destroy(_objectToExplode.gameObject);
    }

    private List<Rigidbody> GetExplodableObjects(float explosionRadius)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        List<Rigidbody> objects = new List<Rigidbody>();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                objects.Add(hit.attachedRigidbody);

        return objects;
    }
}