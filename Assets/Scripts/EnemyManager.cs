using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefabs; //障害物プレハブ
    public GameObject[] enemyPrefabs;     //敵プレハブ

    public float obstaclesinterval;       //障害物のスポーンインターバル
    public float enemyinterval;           //敵のスポーンインターバル
    float obstaclesSpawnTimer;            //障害物スポーンタイマー
    float enemySpawnTimer;                //敵の障害物スポーンタイマー

    [SerializeField] float SpawnRange_x;  //X軸スポーン範囲
    [SerializeField] float SpawnRange_y;  //Y軸スポーン位置

    void Update()
    {
        //各々のタイマー
        obstaclesSpawnTimer += Time.deltaTime;
        enemySpawnTimer += Time.deltaTime;

        //障害物のスポーン
        if (obstaclesSpawnTimer >= obstaclesinterval)
        {
            obstaclesSpawn();
            obstaclesSpawnTimer = 0;
        }
        
        //敵のスポーン
        if (enemySpawnTimer >= enemyinterval)
        {
            enemySpawn();
            enemySpawnTimer = 0;
        }
    }

    /// <summary>
    /// 障害物のスポーン
    /// </summary>
    void obstaclesSpawn()
    {
        //スポーン位置をランダム指定
        float x = Random.Range(-SpawnRange_x, SpawnRange_x);
        float y = SpawnRange_y;
        //ランダムに障害物をスポーン
        int obstacles_index = Random.Range(0, obstaclesPrefabs.Length);
        GameObject obstacles = Instantiate(obstaclesPrefabs[obstacles_index], new Vector3(x, y, 0), Quaternion.identity);
    }

    /// <summary>
    /// 敵のスポーン
    /// </summary>
    void enemySpawn()
    {
        //スポーン位置をランダム指定
        float x = Random.Range(-SpawnRange_x, SpawnRange_x);
        float y = SpawnRange_y;

        //ランダムに敵をスポーン
        int enemy_index = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyPrefab = enemyPrefabs[enemy_index];
        GameObject enemyObj = Instantiate(enemyPrefab, new Vector3(x, y, 0), Quaternion.identity);

        //生成した敵のSpriteRendererとEnemyスクリプトを取得
        SpriteRenderer sr = enemyObj.GetComponent<SpriteRenderer>();
        Enemy enemyScript = enemyObj.GetComponent<Enemy>();

        //敵のスプライトをランダムに変更
        if (enemyScript.EnemySprites.Length > 0)
        {
            int spriteIndex = Random.Range(0, enemyScript.EnemySprites.Length);
            sr.sprite = enemyScript.EnemySprites[spriteIndex];
        }
    }
}