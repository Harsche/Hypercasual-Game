using UnityEngine;
using Lean.Touch;

public class Movement : MonoBehaviour
{
    [SerializeField] private float characterSpeed;
    [SerializeField] private float tapThreshold;
    private Camera mainCamera;
    public bool canMove = true;
    private Transform myTransform;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private Rigidbody2D myRb2d;

    private void Awake()
    {
        mainCamera = Globals.MainCamera.GetComponent<Camera>();
        myTransform = transform;
        myRb2d = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    /*    private void FixedUpdate()
    {
        anim.SetFloat("Velocity", myRb2d.velocity.magnitude);

        if (myRb2d.velocity.magnitude != 0)
        {
            anim.SetFloat("Vel_X", myRb2d.velocity.x);
            anim.SetFloat("Vel_Y", myRb2d.velocity.y);
            spriteRenderer.flipX = myRb2d.velocity.x >= 0 ? false : true;
        }
    }
    */

    public void Move(LeanFinger finger)
    {
        if (enabled && finger.Index == 0)
        {
            if (!finger.Up && canMove)
            {
                Vector2 screenPos = finger.ScreenPosition;

                screenPos = RemapScreenPosition(screenPos);
                Vector3 toWorldPos = new Vector3(screenPos.x, screenPos.y, 10f);
                Vector2 direction = mainCamera.ScreenToWorldPoint(toWorldPos) - myTransform.position;

                if (direction.magnitude < 0.05)
                {
                    direction = Vector2.zero;
                }
                
                myRb2d.velocity = direction * characterSpeed;
            }
            else
            {
                myRb2d.velocity = Vector2.zero;
            }
        }
    }

    private Vector2 RemapScreenPosition(Vector2 position)
    {
        float x = (position.x / Screen.width) * mainCamera.pixelWidth;
        float y = (position.y / Screen.height) * mainCamera.pixelHeight;
        return new Vector2(x, y);
    }
}
