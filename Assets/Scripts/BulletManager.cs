using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> bulletPool;
    public GameObject bulletPrefab;
    public int bulletNum = 30;
    public Transform bulletParent;
    public int bulletCount = 0;
    public int activeBullets = 0;
    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>();
        BuildBulletPool();
    }


    void BuildBulletPool()
    {
        for(int i = 0; i < bulletNum; i++)
        {
            CreateBullet();
        }
        bulletCount = bulletPool.Count;
    }
    private void CreateBullet()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false);
        bullet.transform.SetParent(bulletParent);
        bulletPool.Enqueue(bullet);
    }
    public GameObject GetBullet(Vector2 pos, BulletDirection dir)
    {
        if(bulletPool.Count < 1)
        {
            CreateBullet();
        }
        
        var bullet = bulletPool.Dequeue();
        bullet.SetActive(true);
        bullet.transform.position = pos;
        bullet.GetComponent<BulletBehaviour>().SetDirection(dir);

        bulletCount = bulletPool.Count;
        activeBullets++;

        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
        bulletCount = bulletPool.Count;
        activeBullets--;
    }
}
