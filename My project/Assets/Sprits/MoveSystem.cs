using UnityEngine;

namespace white
{
    /// <summary>
    /// ���ʨt�ΡG����󲾰ʻP�ʵe
    /// </summary>
    public class MoveSystem : MonoBehaviour
    {
        #region ���
        [SerializeField, Header("���ʳt��"), Range(0, 100)]
        private float speed = 3.5f;
        [SerializeField, Header("���ʰѼƦW��")]
        private string parMove = "�}���]�B";

        private Animator ani;
        private Rigidbody2D rig;
        #endregion

        #region ��k
        ///<summary>
        ///���ʤ�k
        ///</summary>
        private void Move()
        {
            float h = Input.GetAxis("Horizontal");
            rig.velocity = new Vector2(h * speed, rig.velocity.y);
            ani.SetBool(parMove, h != 0);

            //�p�G ��������� �p��0.1�N���X
            if (Mathf.Abs(h) < 0.1f) return;

            float yAngle = h > 0 ? 0 : 180;
            transform.eulerAngles = new Vector3(0, yAngle, 0);
        }
        #endregion

        #region �ƥ�
        private void Awake()
        {
            //�x����k�@����������int�Bfloat�BVector2�BAnimator...
            //GetComponent<���������()
            //�@�ΡG���P���}���P�˪���W���ʵe����
            Animation Animation1 = GetComponent<Animation>();
            Animation animation1 = Animation1;
            rig = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }
        #endregion
    }
}