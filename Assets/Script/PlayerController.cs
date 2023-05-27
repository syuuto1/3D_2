using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    Rigidbody rb; // Rididbody
    [SerializeField] float gravityModifier;//重力値調整用
    [SerializeField] float jumpForce;//ジャンプ力
    [SerializeField] bool isOnGround;//地面についているか
    public bool gameOver; //なにも書かなければprivate
    Animator playerAnim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) //スペースが押されて、かつ、地面にいたら、ゲームオーバーでないなら
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);//上への力を加える
            isOnGround = false;//ジャンプした＝地面にいない
            playerAnim.SetTrigger("Jump_trig");//ジャンプアニメ発動準備

        }
    }
    private void OnCollisionEnter(Collision collision)//衝突が起きたら実行
    {
        if(collision.gameObject.CompareTag("Ground"))//ぶつかった相手(collision)のタグがGroundなら
        {
            isOnGround = true;//地面についている状態に変更
        }
        if (collision.gameObject.CompareTag("Obstacle"))//ぶつかった相手(collision)のタグがGroundなら
        {
            gameOver = true;//ゲームオーバーにしてみる
            Debug.Log("Game Over !!! ");//プレイ中にConsoleに表示される
            playerAnim.SetBool("Death_b",true);//ここで死亡状態bにする（Death_bとかいうのは本来自分で定義できる）
            playerAnim.SetInteger("DeathType_int",1);//integerは整数の意味死亡のタイプ？を1番目のやつにするような
            
        }
        
    }
}