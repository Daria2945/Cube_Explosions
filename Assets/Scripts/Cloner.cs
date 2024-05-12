using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cloner : MonoBehaviour
{
    private static int _changeSepation = 100;

    private Rigidbody _objectToClone;

    public bool CanClone => _changeSepation > 0;

    private void Start()
    {
        _objectToClone = GetComponent<Rigidbody>();
    }

    public void Clone()
    {
        int numberOfClones = GetNumberOfClones();

        for (int i = 0; i < numberOfClones; i++)
        {
            GameObject clone = Instantiate(_objectToClone.gameObject);

            ChangeColor(clone);
            ChangeScale(clone);

            clone.transform.parent = null;
        }

        int divisor = 2;
        _changeSepation /= divisor;
    }

    private int GetNumberOfClones()
    {
        int minNumberOfClones = 2;
        int maxNumberOfClones = 6;

        int numberOfClones = Random.Range(minNumberOfClones, maxNumberOfClones);

        return numberOfClones;
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
}