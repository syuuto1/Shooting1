using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;     //移動速度
    public float lifetime;  //削除時間


    void Start()
    {
        Destroy(gameObject, lifetime); //一定時間で削除
    }


    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); //前方向に移動
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //敵キルカウント
            GameManager.Instance.AddKill();

            //敵と自分を削除
            Destroy(other.gameObject);
            Destroy(gameObject);

            Debug.Log("hit");
        }
    }
}