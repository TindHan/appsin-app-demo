using DBUtility;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace app_act.Bizcs.DAL
{
    public class act_psnmain
    {
        public act_psnmain()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string psnPK)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from act_psnmain");
            strSql.Append(" where psnPK=@psnPK ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@psnPK", MySqlDbType.VarChar,50)           };
            parameters[0].Value = psnPK;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Bizcs.Model.act_psnmain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into act_psnmain(");
            strSql.Append("psnPK,psnName,unitPK,deptPK,postPk,unitName,deptName,postName,psnSex,psnCode,updateTime,psnStatus)");
            strSql.Append(" values (");
            strSql.Append("@psnPK,@psnName,@unitPK,@deptPK,@postPk,@unitName,@deptName,@postName,@psnSex,@psnCode,@updateTime,@psnStatus)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@psnPK", MySqlDbType.VarChar,50),
                    new MySqlParameter("@psnName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@unitPK", MySqlDbType.VarChar,50),
                    new MySqlParameter("@deptPK", MySqlDbType.VarChar,50),
                    new MySqlParameter("@postPk", MySqlDbType.VarChar,50),
                    new MySqlParameter("@unitName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@deptName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@postName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@psnSex", MySqlDbType.VarChar,50),
                    new MySqlParameter("@psnCode", MySqlDbType.VarChar,50),
                    new MySqlParameter("@updateTime", MySqlDbType.DateTime),
                    new MySqlParameter("@psnStatus", MySqlDbType.Int32,4)};
            parameters[0].Value = model.psnPK;
            parameters[1].Value = model.psnName;
            parameters[2].Value = model.unitPK;
            parameters[3].Value = model.deptPK;
            parameters[4].Value = model.postPk;
            parameters[5].Value = model.unitName;
            parameters[6].Value = model.deptName;
            parameters[7].Value = model.postName;
            parameters[8].Value = model.psnSex;
            parameters[9].Value = model.psnCode;
            parameters[10].Value = model.updateTime;
            parameters[11].Value = model.psnStatus;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Bizcs.Model.act_psnmain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update act_psnmain set ");
            strSql.Append("psnName=@psnName,");
            strSql.Append("unitPK=@unitPK,");
            strSql.Append("deptPK=@deptPK,");
            strSql.Append("postPk=@postPk,");
            strSql.Append("unitName=@unitName,");
            strSql.Append("deptName=@deptName,");
            strSql.Append("postName=@postName,");
            strSql.Append("psnSex=@psnSex,");
            strSql.Append("psnCode=@psnCode,");
            strSql.Append("updateTime=@updateTime,");
            strSql.Append("psnStatus=@psnStatus");
            strSql.Append(" where psnPK=@psnPK ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@psnName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@unitPK", MySqlDbType.VarChar,50),
                    new MySqlParameter("@deptPK", MySqlDbType.VarChar,50),
                    new MySqlParameter("@postPk", MySqlDbType.VarChar,50),
                    new MySqlParameter("@unitName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@deptName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@postName", MySqlDbType.VarChar,50),
                    new MySqlParameter("@psnSex", MySqlDbType.VarChar,50),
                    new MySqlParameter("@psnCode", MySqlDbType.VarChar,50),
                    new MySqlParameter("@updateTime", MySqlDbType.DateTime),
                    new MySqlParameter("@psnStatus", MySqlDbType.Int32,4),
                    new MySqlParameter("@psnPK", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.psnName;
            parameters[1].Value = model.unitPK;
            parameters[2].Value = model.deptPK;
            parameters[3].Value = model.postPk;
            parameters[4].Value = model.unitName;
            parameters[5].Value = model.deptName;
            parameters[6].Value = model.postName;
            parameters[7].Value = model.psnSex;
            parameters[8].Value = model.psnCode;
            parameters[9].Value = model.updateTime;
            parameters[10].Value = model.psnStatus;
            parameters[11].Value = model.psnPK;

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
        public bool Delete(string psnPK)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from act_psnmain ");
            strSql.Append(" where psnPK=@psnPK ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@psnPK", MySqlDbType.VarChar,50)           };
            parameters[0].Value = psnPK;

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
        public bool DeleteList(string psnPKlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from act_psnmain ");
            strSql.Append(" where psnPK in (" + psnPKlist + ")  ");
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
        public Bizcs.Model.act_psnmain GetModel(string psnPK)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select psnPK,psnName,unitPK,deptPK,postPk,unitName,deptName,postName,psnSex,psnCode,updateTime,psnStatus from act_psnmain ");
            strSql.Append(" where psnPK=@psnPK ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@psnPK", MySqlDbType.VarChar,50)           };
            parameters[0].Value = psnPK;

            Bizcs.Model.act_psnmain model = new Bizcs.Model.act_psnmain();
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
        public Bizcs.Model.act_psnmain DataRowToModel(DataRow row)
        {
            Bizcs.Model.act_psnmain model = new Bizcs.Model.act_psnmain();
            if (row != null)
            {
                if (row["psnPK"] != null)
                {
                    model.psnPK = row["psnPK"].ToString();
                }
                if (row["psnName"] != null)
                {
                    model.psnName = row["psnName"].ToString();
                }
                if (row["unitPK"] != null)
                {
                    model.unitPK = row["unitPK"].ToString();
                }
                if (row["deptPK"] != null)
                {
                    model.deptPK = row["deptPK"].ToString();
                }
                if (row["postPk"] != null)
                {
                    model.postPk = row["postPk"].ToString();
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
                if (row["psnSex"] != null)
                {
                    model.psnSex = row["psnSex"].ToString();
                }
                if (row["psnCode"] != null)
                {
                    model.psnCode = row["psnCode"].ToString();
                }
                if (row["updateTime"] != null && row["updateTime"].ToString() != "")
                {
                    model.updateTime = DateTime.Parse(row["updateTime"].ToString());
                }
                if (row["psnStatus"] != null && row["psnStatus"].ToString() != "")
                {
                    model.psnStatus = int.Parse(row["psnStatus"].ToString());
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
            strSql.Append("select psnPK,psnName,unitPK,deptPK,postPk,unitName,deptName,postName,psnSex,psnCode,updateTime,psnStatus ");
            strSql.Append(" FROM act_psnmain ");
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
            strSql.Append(" psnPK,psnName,unitPK,deptPK,postPk,unitName,deptName,postName,psnSex,psnCode,updateTime,psnStatus ");
            strSql.Append(" FROM act_psnmain ");
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
            strSql.Append("select count(1) FROM act_psnmain ");
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
                strSql.Append("order by T.psnPK desc");
            }
            strSql.Append(")AS Row, T.*  from act_psnmain T ");
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
