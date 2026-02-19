using app_act.Bizcs.Model;
using app_act.Common;
using app_act.Midcs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Text;
using System.Text.Json;

namespace app_act.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        [HttpPost(Name = "editLeave")]
        public async Task<commonResult<string>> editLeave([FromBody] commonRequest<leaveEdit> reqModel)
        {
            commonResult<string> result = new commonResult<string>();
            if (reqModel.uid == "" || !Common.UtilsHelper.isSafe(reqModel.uid) || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                result.status = "fail";
                result.message = "Uid is incorrect!";
                result.resData = null;
            }
            else if (!UtilsHelper.isSafe(reqModel.reqData[0].leaveType) || !UtilsHelper.isSafe(reqModel.reqData[0].leaveReason))
            {
                result.status = "fail";
                result.message = "The arguments including high risk characters!";
                result.resData = null;
            }
            else
            {
                Bizcs.Model.act_psnmain psnModel = new Bizcs.BLL.act_psnmain().GetModel(reqModel.uid);
                var t = reqModel.reqData[0];
                Bizcs.BLL.leave_list leaveBll = new Bizcs.BLL.leave_list();
                Bizcs.Model.leave_list leaveModel = t.leaveID == 0 ? new Bizcs.Model.leave_list() : leaveBll.GetModel(t.leaveID);

                leaveModel.leaveID = t.leaveID == 0 ? 0 : t.leaveID;
                leaveModel.psnPK = psnModel.psnPK;
                leaveModel.unitName = psnModel.unitName;
                leaveModel.deptName = psnModel.deptName;
                leaveModel.postName = psnModel.postName;
                leaveModel.createPsnPk = psnModel.psnPK;
                leaveModel.leaveType = t.leaveType;
                leaveModel.leaveReason = t.leaveReason;
                leaveModel.startTime = t.startTime;
                leaveModel.endTime = t.endTime;
                leaveModel.leaveDays = t.leaveDays;
                leaveModel.createTime = DateTime.Now;
                leaveModel.leaveStatus = (t.leaveStatus == 0 ? 0 : t.leaveStatus);
                leaveModel.approveStatus = t.leaveID == 0 ? 0 : leaveModel.approveStatus;

                if (t.leaveID == 0)
                { t.leaveID = leaveBll.Add(leaveModel); }
                else
                { leaveBll.Update(leaveModel); }

                string invokeResult = "";
                if (t.leaveStatus == 1)
                {
                    Midcs.leaveFlow flowModel = new Midcs.leaveFlow();
                    flowModel.psnPK = psnModel.psnPK;
                    flowModel.createPsnPK = psnModel.psnPK;
                    flowModel.templatePK = "d99c1e06-f1ee-4acc-944a-9f938a613a16";
                    flowModel.aukey = requestHelper.genAukey();
                    flowModel.int1Value = (int)t.leaveDays;
                    flowModel.flowName = psnModel.psnName + "'s leave application form";
                    flowModel.flowDesc = t.leaveType + " for " + t.leaveDays + " day(s)";
                    flowModel.str1Value = "";
                    flowModel.date1Value = null;
                    flowModel.contentUrl = "/show?id=" + t.leaveID;

                    string jsonString = JsonSerializer.Serialize(flowModel);

                    invokeResult = await requestHelper.postRequest("/api/AppServ/createFlow", jsonString);

                    var obj = JObject.Parse(invokeResult);
                    if (obj["status"].ToString().ToUpper() == "SUCCESS")
                    {
                        //Get and update the leavePK which appsin system created.
                        string leavePK = obj["resData"][0].ToString();
                        leaveBll.sycnLeavePK(leavePK, t.leaveID);

                        result.status = "success";
                        result.message = "Saved leave information and created flow successfully!";
                        result.resData = null;
                    }
                    else
                    {
                        result.status = "success";
                        result.message = "Saved leave information successfully but creating flow failed!";
                        result.resData = null;
                    }
                }
                else
                {
                    result.status = "success";
                    result.message = "Saved leave information successfully!";
                    result.resData = null;
                }
            }
            return result;
        }
        [HttpPost(Name = "getLeaveList")]
        public commonResult<leaveList> getLeaveList([FromBody] listRequest reqModel)
        {
            commonResult<leaveList> result = new commonResult<leaveList>();
            if (reqModel.uid == "" || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                result.status = "fail";
                result.message = "Uid is incorrect!";
                result.resData = null;
            }
            else if (!Common.UtilsHelper.isSafe(reqModel.uid) || !Common.UtilsHelper.isSafe(reqModel.uid)
                || !Common.UtilsHelper.isSafe(reqModel.kw) || !Common.UtilsHelper.isSafe(reqModel.status)
                || !Common.UtilsHelper.isSafe(reqModel.type) || !Common.UtilsHelper.isSafe(reqModel.start)
                || !Common.UtilsHelper.isSafe(reqModel.end))
            {
                result.status = "fail";
                result.message = "High risk characters in paras!";
                result.resData = null;
            }
            else
            {
                int pageIndex = Math.Max(reqModel.pageIndex, 1);
                int pageSize = Math.Max(reqModel.pageSize, 10);
                int sIndex = (pageIndex - 1) * pageSize + 1;
                int eIndex = pageIndex * pageSize;

                StringBuilder strWhere = new StringBuilder();
                strWhere.Append(" leaveStatus=@leaveStatus ");
                var parms = new List<MySqlParameter> { new MySqlParameter("@leaveStatus", reqModel.status) };

                if (!string.IsNullOrEmpty(reqModel.type))
                {
                    strWhere.Append(" and approveStatus=@approveStatus ");
                    parms.Add(new MySqlParameter("@approveStatus", reqModel.type));
                }
                if (!string.IsNullOrEmpty(reqModel.start) && DateTime.TryParse(reqModel.start, out var st))
                {
                    strWhere.Append(" and startTime>=@startTime ");
                    parms.Add(new MySqlParameter("@startTime", reqModel.start));
                }
                if (!string.IsNullOrEmpty(reqModel.end) && DateTime.TryParse(reqModel.end, out var et))
                {
                    strWhere.Append(" and endTime<=@endTime ");
                    parms.Add(new MySqlParameter("@endTime", reqModel.end));
                }

                Bizcs.BLL.leave_list leaveBll = new Bizcs.BLL.leave_list();

                DataSet dsLeave = leaveBll.GetListByPage(strWhere.ToString(), " createTime desc ", sIndex, eIndex, parms.ToArray());
                DataSet dsNumber = leaveBll.GetList(strWhere.ToString(), parms.ToArray());
                if (dsLeave.Tables[0] != null && dsLeave.Tables[0].Rows.Count > 0)
                {
                    result.status = "fail";
                    result.message = "There is no data！";
                    result.resData = null;
                }
                else
                {
                    List<leaveList> leList = Common.TBToList<leaveList>.ConvertToList(dsLeave.Tables[0]);

                    if (leList.Count > 0)
                    {
                        result.status = "success";
                        result.message = "Query successfully!";
                        result.number = dsNumber.Tables[0].Rows.Count;
                        result.resData = leList;
                    }
                    else
                    {
                        result.status = "fail";
                        result.message = "There is something wrong occured when add!";
                        result.resData = null;
                    }
                }
            }
            return result;
        }

        [HttpPost(Name = "getMyLeaves")]
        public async Task<commonResult<leaveList>> getMyLeaves([FromBody] listRequest reqModel)
        {
            commonResult<leaveList> result = new commonResult<leaveList>();
            if (reqModel.uid == "" || !Common.UtilsHelper.isSafe(reqModel.uid) || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                result.status = "fail";
                result.message = "Uid is incorrect!";
                result.resData = null;
            }
            else
            {
                await leaveHelper.syncLeaveStatus();

                int pageIndex = Math.Max(reqModel.pageIndex, 1);
                int pageSize = Math.Max(reqModel.pageSize, 10);
                int sIndex = (pageIndex - 1) * pageSize + 1;
                int eIndex = pageIndex * pageSize;

                StringBuilder strWhere = new StringBuilder();
                strWhere.Append("psnPK=@psnPK");
                List<MySqlParameter> parms = new List<MySqlParameter>
                {
                    new MySqlParameter("@psnPK",reqModel.uid)
                };

                Bizcs.BLL.leave_list leaveBll = new Bizcs.BLL.leave_list();

                DataSet dsLeave = leaveBll.GetListByPage(strWhere.ToString(), " createTime desc", sIndex, eIndex,parms.ToArray());
                DataSet dsNumber = leaveBll.GetList(strWhere.ToString(),parms.ToArray());
                if (dsLeave.Tables[0] != null && dsLeave.Tables[0].Rows.Count == 0)
                {
                    result.status = "fail";
                    result.message = "There is no data！";
                    result.resData = null;
                }
                else
                {
                    List<leaveList> leList = Common.TBToList<leaveList>.ConvertToList(dsLeave.Tables[0]);

                    if (leList.Count > 0)
                    {
                        result.status = "success";
                        result.message = "Query successfully!";
                        result.number = dsNumber.Tables[0].Rows.Count;
                        result.resData = leList;
                    }
                    else
                    {
                        result.status = "fail";
                        result.message = "There is something wrong occured when add!";
                        result.resData = null;
                    }
                }
            }
            return result;
        }

        [HttpPost(Name = "getLeaveDetail")]
        public commonResult<leaveList> getLeaveDetail([FromBody] commonRequest<string> reqModel)
        {
            commonResult<leaveList> result = new commonResult<leaveList>();
            if (reqModel.args == "")
            {
                result.status = "fail";
                result.message = "id is incorrect!";
                result.resData = null;
            }
            else
            {
                string strWhere1 = "leaveID=" + reqModel.args;

                Bizcs.BLL.leave_list leaveBll = new Bizcs.BLL.leave_list();

                DataSet dsLeave = leaveBll.GetListByPage(strWhere1, " ", 1, 1);
                if (dsLeave.Tables[0] != null && dsLeave.Tables[0].Rows.Count == 0)
                {
                    result.status = "fail";
                    result.message = "There is no data！";
                    result.resData = null;
                }
                else
                {
                    List<leaveList> leList = Common.TBToList<leaveList>.ConvertToList(dsLeave.Tables[0]);

                    if (leList.Count > 0)
                    {
                        result.status = "success";
                        result.message = "Query successfully!";
                        result.number = 1;
                        result.resData = leList;
                    }
                    else
                    {
                        result.status = "fail";
                        result.message = "There is something wrong occured when add!";
                        result.resData = null;
                    }
                }
            }
            return result;
        }
    }
}
