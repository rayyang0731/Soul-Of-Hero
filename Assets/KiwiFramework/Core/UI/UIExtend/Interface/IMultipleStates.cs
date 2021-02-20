namespace KiwiFramework.UI
{
    /// <summary>
    /// 多状态接口
    /// </summary>
    public interface IMultipleStates<T>
    {
        int DefaultState { get; }
        /// <summary>
        /// 本地状态是否受到父物体状态印象
        /// </summary>
        bool AffectedByParent { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>
        /// <value></value>
        int CurrentState { get; }
        /// <summary>
        /// 初始化状态数据
        /// </summary>
        void Initialize();
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="state">状态索引</param>
        /// <param name="force">是否强制设置状态索引,可缺省,默认为false</param>
        /// <returns>修改状态是否成功</returns>
        bool SetState(int state, bool force = false);
        /// <summary>
        /// 添加/插入状态
        /// </summary>
        /// <param name="data">要添加/插入的状态数据</param>
        /// <param name="insetIndex">新状态要插入的索引,可缺省,默认为-1,状态添加到末尾</param>
        /// <returns>添加/插入状态是否成功</returns>
        void AddState(T data, int insetIndex = -1);
        /// <summary>
        /// 修改状态数据
        /// </summary>
        /// <param name="index">目标状态索引值</param>
        /// <param name="data">要修改的状态数据</param>
        /// <returns>修改数据状态是否成功</returns>
        bool ChangeStateData(int index, T data);
        /// <summary>
        /// 重置为默认状态
        /// </summary>
        /// <returns>重置状态是否成功</returns>
        bool ResetState();
        /// <summary>
        /// 清除全部状态
        /// </summary>
        /// <returns>清除状态是否成功</returns>
        bool ClearState();
    }
}