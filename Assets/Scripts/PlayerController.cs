using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 20;

    public Text scoreText;  //スコアのUI
    public Text winText;    //リザルトのUI

    private Rigidbody rb;
    private int score;  //スコア

	// Use this for initialization
	void Start () {

        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();

        //UIを初期化
        score = 0;
        SetCountText();
        winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        //カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        //カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        //Rigidbodyに力を与えて玉を動かす
        rb.AddForce(movement * speed);

	}

    //玉が他のオブジェクトにぶつかった時に呼び出される
    private void OnTriggerEnter(Collider other)
    {
        //ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("PickUp"))
        {
            //アイテムを非表示にする
            other.gameObject.SetActive(false);

            //スコアを加算します
            score = score + 1;

            //UIの表示を更新します
            SetCountText();
        }
    }

    //UIの表示を更新する
    void SetCountText()
    {
        //スコアの表示を更新
        scoreText.text = "Count : " + score.ToString();

        //すべての収集アイテムを獲得した場合
        if(score >= 12)
        {
            //リザルトの表示を更新
            winText.text = "You Win!!";
        }
    }
}