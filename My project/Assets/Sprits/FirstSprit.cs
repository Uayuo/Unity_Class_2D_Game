using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace white
{

    ///<summary>
    ///類型摘要
    ///</summary>
    public class FirstScript : MonoBehaviour
    {
        ///<summary>
        ///摘要，簡短說明，不是必要但很重要
        ///</summary>
        private void Start()
        {
            print("哈囉，沃德");
        }

        ///<summary>
        ///更新事件
        ///</summary>
        private void Updata()
        {
            print("更新事件");
        }
        //單行註解：標註說明
        //程式區塊說明
        #region 程式區塊
        /*多行註解
         *多行註解
         *多行註解
         *多行註解
         */
        #endregion
    }
}
