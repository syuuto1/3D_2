using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
        //public GameObject player; // 玉のオブジェクト

        //public GameObject Enemy;

        //private Vector3 offset; // 玉からカメラまでの距離


        [SerializeField] private GameObject player;
        private Rigidbody rb;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            //毎フレーム力を加える
            rb.AddForce(player.transform.position - transform.position);
            //何もついてないtransform.positionは、アタッチされている
            //物体の座標になる
            
        }
}
