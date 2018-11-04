using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 20;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {

        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();		
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
}
