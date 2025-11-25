using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float movespeed; //プレイヤーへの移動速度
    Transform player;

    public Sprite[] EnemySprites;

    [SerializeField] float minspeed_x; //X軸の最小値
    [SerializeField] float maxspeed_x; //X軸の最大値
    [SerializeField] float distance_x; //X軸の移動距離

    float Speed;                   //X軸の移動スピード
    float Distance;                //X軸の移動範囲

    void Start()
    {
        //プレイヤーを取得
        player = GameObject.FindWithTag("Player").transform;

        //一度だけランダム値設定
        Speed = Random.Range(minspeed_x, maxspeed_x);
        Distance = Random.Range(-distance_x, distance_x);

    }

    void Update()
    {
        //プレイヤー方向へ進む
        Vector2 dir = (player.position - transform.position).normalized;
        transform.Translate(dir * movespeed * Time.deltaTime);

        //左右の移動
        float offsetX = Mathf.Cos(Time.time * Speed) * Distance;
        transform.position += new Vector3(offsetX * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("ResultScene", LoadSceneMode.Single);
        }
    }
}
