using UnityEngine;
using UnityEngine.SceneManagement;


public class Obstacles : MonoBehaviour
{
    public float speed; //移動速度
    Transform player;

    void Start()
    {
        //プレイヤーの位置取得
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        //プレイヤー方向へ移動
        Vector2 dir = (player.position - transform.position).normalized;
        transform.Translate(dir * speed * Time.deltaTime);
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