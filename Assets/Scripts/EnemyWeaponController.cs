using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class EnemyWeaponController : MonoBehaviour
{
    public AssetReference enemyBulet;
    public float frequency;
    public Transform EnemyGun;

    void Start()
    {
        StartCoroutine(WaitToInstanciate());
    }

    IEnumerator WaitToInstanciate()
    {
        yield return new WaitForSeconds(Random.Range(0.4f,frequency));
        enemyBulet.InstantiateAsync(EnemyGun.position, EnemyGun.rotation).Completed += op =>
        {
            if (op.Status == AsyncOperationStatus.Failed)
            {
                Debug.Log("Error in instantiate enemy bulet");
            }
            else
            {
            StartCoroutine(WaitToInstanciate());
            }
        };
    }

}