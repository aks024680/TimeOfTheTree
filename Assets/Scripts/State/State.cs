using UnityEngine;

namespace tott
{
    /// <summary>
    /// 狀態機
    /// </summary>
    public abstract class State : MonoBehaviour
    {
        /// <summary>
        /// 執行當前的狀態
        /// </summary>
        /// <returns>當前的狀態</returns>
        public abstract State RunCurrentState();

        protected Animator ani { get;private set; }

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }
    }
}

