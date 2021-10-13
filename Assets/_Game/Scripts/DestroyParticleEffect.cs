using UnityEngine;

public class DestroyParticleEffect : MonoBehaviour
{
    private void OnParticleSystemStopped()
    {
        PoolManager.ReleaseObject(gameObject);
    }
}
