using UnityEngine;
using UnityEngine.AddressableAssets;

public class DestroyByContact : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || gameObject.tag == "Boundary")
        {
            return;
        }
        else if (gameObject.tag == "Asteroid" )
        {
            Destroy(other);
        }
        else if ( gameObject.tag == "EnemyShip")
        {
            if (other.tag != "EnemyBulet")
            Destroy(other);
        }
        else if (gameObject.tag == "PlayerBulet")
        {
           if (other.tag != "PlayerShip")
               Destroy(other);
        }
        else if (gameObject.tag == "EnemyBulet")
        {
            if (other.tag == "PlayerShip" || other.tag != "EnemyShip")
               Destroy(other);
        }    
    }
    public void Destroy(Collider other)
    {
        Addressables.ReleaseInstance(gameObject);
        Addressables.ReleaseInstance(other.gameObject);
    }
}
