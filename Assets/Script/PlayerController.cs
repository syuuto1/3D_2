using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    Rigidbody rb; // Rididbody
    [SerializeField] float gravityModifier;//重力値調整用
    [SerializeField] float jumpForce;//ジャンプ力
    [SerializeField] bool isOnGround;//地面についているか

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround) //スペースが押されて、かつ、地面にいたら
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);//上への力を加える
            isOnGround = false;//ジャンプした＝地面にいない
        }
    }
    private void OnCollisionEnter(Collision collision)//衝突が起きたら実行
    {
        if(collision.gameObject.CompareTag("Ground"))//ぶつかった相手(collision)のタグがGroundなら
        isOnGround = true;//地面についている状態に変更
    }
}