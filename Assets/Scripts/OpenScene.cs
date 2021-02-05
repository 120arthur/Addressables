using UnityEngine;
using UnityEngine.AddressableAssets;

public class OpenScene : MonoBehaviour
{
   public AssetReference Scene;
    void Start()
    {
        Addressables.LoadSceneAsync(Scene);
    }
}
