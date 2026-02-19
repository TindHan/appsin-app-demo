using DBUtility;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace app_act.Bizcs.DAL
{
    public class leave_list
    {
        public leave_list()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int leaveID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from leave_list");
            strSql.Append(" where leaveID=@leaveID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@leaveID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = leaveID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Bizcs.Model.leave_list model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into leave_list(");
            strSql.Append("leavePK,psnPK,unitName,deptName,postName,leaveType,startTime,endTime,leaveDays,createPsnPk,createTime,approveStatus,leaveStatus,leaveReason)");
            strSql.Append(" values (");
            strSql.Append("@leavePK,@psnPK,@unitName,@deptName,@postName,@leaveType,@startTime,@endTime,@leaveDays,@createPsnPk,@createTime,@approveStatus,@leaveStatus,@leaveReason)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@leavePK", MySqlDbType.VarChar,100),
                    new MySqlParameter("@psnPK", MySqlDbType.VarChar,100),
                    new MySqlParameter("@unitName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@deptName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@postName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@leaveType", MySqlDbType.VarChar,100),
                    new MySqlParameter("@startTime", MySqlDbType.DateTime),
                    new MySqlParameter("@endTime", MySqlDbType.DateTime),
                    new MySqlParameter("@leaveDays", MySqlDbType.Decimal,9),
                    new MySqlParameter("@createPsnPk", MySqlDbType.VarChar,100),
                    new MySqlParameter("@createTime", MySqlDbType.DateTime),
                    new MySqlParameter("@approveStatus", MySqlDbType.Int32,4),
                    new MySqlParameter("@leaveStatus", MySqlDbType.Int32,4),
                    new MySqlParameter("@leaveReason", MySqlDbType.VarChar,200)};
            parameters[0].Value = model.leavePK;
            parameters[1].Value = model.psnPK;
            parameters[2].Value = model.unitName;
            parameters[3].Value = model.deptName;
            parameters[4].Value = model.postName;
            parameters[5].Value = model.leaveType;
            parameters[6].Value = model.startTime;
            parameters[7].Value = model.endTime;
            parameters[8].Value = model.leaveDays;
            parameters[9].Value = model.createPsnPk;
            parameters[10].Value = model.createTime;
            parameters[11].Value = model.approveStatus;
            parameters[12].Value = model.leaveStatus;
            parameters[13].Value = model.leaveReason;

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
        public bool Update(Bizcs.Model.leave_list model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update leave_list set ");
            strSql.Append("leavePK=@leavePK,");
            strSql.Append("psnPK=@psnPK,");
            strSql.Append("unitName=@unitName,");
            strSql.Append("deptName=@deptName,");
            strSql.Append("postName=@postName,");
            strSql.Append("leaveType=@leaveType,");
            strSql.Append("startTime=@startTime,");
            strSql.Append("endTime=@endTime,");
            strSql.Append("leaveDays=@leaveDays,");
            strSql.Append("createPsnPk=@createPsnPk,");
            strSql.Append("createTime=@createTime,");
            strSql.Append("approveStatus=@approveStatus,");
            strSql.Append("leaveStatus=@leaveStatus,");
            strSql.Append("leaveReason=@leaveReason");
            strSql.Append(" where leaveID=@leaveID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@leavePK", MySqlDbType.VarChar,100),
                    new MySqlParameter("@psnPK", MySqlDbType.VarChar,100),
                    new MySqlParameter("@unitName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@deptName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@postName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@leaveType", MySqlDbType.VarChar,100),
                    new MySqlParameter("@startTime", MySqlDbType.DateTime),
                    new MySqlParameter("@endTime", MySqlDbType.DateTime),
                    new MySqlParameter("@leaveDays", MySqlDbType.Decimal,9),
                    new MySqlParameter("@createPsnPk", MySqlDbType.VarChar,100),
                    new MySqlParameter("@createTime", MySqlDbType.DateTime),
                    new MySqlParameter("@approveStatus", MySqlDbType.Int32,4),
                    new MySqlParameter("@leaveStatus", MySqlDbType.Int32,4),
                    new MySqlParameter("@leaveReason", MySqlDbType.VarChar,200),
                    new MySqlParameter("@leaveID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.leavePK;
            parameters[1].Value = model.psnPK;
            parameters[2].Value = model.unitName;
            parameters[3].Value = model.deptName;
            parameters[4].Value = model.postName;
            parameters[5].Value = model.leaveType;
            parameters[6].Value = model.startTime;
            parameters[7].Value = model.endTime;
            parameters[8].Value = model.leaveDays;
            parameters[9].Value = model.createPsnPk;
            parameters[10].Value = model.createTime;
            parameters[11].Value = model.approveStatus;
            parameters[12].Value = model.leaveStatus;
            parameters[13].Value = model.leaveReason;
            parameters[14].Value = model.leaveID;

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
        public bool Delete(int leaveID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from leave_list ");
            strSql.Append(" where leaveID=@leaveID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@leaveID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = leaveID;

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
        public bool DeleteList(string leaveIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from leave_list ");
            strSql.Append(" where leaveID in (" + leaveIDlist + ")  ");
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
        public Bizcs.Model.leave_list GetModel(int leaveID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select leaveID,leavePK,psnPK,unitName,deptName,postName,leaveType,startTime,endTime,leaveDays,createPsnPk,createTime,approveStatus,leaveStatus,leaveReason from leave_list ");
            strSql.Append(" where leaveID=@leaveID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@leaveID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = leaveID;

            Bizcs.Model.leave_list model = new Bizcs.Model.leave_list();
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
        public Bizcs.Model.leave_list DataRowToModel(DataRow row)
        {
            Bizcs.Model.leave_list model = new Bizcs.Model.leave_list();
            if (row != null)
            {
                if (row["leaveID"] != null && row["leaveID"].ToString() != "")
                {
                    model.leaveID = int.Parse(row["leaveID"].ToString());
                }
                if (row["leavePK"] != null)
                {
                    model.leavePK = row["leavePK"].ToString();
                }
                if (row["psnPK"] != null)
                {
                    model.psnPK = row["psnPK"].ToString();
                }
                if (row["unitName"] != null)
                {
                    model.unitName = row["unitName"].ToString();
                }
                if (row["deptName"] != null)
                {
                    model.deptName = row["deptName"].ToString();
                }
                if (row["postName"] != null)
                {
                    model.postName = row["postName"].ToString();
                }
                if (row["leaveType"] != null)
                {
                    model.leaveType = row["leaveType"].ToString();
                }
                if (row["startTime"] != null && row["startTime"].ToString() != "")
                {
                    model.startTime = DateTime.Parse(row["startTime"].ToString());
                }
                if (row["endTime"] != null && row["endTime"].ToString() != "")
                {
                    model.endTime = DateTime.Parse(row["endTime"].ToString());
                }
                if (row["leaveDays"] != null && row["leaveDays"].ToString() != "")
                {
                    model.leaveDays = decimal.Parse(row["leaveDays"].ToString());
                }
                if (row["createPsnPk"] != null)
                {
                    model.createPsnPk = row["createPsnPk"].ToString();
                }
                if (row["createTime"] != null && row["createTime"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(row["createTime"].ToString());
                }
                if (row["approveStatus"] != null && row["approveStatus"].ToString() != "")
                {
                    model.approveStatus = int.Parse(row["approveStatus"].ToString());
                }
                if (row["leaveStatus"] != null && row["leaveStatus"].ToString() != "")
                {
                    model.leaveStatus = int.Parse(row["leaveStatus"].ToString());
                }
                if (row["leaveReason"] != null)
                {
                    model.leaveReason = row["leaveReason"].ToString();
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
            strSql.Append("select leaveID,leavePK,psnPK,unitName,deptName,postName,leaveType,startTime,endTime,leaveDays,createPsnPk,createTime,approveStatus,leaveStatus,leaveReason ");
            strSql.Append(" FROM leave_list ");
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
                strSql.Append(" limit " + Top.ToString());
            }
            strSql.Append(" leaveID,leavePK,psnPK,unitName,deptName,postName,leaveType,startTime,endTime,leaveDays,createPsnPk,createTime,approveStatus,leaveStatus,leaveReason ");
            strSql.Append(" FROM leave_list ");
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
            strSql.Append("select count(1) FROM leave_list ");
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
            strSql.Append("SELECT leaveID as id,leavePK,psnPK,unitName,deptName,postName,leaveType,startTime,endTime,leaveDays,createPsnPk,createTime,approveStatus,leaveStatus,leaveReason, ");
            strSql.Append("(SELECT psnName from act_psnMain psn where psn.psnPK=TT.psnPK) as psnName ");
            strSql.Append(" FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.leaveID desc");
            }
            strSql.Append(")AS iRow, T.*  from leave_list T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.iRow between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        public DataSet GetList(string strWhere,params MySqlParameter[] parms)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select leaveID,leavePK,psnPK,unitName,deptName,postName,leaveType,startTime,endTime,leaveDays,createPsnPk,createTime,approveStatus,leaveStatus,leaveReason ");
            strSql.Append(" FROM leave_list ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString(),parms);
        } 
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex,params MySqlParameter[] parms)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT leaveID as id,leavePK,psnPK,unitName,deptName,postName,leaveType,startTime,endTime,leaveDays,createPsnPk,createTime,approveStatus,leaveStatus,leaveReason, ");
            strSql.Append("(SELECT psnName from act_psnMain psn where psn.psnPK=TT.psnPK) as psnName ");
            strSql.Append(" FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.leaveID desc");
            }
            strSql.Append(")AS iRow, T.*  from leave_list T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.iRow between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString(),parms);
        }
        public bool sycnApproveStatus(string leavePK,int approveStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update leave_list set ");
            strSql.Append("approveStatus=@approveStatus ");
            strSql.Append(" where leavePK=@leavePK");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@approveStatus", MySqlDbType.Int32,4),
                    new MySqlParameter("@leavePK", MySqlDbType.VarChar,100) };
            parameters[0].Value = approveStatus;
            parameters[1].Value = leavePK;

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

        public bool sycnLeavePK(string leavePK, int leaveID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update leave_list set ");
            strSql.Append("leavePK=@leavePK ");
            strSql.Append(" where leaveID=@leaveID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@leavePK",MySqlDbType.VarChar,100),
                    new MySqlParameter("@leaveID",  MySqlDbType.Int32,4) };
            parameters[0].Value = leavePK;
            parameters[1].Value = leaveID;

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
        #endregion  ExtensionMethod
    }
}
