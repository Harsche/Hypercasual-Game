using System.Collections;
using UnityEngine;
using Lean.Touch;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float shootFrequency;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private GameObject redBall;
    [SerializeField] private GameObject greenBall;
    [SerializeField] private GameObject blueBall;
    [SerializeField] private GameObject shooterParticles;
    private Coroutine shooting;
    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
        shootFrequency = 1 / shootFrequency;
    }

    private void Start()
    {
        shooterParticles.GetComponent<ParticleSystem>().Stop();
    }

    public void Shoot(LeanFinger finger)
    {
        if (gameObject.activeSelf)
        {
            if (finger.Down)
            {
                shooterParticles.GetComponent<ParticleSystem>().Play();
                shooting = StartCoroutine(ShootProjectile(redBall));
            }
            else if (finger.Up & shooting != null)
            {
                shooterParticles.GetComponent<ParticleSystem>().Stop();
                StopCoroutine(shooting);
            }
        }

    }

    IEnumerator ShootProjectile(GameObject projectile)
    {
        while (true)
        {
            GameObject projObj = Instantiate(projectile, myTransform.position, Quaternion.identity);
            projObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
            yield return new WaitForSeconds(shootFrequency);
        }
    }
}
