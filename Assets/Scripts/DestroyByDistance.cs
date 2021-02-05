using UnityEngine;
using UnityEngine.AddressableAssets;

public class DestroyByDistance : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            Addressables.ReleaseInstance(gameObject);
        }
    }
}
