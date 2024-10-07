using DBUtility;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace app_act.Bizcs.DAL
{
    public class act_activitymain
    {
        public act_activitymain()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int actID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from act_activitymain");
            strSql.Append(" where actID=@actID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@actID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = actID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Bizcs.Model.act_activitymain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into act_activitymain(");
            strSql.Append("actName,actDesc,actStartTime,actEndTime,signupStartTime,signupEndTime,actType,actWay,actUrl,actAddr,actMemo1,actMemo2,actMemo3,actMemo4,actMemo5,actStatus)");
            strSql.Append(" values (");
            strSql.Append("@actName,@actDesc,@actStartTime,@actEndTime,@signupStartTime,@signupEndTime,@actType,@actWay,@actUrl,@actAddr,@actMemo1,@actMemo2,@actMemo3,@actMemo4,@actMemo5,@actStatus)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@actName", MySqlDbType.VarChar,200),
                    new MySqlParameter("@actDesc", MySqlDbType.Text),
                    new MySqlParameter("@actStartTime", MySqlDbType.DateTime),
                    new MySqlParameter("@actEndTime", MySqlDbType.DateTime),
                    new MySqlParameter("@signupStartTime", MySqlDbType.DateTime),
                    new MySqlParameter("@signupEndTime", MySqlDbType.DateTime),
                    new MySqlParameter("@actType", MySqlDbType.VarChar,50),
                    new MySqlParameter("@actWay", MySqlDbType.VarChar,50),
                    new MySqlParameter("@actUrl", MySqlDbType.VarChar,500),
                    new MySqlParameter("@actAddr", MySqlDbType.VarChar,500),
                    new MySqlParameter("@actMemo1", MySqlDbType.Int32,4),
                    new MySqlParameter("@actMemo2", MySqlDbType.Int32,4),
                    new MySqlParameter("@actMemo3", MySqlDbType.Int32,4),
                    new MySqlParameter("@actMemo4", MySqlDbType.Int32,4),
                    new MySqlParameter("@actMemo5", MySqlDbType.Int32,4),
                    new MySqlParameter("@actStatus", MySqlDbType.Int32,4)};
            parameters[0].Value = model.actName;
            parameters[1].Value = model.actDesc;
            parameters[2].Value = model.actStartTime;
            parameters[3].Value = model.actEndTime;
            parameters[4].Value = model.signupStartTime;
            parameters[5].Value = model.signupEndTime;
            parameters[6].Value = model.actType;
            parameters[7].Value = model.actWay;
            parameters[8].Value = model.actUrl;
            parameters[9].Value = model.actAddr;
            parameters[10].Value = model.actMemo1;
            parameters[11].Value = model.actMemo2;
            parameters[12].Value = model.actMemo3;
            parameters[13].Value = model.actMemo4;
            parameters[14].Value = model.actMemo5;
            parameters[15].Value = model.actStatus;

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
        public bool Update(Bizcs.Model.act_activitymain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update act_activitymain set ");
            strSql.Append("actName=@actName,");
            strSql.Append("actDesc=@actDesc,");
            strSql.Append("actStartTime=@actStartTime,");
            strSql.Append("actEndTime=@actEndTime,");
            strSql.Append("signupStartTime=@signupStartTime,");
            strSql.Append("signupEndTime=@signupEndTime,");
            strSql.Append("actType=@actType,");
            strSql.Append("actWay=@actWay,");
            strSql.Append("actUrl=@actUrl,");
            strSql.Append("actAddr=@actAddr,");
            strSql.Append("actMemo1=@actMemo1,");
            strSql.Append("actMemo2=@actMemo2,");
            strSql.Append("actMemo3=@actMemo3,");
            strSql.Append("actMemo4=@actMemo4,");
            strSql.Append("actMemo5=@actMemo5,");
            strSql.Append("actStatus=@actStatus");
            strSql.Append(" where actID=@actID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@actName", MySqlDbType.VarChar,200),
                    new MySqlParameter("@actDesc", MySqlDbType.Text),
                    new MySqlParameter("@actStartTime", MySqlDbType.DateTime),
                    new MySqlParameter("@actEndTime", MySqlDbType.DateTime),
                    new MySqlParameter("@signupStartTime", MySqlDbType.DateTime),
                    new MySqlParameter("@signupEndTime", MySqlDbType.DateTime),
                    new MySqlParameter("@actType", MySqlDbType.VarChar,50),
                    new MySqlParameter("@actWay", MySqlDbType.VarChar,50),
                    new MySqlParameter("@actUrl", MySqlDbType.VarChar,500),
                    new MySqlParameter("@actAddr", MySqlDbType.VarChar,500),
                    new MySqlParameter("@actMemo1", MySqlDbType.Int32,4),
                    new MySqlParameter("@actMemo2", MySqlDbType.Int32,4),
                    new MySqlParameter("@actMemo3", MySqlDbType.Int32,4),
                    new MySqlParameter("@actMemo4", MySqlDbType.Int32,4),
                    new MySqlParameter("@actMemo5", MySqlDbType.Int32,4),
                    new MySqlParameter("@actStatus", MySqlDbType.Int32,4),
                    new MySqlParameter("@actID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.actName;
            parameters[1].Value = model.actDesc;
            parameters[2].Value = model.actStartTime;
            parameters[3].Value = model.actEndTime;
            parameters[4].Value = model.signupStartTime;
            parameters[5].Value = model.signupEndTime;
            parameters[6].Value = model.actType;
            parameters[7].Value = model.actWay;
            parameters[8].Value = model.actUrl;
            parameters[9].Value = model.actAddr;
            parameters[10].Value = model.actMemo1;
            parameters[11].Value = model.actMemo2;
            parameters[12].Value = model.actMemo3;
            parameters[13].Value = model.actMemo4;
            parameters[14].Value = model.actMemo5;
            parameters[15].Value = model.actStatus;
            parameters[16].Value = model.actID;

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
        public bool Delete(int actID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from act_activitymain ");
            strSql.Append(" where actID=@actID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@actID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = actID;

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
        public bool DeleteList(string actIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from act_activitymain ");
            strSql.Append(" where actID in (" + actIDlist + ")  ");
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
        public Bizcs.Model.act_activitymain GetModel(int actID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select actID,actName,actDesc,actStartTime,actEndTime,signupStartTime,signupEndTime,actType,actWay,actUrl,actAddr,actMemo1,actMemo2,actMemo3,actMemo4,actMemo5,actStatus from act_activitymain ");
            strSql.Append(" where actID=@actID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@actID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = actID;

            Bizcs.Model.act_activitymain model = new Bizcs.Model.act_activitymain();
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
        public Bizcs.Model.act_activitymain DataRowToModel(DataRow row)
        {
            Bizcs.Model.act_activitymain model = new Bizcs.Model.act_activitymain();
            if (row != null)
            {
                if (row["actID"] != null && row["actID"].ToString() != "")
                {
                    model.actID = int.Parse(row["actID"].ToString());
                }
                if (row["actName"] != null)
                {
                    model.actName = row["actName"].ToString();
                }
                if (row["actDesc"] != null)
                {
                    model.actDesc = row["actDesc"].ToString();
                }
                if (row["actStartTime"] != null && row["actStartTime"].ToString() != "")
                {
                    model.actStartTime = DateTime.Parse(row["actStartTime"].ToString());
                }
                if (row["actEndTime"] != null && row["actEndTime"].ToString() != "")
                {
                    model.actEndTime = DateTime.Parse(row["actEndTime"].ToString());
                }
                if (row["signupStartTime"] != null && row["signupStartTime"].ToString() != "")
                {
                    model.signupStartTime = DateTime.Parse(row["signupStartTime"].ToString());
                }
                if (row["signupEndTime"] != null && row["signupEndTime"].ToString() != "")
                {
                    model.signupEndTime = DateTime.Parse(row["signupEndTime"].ToString());
                }
                if (row["actType"] != null)
                {
                    model.actType = row["actType"].ToString();
                }
                if (row["actWay"] != null)
                {
                    model.actWay = row["actWay"].ToString();
                }
                if (row["actUrl"] != null)
                {
                    model.actUrl = row["actUrl"].ToString();
                }
                if (row["actAddr"] != null)
                {
                    model.actAddr = row["actAddr"].ToString();
                }
                if (row["actMemo1"] != null && row["actMemo1"].ToString() != "")
                {
                    model.actMemo1 = int.Parse(row["actMemo1"].ToString());
                }
                if (row["actMemo2"] != null && row["actMemo2"].ToString() != "")
                {
                    model.actMemo2 = int.Parse(row["actMemo2"].ToString());
                }
                if (row["actMemo3"] != null && row["actMemo3"].ToString() != "")
                {
                    model.actMemo3 = int.Parse(row["actMemo3"].ToString());
                }
                if (row["actMemo4"] != null && row["actMemo4"].ToString() != "")
                {
                    model.actMemo4 = int.Parse(row["actMemo4"].ToString());
                }
                if (row["actMemo5"] != null && row["actMemo5"].ToString() != "")
                {
                    model.actMemo5 = int.Parse(row["actMemo5"].ToString());
                }
                if (row["actStatus"] != null && row["actStatus"].ToString() != "")
                {
                    model.actStatus = int.Parse(row["actStatus"].ToString());
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
            strSql.Append("select actID,actName,actDesc,actStartTime,actEndTime,signupStartTime,signupEndTime,actType,actWay,actUrl,actAddr,actMemo1,actMemo2,actMemo3,actMemo4,actMemo5,actStatus ");
            strSql.Append(" FROM act_activitymain ");
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
            strSql.Append(" actID,actName,actDesc,actStartTime,actEndTime,signupStartTime,signupEndTime,actType,actWay,actUrl,actAddr,actMemo1,actMemo2,actMemo3,actMemo4,actMemo5,actStatus ");
            strSql.Append(" FROM act_activitymain ");
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
            strSql.Append("select count(1) FROM act_activitymain ");
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
            strSql.Append("SELECT *,actID AS `key` FROM ( ");
            strSql.Append(" SELECT *, ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by " + orderby);
            }
            else
            {
                strSql.Append("order by actID desc");
            }
            strSql.Append(")AS rnum from act_activitymain ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) as TT");
            strSql.AppendFormat(" WHERE rnum between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataSet exportList(string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select actName as activityName,actDesc as activityDescription," +
                "date_format(actStartTime,'%Y-%m-%d %H:%I') as activityStartTime,date_format(actEndTime,'%Y-%m-%d %H:%I') as activityEndTime," +
                "date_format(signupStartTime,'%Y-%m-%d %H:%I') as signupStartTime,date_format(signupEndTime,'%Y-%m-%d %H:%I') as signupEndTime ," +
                "actType as type,actWay as way,actAddr as address,actMemo1 as description ");
            strSql.Append(" FROM act_activitymain ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by " + orderby);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}
