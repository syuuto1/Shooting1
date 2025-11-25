using UnityEngine;

public class Player : MonoBehaviour
{
    private float shootTimer; //弾発射のタイマー

    [SerializeField] GameObject bulletPrefab; //弾のプレハブ
    [SerializeField] float shootInterval;     //発射インターバル

    void Update()
    {
        shootTimer += Time.deltaTime; //前フレームからの経過時間を加算


        //マウス方向を向く
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Vector2 direction = mouse - transform.position;
        transform.up = direction;

        //タイマーが発射間隔を超えたら弾を発射
        if (shootTimer >= shootInterval)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            shootTimer = 0;
        }
    }
}