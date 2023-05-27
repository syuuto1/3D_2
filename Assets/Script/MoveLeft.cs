using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed = 30;//Groundが動く速さ
    PlayerController PlayerControllerScript;
    float lefBound = -15;//左の限界点
    //PlayerControllerというも、Rigidbodyとかと同様「クラス」なので型として宣言できる
    //＜型名＞　変数　の順序
    public void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
       if(PlayerControllerScript.gameOver == false)//ゲームオーバー状態でなければ、あってなくても同じ意味
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
       if(transform.position.x < lefBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}
