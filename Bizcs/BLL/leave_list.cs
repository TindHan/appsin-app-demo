using MySql.Data.MySqlClient;
using System.Data;

namespace app_act.Bizcs.BLL
{
    public class leave_list
    {
        private readonly Bizcs.DAL.leave_list dal = new Bizcs.DAL.leave_list();
        public leave_list()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int leaveID)
        {
            return dal.Exists(leaveID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Bizcs.Model.leave_list model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Bizcs.Model.leave_list model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int leaveID)
        {

            return dal.Delete(leaveID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string leaveIDlist)
        {
            return dal.DeleteList(leaveIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Bizcs.Model.leave_list GetModel(int leaveID)
        {

            return dal.GetModel(leaveID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Bizcs.Model.leave_list> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Bizcs.Model.leave_list> DataTableToList(DataTable dt)
        {
            List<Bizcs.Model.leave_list> modelList = new List<Bizcs.Model.leave_list>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Bizcs.Model.leave_list model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataSet GetList(string strWhere, params MySqlParameter[] parms)
        {
            return dal.GetList(strWhere, parms);
        }
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, params MySqlParameter[] parms)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex, parms);
        }
        public bool sycnApproveStatus(string leavePK, int approveStatus)
        {
            return dal.sycnApproveStatus(leavePK, approveStatus);
        }
        public bool sycnLeavePK(string leavePK, int leaveID)
        {
            return dal.sycnLeavePK(leavePK, leaveID);
        }
        #endregion  ExtensionMethod
    }
}
