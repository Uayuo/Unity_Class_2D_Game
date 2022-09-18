using UnityEngine;

namespace white
{
    /// <summary>
    /// 移動系統：控制物件移動與動畫
    /// </summary>
    public class MoveSystem : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("移動速度"), Range(0, 100)]
        private float speed = 3.5f;
        [SerializeField, Header("移動參數名稱")]
        private string ParMove = "開關跑步";

        private Animator ani;
        private Rigidbody2D rig;
        #endregion

        #region 方法
        ///<summary>
        ///移動方法
        ///</summary>
        private void Move()
        {
            float h = Input.GetAxis("Horizontal");
            rig.velocity = new Vector2(h * speed, rig.velocity.y);

            ani.SetBool(ParMove, h != 0);

            //如果 水平絕對值 小於0.1就跳出
            if (Mathf.Abs(h) < 0.1f) return;

            float yAngle = h > 0 ? 0 : 180;
            transform.eulerAngles = new Vector3(0 , yAngle , 0);
        }
        #endregion

        #region 事件
        private void Awake()
        {
            ///型方法　指任何類型int、float、Vector2、Animator...
            //GetComponent<資料類型＞()
            //作用：抓到與此腳本同樣物件上的動畫元件

            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }
        #endregion
    }
}