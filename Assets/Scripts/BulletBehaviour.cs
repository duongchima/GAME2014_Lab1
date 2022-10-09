using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
[System.Serializable]
public struct ScreenBounds
{
    public Boundary horizontal;
    public Boundary vertical;
}
public class BulletBehaviour: MonoBehaviour
{
    public float speed;
    public BulletDirection bulletDirection;
    public Vector3 velocity;
    public ScreenBounds bounds;
    public UI_Score score;
    public BulletManager bulletManager;
    private void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        SetDirection(bulletDirection);
        score = FindObjectOfType<UI_Score>();
    }



    private void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += velocity * Time.deltaTime;
    }

    void CheckBounds()
    {
        if ((transform.position.x > bounds.horizontal.max) ||
            (transform.position.x < bounds.horizontal.min) ||
            (transform.position.y > bounds.vertical.max) ||
            (transform.position.y < bounds.vertical.min))
        {
            bulletManager.ReturnBullet(this.gameObject);
        }
    }
    public void SetDirection(BulletDirection direction)
    {
        switch (direction)
        {
            case BulletDirection.UP:
                velocity = Vector3.up * speed;
                break;
            case BulletDirection.RIGHT:
                velocity = Vector3.right * speed;
                break;
            case BulletDirection.DOWN:
                velocity = Vector3.down * speed;
                break;
            case BulletDirection.LEFT:
                velocity = Vector3.left * speed;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bulletManager.ReturnBullet(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("drops"))
        {
            Destroy(collision.gameObject);
            score.AddPoints(5);
        }
    }
}