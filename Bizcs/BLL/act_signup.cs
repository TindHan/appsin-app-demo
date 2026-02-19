using MySql.Data.MySqlClient;
using System.Data;

namespace app_act.Bizcs.BLL
{
    public class act_signup
    {
        private readonly Bizcs.DAL.act_signup dal = new Bizcs.DAL.act_signup();
        public act_signup()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int signID)
        {
            return dal.Exists(signID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Bizcs.Model.act_signup model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Bizcs.Model.act_signup model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int signID)
        {

            return dal.Delete(signID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string signIDlist)
        {
            return dal.DeleteList(signIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Bizcs.Model.act_signup GetModel(int signID)
        {

            return dal.GetModel(signID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetList(string strWhere, params MySqlParameter[] parms)
        {
            return dal.GetList(strWhere, parms);
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
        public List<Bizcs.Model.act_signup> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Bizcs.Model.act_signup> DataTableToList(DataTable dt)
        {
            List<Bizcs.Model.act_signup> modelList = new List<Bizcs.Model.act_signup>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Bizcs.Model.act_signup model;
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

        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataSet exportList(string strWhere)
        {
            return dal.exportList(strWhere);
        }
        public DataSet exportList(string strWhere, params MySqlParameter[] parms)
        {
            return dal.exportList(strWhere, parms);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string subStrWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, subStrWhere, orderby, startIndex, endIndex);
        }

        public DataSet GetListByPage(string strWhere, string subStrWhere, string orderby, int startIndex, int endIndex, params MySqlParameter[] parms)
        {
            return dal.GetListByPage(strWhere, subStrWhere, orderby, startIndex, endIndex, parms);
        }

        #endregion  ExtensionMethod
    }
}
