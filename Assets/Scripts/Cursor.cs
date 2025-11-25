using UnityEngine;

public class Cursor : MonoBehaviour
{
    void Update()
    {
        //マウスのスクリーン座標をワールド座標に変換
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        //スクリーンのサイズを取得
        Vector3 min = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 max = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        //スクリーン外にでないように制限
        mousePos.x = Mathf.Clamp(mousePos.x, min.x, max.x);
        mousePos.y = Mathf.Clamp(mousePos.y, min.y, max.y);

        transform.position = mousePos; //カーソルの移動
    }
}