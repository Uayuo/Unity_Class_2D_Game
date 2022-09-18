using UnityEngine;

namespace white
{
	///<summary>
	///跳躍系統：腳色跳躍與動畫更新
	///</summary>
	public class JumpSystem : MonoBehaviour
	{
		#region 資料
		[SerializeField, Header("跳躍高度"), Range(0, 10000)]
		private float jump = 5;
		[SerializeField, Header("跳躍參數名稱")]
		private string parJump = "跳躍開關";

		private Animation ani;
		private Rigidbody2D rig;
		#endregion

		#region 跳躍資料
		[SerializeField, Header("檢查地板顏色")]
		private Color cheakGroundColor = new Color(1, 0, 0.2f, 0.3f);


		[SerializeField] private Vector3 cheakGroundsize;
		[SerializeField] private Vector3 cheakGroundoffset;
		[SerializeField, Header("檢查地板圖層")]
		private LayerMask checkGroundLaver;
		[SerializeField]private bool isGrounded;
		#endregion
		#region 事件
		private void Awake()
		{
			ani = GetComponent<Animation>();
			rig = GetComponent<Rigidbody2D>();
		}
		#endregion
		private void OnDrawGizmos()
		{
			Gizmos.color = cheakGroundColor;
			Gizmos.DrawCube(
				transform.position + cheakGroundoffset,
				cheakGroundsize);
		}

		private void Update()
		{
			CheckGround();
			Jump();
		}
		#region 方法
		///<summary>
		///檢查地板
		///</summary>
		private void CheckGround()
		{
			Collider2D hit = Physics2D.OverlapBox(
				transform.position + cheakGroundoffset,
				cheakGroundsize, 0,checkGroundLaver);
			//print("<color=red>碰到的物件" + hit + "/color");
			isGrounded = hit;
		}
		#endregion

		///<summary>
		///跳躍
		///</summary>
		private void Jump()
		{
			//如果在地板上 並且 按下空白鍵 就跳躍
			if (isGrounded && Input.GetKeyDown(KeyCode.Space))
			{
				rig.AddForce(new Vector2(0, jump));
			}
			
		}
	}
}