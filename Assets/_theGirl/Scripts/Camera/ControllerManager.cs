using UnityEngine;
namespace TSUTwoD
{
    public class ControllerManager : MonoBehaviour
    {
        #region 資料
        [SerializeField, Range(3, 500), Header("移動速度")]
        private float speed = 3.5f;
        private Rigidbody rig;
        [SerializeField, Range(0.1f, 1500), Header("跳躍力道")]
        private float jumpForce = 500f;
        bool isGrounded;
        #endregion

        #region 事件
        private void Awake()
        {
            rig = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            MoveAndFlip();
            Jump();
        }
        #endregion

        #region 方法
        private void Jump()
        {
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))  // 只有在地板上並且按下空格時才能跳躍
            {
                rig.AddForce(Vector3.up * jumpForce);
            }
        }
        private void MoveAndFlip()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            rig.velocity = new Vector3(h * speed, rig.velocity.y, v * speed);
        }
        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))  // 碰撞到地板時
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))  // 离开地板时
            {
                isGrounded = false;
            }
        }
        #endregion
    }
}
