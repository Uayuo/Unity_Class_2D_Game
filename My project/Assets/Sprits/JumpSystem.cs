using UnityEngine;

namespace white
{
	///<summary>
	///���D�t�ΡG�}����D�P�ʵe��s
	///</summary>
	public class JumpSystem : MonoBehaviour
	{
		#region ���
		[SerializeField, Header("���D����"), Range(0, 10000)]
		private float jump = 5;
		[SerializeField, Header("���D�ѼƦW��")]
		private string parJump = "���D�}��";

		private Animation ani;
		private Rigidbody2D rig;
		#endregion

		#region ���D���
		[SerializeField, Header("�ˬd�a�O�C��")]
		private Color cheakGroundColor = new Color(1, 0, 0.2f, 0.3f);


		[SerializeField] private Vector3 cheakGroundsize;
		[SerializeField] private Vector3 cheakGroundoffset;
		[SerializeField, Header("�ˬd�a�O�ϼh")]
		private LayerMask checkGroundLaver;
		[SerializeField]private bool isGrounded;
		#endregion
		#region �ƥ�
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
		#region ��k
		///<summary>
		///�ˬd�a�O
		///</summary>
		private void CheckGround()
		{
			Collider2D hit = Physics2D.OverlapBox(
				transform.position + cheakGroundoffset,
				cheakGroundsize, 0,checkGroundLaver);
			//print("<color=red>�I�쪺����" + hit + "/color");
			isGrounded = hit;
		}
		#endregion

		///<summary>
		///���D
		///</summary>
		private void Jump()
		{
			//�p�G�b�a�O�W �åB ���U�ť��� �N���D
			if (isGrounded && Input.GetKeyDown(KeyCode.Space))
			{
				rig.AddForce(new Vector2(0, jump));
			}
			
		}
	}
}