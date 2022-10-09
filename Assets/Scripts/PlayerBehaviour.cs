using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 3.0f;
    public ScreenBounds bounds;
    Camera camera;
    public bool usingMobileInput = false;
    public UI_Score score;

    public Transform bulletSpawnPoint;
    public float fireRate = 0.2f;
    public BulletManager bulletManager;
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();

        camera = Camera.main;

        usingMobileInput = Application.platform == RuntimePlatform.Android ||
                            Application.platform == RuntimePlatform.IPhonePlayer;

        score = FindObjectOfType<UI_Score>();

        InvokeRepeating("FireBullets", 0.0f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (usingMobileInput)
        {
            MobileInput();
        }
        else
        {
            KeyboardInput();
        }
        Move();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("drops"))
        {
            Destroy(other.gameObject);
            score.LosePonts(2);
        }
    }
    public void Move()
    {
        float clampedHorizontalPos = Mathf.Clamp(transform.position.x, bounds.horizontal.min, bounds.horizontal.max);
        float clampedVerticalPos = Mathf.Clamp(transform.position.y, bounds.vertical.min, bounds.vertical.max);
        transform.position = new Vector2(clampedHorizontalPos, clampedVerticalPos);
    }
    public void MobileInput()
    {
        foreach(var touch in Input.touches)
        {
            var dest = camera.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, dest, Time.deltaTime * speed);
        }
    }
    public void KeyboardInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        transform.position = new Vector2(transform.position.x + x, transform.position.y + y);
    }

    void FireBullets()
    {
        var bullet = bulletManager.GetBullet(bulletSpawnPoint.position, BulletDirection.UP);
    }
}
