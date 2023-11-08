using Fungus;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace tott
{
    /// <summary>
    /// 遊走狀態
    /// </summary>
    public class StateWander : State
    {
        [SerializeField, Header("等待狀態")]
        private StateIdle stateIdle;
        [SerializeField, Header("是否回復等待")]
        private bool startIdle;
        [SerializeField, Header("等待狀態的隨機時間範圍")]
        private Vector2 rangeWanderTime = new Vector2(0, 10);
        [SerializeField, Header("左邊座標位移")]
        private float offsetLeft = -2;
        [SerializeField, Header("右邊座標位移")]
        private float offsetRight = 2;

        [SerializeField, Header("移動速度"), Range(0, 5)]
        private float speed = 1.5f;

        /// <summary>
        /// 方向&#xff1a;右邊 +1&#xff0c;左邊 -1
        /// </summary>
        private int direction = 1;

        private Vector3 pointLeft => pointOriginal + Vector3.right * offsetLeft;
        private Vector3 pointRight => pointOriginal + Vector3.right * offsetRight;

        

        private string parWalk = "parWalk";
        private Rigidbody rig;


        private float timeWander;
        private float timer;

        [SerializeField, Header("角色的初始座標")]
        private Vector3 pointOriginal;

        [ContextMenu("取得角色原始座標")]
        private void GetOriginalPoint()
        {
            pointOriginal = transform.position;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.8f, 0.1f, 0.5f);
            Gizmos.DrawSphere(pointLeft, 0.1f);
            Gizmos.DrawSphere(pointRight, 0.1f);
        }

        private void Start()
        {
            rig = GetComponent<Rigidbody>();
            timeWander = Random.Range(rangeWanderTime.x, rangeWanderTime.y);
        }

        public override State RunCurrentState()
        {
            if (Vector3.Distance(transform.position, pointRight) < 0.5f)
            {
                direction = -1;
                transform.eulerAngles = new Vector3(0, 270, 0);
            }
            if (Vector3.Distance(transform.position, pointLeft) < 0.5f)
            {
                direction = 1;
                transform.eulerAngles = new Vector3(0,90,0);
            }

            rig.velocity = new Vector2(direction * speed, rig.velocity.y);
            ani.SetBool(parWalk, true);

            timer += Time.deltaTime;
            // print($"<color=#69f>計時器&#xff1a;{timer}</color>");

            if (timer >= timeWander) startIdle = true;

            if (startIdle)
            {
                return stateIdle;
            }
            else
            {
                return this;
            }
        }
    }
}

