using UnityEngine;

public class Movment : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
    }

}
