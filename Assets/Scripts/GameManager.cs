using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //インスタンス

    [SerializeField] int Count; //目標カウント
    public int killCount = 0;   //現在のキルカウント
    public Text killText;       //UIテキスト

    void Awake()
    {
        // シングルトン（どこからでもアクセス可）
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    public void AddKill()
    {
        killCount++;
        killText.text = "Kill: " + killCount; //キルカウントテキスト
    }

    private void Update()
    {
        //一定キル後にリザルトへ
        if(killCount >= Count)
        {
            SceneManager.LoadScene("ResultScene", LoadSceneMode.Single);
        }
    }
}
