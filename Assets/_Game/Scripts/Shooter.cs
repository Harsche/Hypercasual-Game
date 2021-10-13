using System.Collections;
using UnityEngine;
using Lean.Touch;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float shootFrequency;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float tapThreshold;
    [SerializeField] private GameObject redBall;
    [SerializeField] private ParticleSystem shooterParticles;
    private Coroutine shooting;
    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
        shootFrequency = 1 / shootFrequency;
    }

    private void Start()
    {
        shooterParticles.Stop();
    }

    public void Shoot(LeanFinger finger)
    {
        if (gameObject.activeSelf && finger.Index == 0)
        {
            if (finger.Down)
            {
                shooting = StartCoroutine(ShootProjectile(redBall, finger));
            }
            else if (finger.Up & shooting != null)
            {
                StopShooting();
            }
        }

    }

    public void StopShooting()
    {
        shooterParticles.Stop();
        StopCoroutine(shooting);
    }

    IEnumerator ShootProjectile(GameObject projectile, LeanFinger finger)
    {
        yield return new WaitForSeconds(tapThreshold);
        while (true)
        {
            if (!shooterParticles.isPlaying)
            {
                shooterParticles.Play();
            }
            
            GameObject projObj = PoolManager.SpawnObject(projectile, myTransform.position, Quaternion.identity);
            projObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
            yield return new WaitForSeconds(shootFrequency);
        }
    }
}
