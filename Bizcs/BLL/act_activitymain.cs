using System.Data;

namespace app_act.Bizcs.BLL
{
    public class act_activitymain
    {
        private readonly app_act.Bizcs.DAL.act_activitymain dal = new Bizcs.DAL.act_activitymain();
        public act_activitymain()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int actID)
        {
            return dal.Exists(actID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Bizcs.Model.act_activitymain model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Bizcs.Model.act_activitymain model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int actID)
        {

            return dal.Delete(actID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string actIDlist)
        {
            return dal.DeleteList(actIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Bizcs.Model.act_activitymain GetModel(int actID)
        {

            return dal.GetModel(actID);
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
        public List<Bizcs.Model.act_activitymain> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Bizcs.Model.act_activitymain> DataTableToList(DataTable dt)
        {
            List<Bizcs.Model.act_activitymain> modelList = new List<Bizcs.Model.act_activitymain>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Bizcs.Model.act_activitymain model;
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

        #endregion  ExtensionMethod
    }
}
