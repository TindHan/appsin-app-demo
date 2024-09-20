using DBUtility;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace app_act.Bizcs.DAL
{
    public class act_signup
    {
        public act_signup()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int signID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from act_signup");
            strSql.Append(" where signID=@signID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@signID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = signID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Bizcs.Model.act_signup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into act_signup(");
            strSql.Append("actID,psnPK,signTime,isPay,isConfirm,signStatus)");
            strSql.Append(" values (");
            strSql.Append("@actID,@psnPK,@signTime,@isPay,@isConfirm,@signStatus)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@actID", MySqlDbType.Int32,4),
                    new MySqlParameter("@psnPK", MySqlDbType.VarChar,50),
                    new MySqlParameter("@signTime", MySqlDbType.DateTime),
                    new MySqlParameter("@isPay", MySqlDbType.Int32,4),
                    new MySqlParameter("@isConfirm", MySqlDbType.Int32,4),
                    new MySqlParameter("@signStatus", MySqlDbType.Int32,4)};
            parameters[0].Value = model.actID;
            parameters[1].Value = model.psnPK;
            parameters[2].Value = model.signTime;
            parameters[3].Value = model.isPay;
            parameters[4].Value = model.isConfirm;
            parameters[5].Value = model.signStatus;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Bizcs.Model.act_signup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update act_signup set ");
            strSql.Append("actID=@actID,");
            strSql.Append("psnPK=@psnPK,");
            strSql.Append("signTime=@signTime,");
            strSql.Append("isPay=@isPay,");
            strSql.Append("isConfirm=@isConfirm,");
            strSql.Append("signStatus=@signStatus");
            strSql.Append(" where signID=@signID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@actID", MySqlDbType.Int32,4),
                    new MySqlParameter("@psnPK", MySqlDbType.VarChar,50),
                    new MySqlParameter("@signTime", MySqlDbType.DateTime),
                    new MySqlParameter("@isPay", MySqlDbType.Int32,4),
                    new MySqlParameter("@isConfirm", MySqlDbType.Int32,4),
                    new MySqlParameter("@signStatus", MySqlDbType.Int32,4),
                    new MySqlParameter("@signID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.actID;
            parameters[1].Value = model.psnPK;
            parameters[2].Value = model.signTime;
            parameters[3].Value = model.isPay;
            parameters[4].Value = model.isConfirm;
            parameters[5].Value = model.signStatus;
            parameters[6].Value = model.signID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int signID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from act_signup ");
            strSql.Append(" where signID=@signID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@signID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = signID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string signIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from act_signup ");
            strSql.Append(" where signID in (" + signIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Bizcs.Model.act_signup GetModel(int signID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 signID,actID,psnPK,signTime,isPay,isConfirm,signStatus from act_signup ");
            strSql.Append(" where signID=@signID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@signID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = signID;

            Bizcs.Model.act_signup model = new Bizcs.Model.act_signup();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Bizcs.Model.act_signup DataRowToModel(DataRow row)
        {
            Bizcs.Model.act_signup model = new Bizcs.Model.act_signup();
            if (row != null)
            {
                if (row["signID"] != null && row["signID"].ToString() != "")
                {
                    model.signID = int.Parse(row["signID"].ToString());
                }
                if (row["actID"] != null && row["actID"].ToString() != "")
                {
                    model.actID = int.Parse(row["actID"].ToString());
                }
                if (row["psnPK"] != null)
                {
                    model.psnPK = row["psnPK"].ToString();
                }
                if (row["signTime"] != null && row["signTime"].ToString() != "")
                {
                    model.signTime = DateTime.Parse(row["signTime"].ToString());
                }
                if (row["isPay"] != null && row["isPay"].ToString() != "")
                {
                    model.isPay = int.Parse(row["isPay"].ToString());
                }
                if (row["isConfirm"] != null && row["isConfirm"].ToString() != "")
                {
                    model.isConfirm = int.Parse(row["isConfirm"].ToString());
                }
                if (row["signStatus"] != null && row["signStatus"].ToString() != "")
                {
                    model.signStatus = int.Parse(row["signStatus"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select signID,actID,psnPK,signTime,isPay,isConfirm,signStatus ");
            strSql.Append(" FROM act_signup ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" signID,actID,psnPK,signTime,isPay,isConfirm,signStatus ");
            strSql.Append(" FROM act_signup ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM act_signup ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.signID desc");
            }
            strSql.Append(")AS Row, T.*  from act_signup T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
