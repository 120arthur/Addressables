using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class GameControler : MonoBehaviour
{
    [SerializeField]
    private AssetReference _Player;
    [SerializeField]
    private AssetLabelReference _EnemyShipAndAsteroids;
    List<IResourceLocation> EnemyAndAsteroidsLocations;

    public int spawnCownt;
    public float startWait;
    public float waveWait;
    public float timeWait;
    public Vector3 spawnValues;

    void Start()
    {
        LoadEnemyShipAndAsteroids();
    }
    void Update()
    {

    }
    void LoadEnemyShipAndAsteroids()
    {
        Addressables.LoadResourceLocationsAsync(_EnemyShipAndAsteroids.labelString).Completed += OnShipsAndArteroidsLoaded;
    }

    void OnShipsAndArteroidsLoaded(AsyncOperationHandle<IList<IResourceLocation>> op)
    {
        if (op.Status == AsyncOperationStatus.Failed)
        {
            Debug.Log("Error to load ships and Asteroids");
            Invoke("LoadEnemyShipAndAsteroids", 0.5f);
            return;
        }
        EnemyAndAsteroidsLocations = new List<IResourceLocation>(op.Result);
        _Player.InstantiateAsync().Completed += op2 =>
        {
            if (op2.Status == AsyncOperationStatus.Failed)
            {
                Debug.Log("Error to load Player");
                Invoke("LoadEnemyShipAndAsteroids", 1f);
                return;
            }
            else
            {
            StartCoroutine(Waves());
            }
        };
    }

    IEnumerator Waves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < spawnCownt; i++)
            {

                var obstacleAdress = EnemyAndAsteroidsLocations[Random.Range(0, EnemyAndAsteroidsLocations.Count)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion rotation = Quaternion.Euler(0,180,0);
                Addressables.InstantiateAsync(obstacleAdress, spawnPosition, rotation);
                print("oi");

                yield return new WaitForSeconds(timeWait);
            }
                yield return new WaitForSeconds(waveWait);
        }

    }
}

