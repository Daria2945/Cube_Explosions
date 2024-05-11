using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cloner : MonoBehaviour
{
    private static int _changeSepation = 100;

    private Rigidbody _gameObject;

    void Start()
    {
        _gameObject = GetComponent<Rigidbody>();
    }

    private void OnMouseUpAsButton()
    {
        if (_changeSepation > 0)
        {
            int divisor = 2;

            _changeSepation /= divisor;

            Clone();
        }
        else
        {
            Destroy(_gameObject.gameObject);
        }
    }

    private void Clone()
    {
        int minNumberOfClones = 2;
        int maxNumberOfClones = 6;

        int numberOfClones = Random.Range(minNumberOfClones, maxNumberOfClones);

        for (int i = 0; i < numberOfClones; i++)
        {
            GameObject clone = Instantiate(_gameObject.gameObject);

            ChangeColor(clone);
            ChangeScale(clone);

            clone.transform.parent = null;
        }

        BlowUp();
    }

    private void ChangeColor(GameObject gameObject)
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    private void ChangeScale(GameObject gameObject)
    {
        int divisor = 2;

        gameObject.transform.localScale = new Vector3(transform.localScale.x / divisor, transform.localScale.y / divisor, transform.localScale.z / divisor);
    }

    private void BlowUp()
    {
        float explosionRadius = 50;
        float explosionForse = 250;

        foreach (Rigidbody explodableObgect in GetExplodableObjects(explosionRadius))
            explodableObgect.AddExplosionForce(explosionForse, transform.position, explosionRadius);

        Destroy(_gameObject.gameObject);
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