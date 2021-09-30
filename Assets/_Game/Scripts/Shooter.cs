using UnityEngine;
using Lean.Touch;

public class Shooter : MonoBehaviour
{
    [SerializeField] private RectTransform canvas;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float initialDelay;
    [SerializeField] private float frequency;
    [SerializeField] private float bulletSpeed;
    private bool shooting;
    private float lastShot;

    public void Shoot(LeanFinger finger)
    {
        if (gameObject.activeSelf)
        {
            if (finger.Down)
            {
                lastShot = Time.time - frequency + initialDelay;
                shooting = true;
            }

            if (finger.Up)
            {
                shooting = false;
            }

            if (shooting && Time.time >= lastShot + frequency)
            {
                GameObject obj = Instantiate(bullet);
                obj.transform.SetParent(canvas);
                obj.transform.position = transform.position;
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                lastShot = Time.time;
            }
        }
    }
}
