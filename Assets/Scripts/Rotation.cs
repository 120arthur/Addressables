using UnityEngine;

public class Rotation : MonoBehaviour
{
    float trumble;
    private void Start()
    {
        trumble = Random.Range(1,5);

        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * trumble;
    }
}
