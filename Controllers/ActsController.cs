using app_act.Bizcs.Model;
using app_act.Midcs;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Linq;
using System.Text;

namespace app_act.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActsController : ControllerBase
    {

        [HttpPost(Name = "addPsn")]
        public commonResult<string> addPsn([FromBody] commonRequest<string> reqModel)
        {
            commonResult<string> result = new commonResult<string>();
            if (reqModel.uid == "" || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                result.status = "fail";
                result.message = "Uid is incorrect!";
                result.resData = null;
            }
            else if (!Common.UtilsHelper.isSafe(reqModel.uid) || !Common.UtilsHelper.isSafe(reqModel.args))
            {
                result.status = "fail";
                result.message = "High risk characters in paras!";
                result.resData = null;
            }
            else if (reqModel.reqData.Count < 1)
            {
                result.status = "fail";
                result.message = "No valid para!";
                result.resData = null;
            }
            else
            {
                int actID = int.Parse(reqModel.args);
                string psnPk = reqModel.reqData[0];

                Bizcs.BLL.act_signup signBll = new Bizcs.BLL.act_signup();

                DataSet dsObj = signBll.GetList(" actID=" + actID + " and psnPk='" + psnPk + "' and signStatus=1 ");
                if (dsObj.Tables[0] != null && dsObj.Tables[0].Rows.Count > 0)
                {
                    result.status = "fail";
                    result.message = "There is an signed up record exist for this person！";
                    result.resData = null;
                }
                else
                {
                    Bizcs.Model.act_signup signModel = new Bizcs.Model.act_signup();
                    signModel.actID = actID;
                    signModel.psnPK = psnPk;
                    signModel.isPay = 0;
                    signModel.isConfirm = 0;
                    signModel.signWay = "pc_admin";
                    signModel.signTime = DateTime.Now;
                    signModel.signStatus = 1;
                    int iss = signBll.Add(signModel);
                    if (iss > 0)
                    {
                        result.status = "success";
                        result.message = "Add successfully!";
                        result.resData = null;
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

        [HttpPost(Name = "searchPsn")]
        public async Task<commonResult<string>> searchPsn([FromBody] commonRequest<string> reqModel)
        {
            commonResult<string> result = new commonResult<string>();

            if (reqModel.uid == "" || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                result.status = "fail";
                result.message = "Uid is incorrect!";
                result.resData = null;
            }
            else if (!Common.UtilsHelper.isSafe(reqModel.uid) || !Common.UtilsHelper.isSafe(reqModel.args))
            {
                result.status = "fail";
                result.message = "High risk characters in paras!";
                result.resData = null;
            }
            else
            {
                string keyWord = reqModel.args;

                string psnList = await Common.requestHelper.postRequest
                    (
                    "/api/Appserv/getPsnSearch",
                    "{\"aukey\":\"" + Common.requestHelper.genAukey() + "\",\"args\":\"" + keyWord + "\"}"
                    );
                var obj = JObject.Parse(psnList);

                if (obj["status"].ToString().ToLower() == "success")
                {
                    JToken datalist = obj["resData"];

                    string psnPK = "";
                    Bizcs.BLL.act_psnmain psnBll = new Bizcs.BLL.act_psnmain();
                    Bizcs.Model.act_psnmain psnModel = new act_psnmain();
                    for (int i = 0; i < datalist.Count(); i++)
                    {

                        psnModel.psnName = datalist[i]["psnName"].ToString();
                        psnModel.psnCode = datalist[i]["psnCode"] == null ? "" : datalist[i]["psnCode"].ToString();
                        psnModel.unitPK = datalist[i]["unitPK"] == null ? "" : datalist[i]["unitPK"].ToString();
                        psnModel.deptPK = datalist[i]["deptPK"] == null ? "" : datalist[i]["deptPK"].ToString();
                        psnModel.postPk = datalist[i]["postPK"] == null ? "" : datalist[i]["postPK"].ToString();
                        psnModel.unitName = datalist[i]["unitName"] == null ? "" : datalist[i]["unitName"].ToString();
                        psnModel.deptName = datalist[i]["deptName"] == null ? "" : datalist[i]["deptName"].ToString();
                        psnModel.postName = datalist[i]["postName"] == null ? "" : datalist[i]["postName"].ToString();
                        psnModel.psnSex = datalist[i]["psnSex"] == null ? "" : datalist[i]["psnSex"].ToString();
                        psnModel.updateTime = DateTime.Now;
                        psnModel.psnStatus = 1;

                        psnModel.psnPK = datalist[i]["psnPK"].ToString();

                        bool iss = psnBll.Exists(psnModel.psnPK);

                        if (iss)
                        {
                            psnBll.Update(psnModel);
                        }
                        else
                        {
                            psnBll.Add(psnModel);
                        }
                    }
                    int aa = datalist.Count();
                    result.status = "success";
                    result.message = "";
                    result.resData = [datalist.ToString()];
                }
                else
                {
                    result.status = "fail";
                    result.message = "No required data";
                    result.resData = [null];
                }


            }

            return result;
        }

        [HttpPost(Name = "cancelSignup")]
        public commonResult<string> cancelSignup([FromBody] commonRequest<string> reqModel)
        {
            commonResult<string> result = new commonResult<string>();

            if (reqModel.uid == "" || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                result.status = "fail";
                result.message = "Uid is incorrect!";
                result.resData = null;
            }
            else if (!Common.UtilsHelper.isSafe(reqModel.uid) || !Common.UtilsHelper.isSafe(reqModel.args))
            {
                result.status = "fail";
                result.message = "High risk characters in paras!";
                result.resData = null;
            }
            else
            {
                int signID = int.Parse(reqModel.args);
                Bizcs.BLL.act_signup signBll = new Bizcs.BLL.act_signup();
                Bizcs.Model.act_signup signModel = signBll.GetModel(signID);
                if (signModel == null)
                {
                    result.status = "fail";
                    result.message = "Invalid para!";
                    result.resData = null;
                }
                else
                {
                    signModel.signStatus = -1;
                    bool iss = signBll.Update(signModel);
                    if (iss)
                    {
                        result.status = "success";
                        result.message = "Sign up canceled!";
                        result.resData = null;
                    }
                    else
                    {
                        result.status = "fail";
                        result.message = "Error occured when update!";
                        result.resData = null;
                    }
                }
            }


            return result;
        }

        [HttpPost(Name = "dlSignup")]
        public IActionResult dlSignup(listRequest reqModel)
        {
            if (reqModel.uid == "" || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                return new JsonResult(new { status = "false", message = "Uid is incorrect!" });
            }
            else if (!Common.UtilsHelper.isSafe(reqModel.uid) || !Common.UtilsHelper.isSafe(reqModel.kw) || !Common.UtilsHelper.isSafe(reqModel.type)
                || !Common.UtilsHelper.isSafe(reqModel.start) || !Common.UtilsHelper.isSafe(reqModel.end) || !Common.UtilsHelper.isSafe(reqModel.status))
            {
                return new JsonResult(new { status = "false", message = "High risk characters in paras!" });
            }
            else
            {
                Bizcs.BLL.act_signup signbll = new Bizcs.BLL.act_signup();

                StringBuilder strWhere = new StringBuilder();
                List<MySqlParameter> parms = new List<MySqlParameter>();
                strWhere.Append(" 1=1 ");
                if (!string.IsNullOrEmpty(reqModel.kw))
                {
                    strWhere.Append(" and psnName like @psnName ");
                    parms.Add(new MySqlParameter("@psnName", $"%{reqModel.kw}%"));
                }
                if (!string.IsNullOrEmpty(reqModel.start) && DateTime.TryParse(reqModel.start, out var st))
                {
                    strWhere.Append(" and signTime>= @signTime1");
                    parms.Add(new MySqlParameter("@signTime1", DateTime.Parse(reqModel.start)));
                }
                if (!string.IsNullOrEmpty(reqModel.end) && DateTime.TryParse(reqModel.end, out var et))
                {
                    strWhere.Append(" and signTime< @signTime2");
                    parms.Add(new MySqlParameter("@signTime2", DateTime.Parse(reqModel.end).AddDays(1)));
                }
                if (!string.IsNullOrEmpty(reqModel.status))
                {
                    strWhere.Append(" and signStatus=@signStatus");
                    parms.Add(new MySqlParameter("@signStatus", reqModel.status));
                }
                if (!string.IsNullOrEmpty(reqModel.type))
                {
                    strWhere.Append(" and actID=@actID");
                    parms.Add(new MySqlParameter("@actID", reqModel.type));
                }

                DataSet dsObj = signbll.exportList(strWhere.ToString(), parms.ToArray());
                if (dsObj.Tables[0] != null && dsObj.Tables[0].Rows.Count > 0)
                {
                    string fileInfo = Common.ExcelHelper.DataToExcel(dsObj.Tables[0], "list" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx", "Sign Up List");
                    string filePath = Directory.GetCurrentDirectory() + fileInfo;
                    var fileObj = Path.GetFileName(filePath);
                    // read file content
                    byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

                    // set file name and MIME type
                    string fileName = Path.GetFileName(filePath);
                    string mimeType = "application/vnd.ms-excel"; // set MIME type
                    Response.Headers.Add("fileName", fileName);

                    //create FileContentResult and return
                    return File(fileBytes, mimeType, fileName);

                }
                else
                {
                    return new JsonResult(new { status = "false", message = "There is no data can be download!" });
                }
            }
        }

        [HttpPost(Name = "allSignup")]
        public commonResult<listSign> allSignup(listRequest reqModel)
        {
            commonResult<listSign> result = new commonResult<listSign>();

            if (reqModel.uid == "" || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                result.status = "fail";
                result.message = "Uid is incorrect!";
                result.resData = null;
            }
            else if (!Common.UtilsHelper.isSafe(reqModel.uid) || !Common.UtilsHelper.isSafe(reqModel.kw) || !Common.UtilsHelper.isSafe(reqModel.type)
                || !Common.UtilsHelper.isSafe(reqModel.start) || !Common.UtilsHelper.isSafe(reqModel.end) || !Common.UtilsHelper.isSafe(reqModel.status))
            {
                result.status = "fail";
                result.message = "High risk characters in paras!";
                result.resData = null;
            }
            else
            {
                Bizcs.BLL.act_signup signbll = new Bizcs.BLL.act_signup();

                int pageIndex = Math.Max(reqModel.pageIndex, 1);
                int pageSize = Math.Max(reqModel.pageSize, 10);
                int sIndex = (pageIndex - 1) * pageSize + 1;
                int eIndex = pageIndex * pageSize;

                StringBuilder strWhere = new StringBuilder();
                StringBuilder subStrWhere = new StringBuilder();
                List<MySqlParameter> parms = new List<MySqlParameter>();
                strWhere.Append(" 1=1 ");
                if (!string.IsNullOrEmpty(reqModel.kw))
                {
                    subStrWhere.Append(" and psnName like @psnName ");
                    parms.Add(new MySqlParameter("@psnName", $"%{reqModel.kw}%"));
                }
                if (!string.IsNullOrEmpty(reqModel.start) && DateTime.TryParse(reqModel.start, out var st))
                {
                    strWhere.Append(" and signTime>= @signTime1");
                    parms.Add(new MySqlParameter("@signTime1", DateTime.Parse(reqModel.start)));
                }
                if (!string.IsNullOrEmpty(reqModel.end) && DateTime.TryParse(reqModel.end, out var et))
                {
                    strWhere.Append(" and signTime< @signTime2");
                    parms.Add(new MySqlParameter("@signTime2", DateTime.Parse(reqModel.end).AddDays(1)));
                }
                if (!string.IsNullOrEmpty(reqModel.status))
                {
                    strWhere.Append(" and signStatus=@signStatus");
                    parms.Add(new MySqlParameter("@signStatus", reqModel.status));
                }
                if (!string.IsNullOrEmpty(reqModel.type))
                {
                    strWhere.Append(" and actID=@actID");
                    parms.Add(new MySqlParameter("@actID", reqModel.type));
                }


                DataSet dsPsn = signbll.GetListByPage(strWhere.ToString(), subStrWhere.ToString(), "", sIndex, eIndex, parms.ToArray());
                DataSet dsAll = signbll.GetList(strWhere.ToString(), parms.ToArray());
                if (dsPsn != null)
                {
                    List<listSign> signlist = Common.TBToList<listSign>.ConvertToList(dsPsn.Tables[0]);
                    result.status = "success";
                    result.message = "The data is in resData";
                    result.number = dsAll.Tables[0].Rows.Count;
                    result.resData = signlist;
                }
                else
                {
                    result.status = "success";
                    result.message = "No data";
                    result.resData = null;
                }
            }
            return result;
        }

        [HttpPost(Name = "mySignup")]
        public commonResult<listSign> mySignup(listRequest reqModel)
        {
            commonResult<listSign> result = new commonResult<listSign>();

            if (reqModel.uid == "" || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                result.status = "fail";
                result.message = "Uid is incorrect!";
                result.resData = null;
            }
            else if (!Common.UtilsHelper.isSafe(reqModel.uid) || !Common.UtilsHelper.isSafe(reqModel.kw) || !Common.UtilsHelper.isSafe(reqModel.type)
                || !Common.UtilsHelper.isSafe(reqModel.start) || !Common.UtilsHelper.isSafe(reqModel.end) || !Common.UtilsHelper.isSafe(reqModel.status))
            {
                result.status = "fail";
                result.message = "High risk characters in paras!";
                result.resData = null;
            }
            else
            {
                Bizcs.BLL.act_signup signbll = new Bizcs.BLL.act_signup();

                int pageIndex = Math.Max(reqModel.pageIndex, 1);
                int pageSize = Math.Max(reqModel.pageSize, 10);
                int sIndex = (pageIndex - 1) * pageSize + 1;
                int eIndex = pageIndex * pageSize;

                StringBuilder strWhere = new StringBuilder();
                StringBuilder subStrWhere = new StringBuilder();
                List<MySqlParameter> parms = new List<MySqlParameter>();
                strWhere.Append(" 1=1 ");
                if (!string.IsNullOrEmpty(reqModel.uid))
                {
                    strWhere.Append(" and psnPk= @psnPk ");
                    parms.Add(new MySqlParameter("@psnPk", reqModel.uid));
                }
                if (!string.IsNullOrEmpty(reqModel.kw))
                {
                    subStrWhere.Append(" and actName like @actName ");
                    parms.Add(new MySqlParameter("@actName", $"%{ reqModel.kw }%"));
                }
                if (!string.IsNullOrEmpty(reqModel.start) && DateTime.TryParse(reqModel.start, out var st))
                {
                    strWhere.Append(" and signTime>= @signTime1 ");
                    parms.Add(new MySqlParameter("@signTime1", DateTime.Parse(reqModel.start)));
                }
                if (!string.IsNullOrEmpty(reqModel.end) && DateTime.TryParse(reqModel.end, out var et))
                {
                    strWhere.Append(" and signTime< @signTime2");
                    parms.Add(new MySqlParameter("@signTime2", DateTime.Parse(reqModel.end).AddDays(1)));
                }
                if (!string.IsNullOrEmpty(reqModel.status))
                {
                    strWhere.Append(" and signStatus=@signStatus ");
                    parms.Add(new MySqlParameter("@signStatus", reqModel.status));
                }

                DataSet dsPsn = signbll.GetListByPage(strWhere.ToString(), subStrWhere.ToString(), "", sIndex, eIndex, parms.ToArray());
                DataSet dsAll = signbll.GetList(strWhere.ToString(), parms.ToArray());
                if (dsPsn != null)
                {
                    List<listSign> signlist = Common.TBToList<listSign>.ConvertToList(dsPsn.Tables[0]);
                    result.status = "success";
                    result.message = "The data is in resData";
                    result.number = dsAll.Tables[0].Rows.Count;
                    result.resData = signlist;
                }
                else
                {
                    result.status = "success";
                    result.message = "No data";
                    result.resData = null;
                }
            }
            return result;
        }

        [HttpPost(Name = "signupAct")]
        public commonResult<string> signupAct(commonRequest<string> reqModel)
        {
            commonResult<string> result = new commonResult<string>();
            if (reqModel.uid == "" || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                result.status = "fail";
                result.message = "Uid is incorrect!";
                result.resData = null;
            }
            else if (!Common.UtilsHelper.isSafe(reqModel.uid) || !Common.UtilsHelper.isSafe(reqModel.args))
            {
                result.status = "fail";
                result.message = "High risk characters in paras!";
                result.resData = null;
            }
            else
            {
                Bizcs.BLL.act_signup signBll = new Bizcs.BLL.act_signup();
                DataSet dsSign = signBll.GetList(" psnPk='" + reqModel.uid + "' and actID=" + reqModel.args + " and signStatus=1");
                if (dsSign.Tables[0] != null && dsSign.Tables[0].Rows.Count > 0)
                {
                    result.status = "fail";
                    result.message = "You have already signed up this activity!";
                    result.resData = null;
                }
                else
                {
                    Bizcs.Model.act_signup signModel = new act_signup();
                    signModel.actID = int.Parse(reqModel.args);
                    signModel.psnPK = reqModel.uid;
                    signModel.signTime = DateTime.Now;
                    signModel.signWay = reqModel.reqData[0];
                    signModel.isConfirm = 0;
                    signModel.signStatus = 1;
                    int iss = new Bizcs.BLL.act_signup().Add(signModel);
                    if (iss > 0)
                    {
                        result.status = "success";
                        result.message = "Sign up success!";
                        result.resData = null;
                    }
                    else
                    {
                        result.status = "fail";
                        result.message = "Error occured when add!";
                        result.resData = null;
                    }
                }

            }

            return result;
        }

        [HttpPost(Name = ("delAct"))]
        public commonResult<string> delAct([FromBody] commonRequest<string> reqModel)
        {
            commonResult<string> result = new commonResult<string>();

            if (reqModel.uid == "" || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                result.status = "fail";
                result.message = "Uid is incorrect!";
                result.resData = null;
            }
            else if (reqModel.reqData.Count <= 0)
            {
                result.status = "fail";
                result.message = "No valid data submit!";
                result.resData = null;
            }
            else if (!Common.UtilsHelper.isSafe(reqModel.uid) || !Common.UtilsHelper.isSafe(reqModel.args) || !Common.UtilsHelper.isSafe(reqModel.reqData[0]))
            {
                result.status = "fail";
                result.message = "High risk characters in paras!";
                result.resData = null;
            }
            else
            {
                int actID = int.Parse(reqModel.reqData[0]);
                if (actID > 0)
                {
                    Bizcs.BLL.act_signup signBll = new Bizcs.BLL.act_signup();
                    DataSet dsSign = signBll.GetList(" actID=" + actID);
                    if (dsSign.Tables[0] != null && dsSign.Tables[0].Rows.Count > 0)
                    {
                        result.status = "fail";
                        result.message = "Someone have already signed up,can't be deleted!";
                        result.resData = null;
                    }
                    else
                    {
                        bool iss = new Bizcs.BLL.act_activitymain().Delete(actID);
                        if (iss)
                        {
                            result.status = "success";
                            result.message = "Item has been deleted!";
                            result.resData = null;
                        }
                        else
                        {
                            result.status = "fail";
                            result.message = "Error occured when delete!";
                            result.resData = null;
                        }
                    }
                }
                else
                {
                    result.status = "fail";
                    result.message = "ID is incorrect!";
                    result.resData = null;
                }
            }
            return result;
        }

        [HttpPost(Name = ("editAct"))]
        public commonResult<string> editAct([FromBody] commonRequest<editActivity> reqModel)
        {
            commonResult<string> result = new commonResult<string>();

            if (reqModel.uid == "" || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                result.status = "fail";
                result.message = "Uid is incorrect!";
                result.resData = null;
            }
            else if (reqModel.reqData.Count <= 0)
            {
                result.status = "fail";
                result.message = "No valid data submit!";
                result.resData = null;
            }
            else if (!Common.UtilsHelper.isSafe(reqModel.uid) || !Common.UtilsHelper.isSafe(reqModel.args)
                || !Common.UtilsHelper.isSafe(reqModel.reqData[0].actID) || !Common.UtilsHelper.isSafe(reqModel.reqData[0].actStatus)
                || !Common.UtilsHelper.isSafe(reqModel.reqData[0].actName) || !Common.UtilsHelper.isSafe(reqModel.reqData[0].actType)
                || !Common.UtilsHelper.isSafe(reqModel.reqData[0].actStartTime) || !Common.UtilsHelper.isSafe(reqModel.reqData[0].actEndTime)
                || !Common.UtilsHelper.isSafe(reqModel.reqData[0].signupStartTime) || !Common.UtilsHelper.isSafe(reqModel.reqData[0].signupEndTime)
                || !Common.UtilsHelper.isSafe(reqModel.reqData[0].actAddr) || !Common.UtilsHelper.isSafe(reqModel.reqData[0].actDesc))
            {
                result.status = "fail";
                result.message = "High risk characters in paras!";
                result.resData = null;
            }
            else
            {
                int actID = int.Parse(reqModel.reqData[0].actID);
                if (actID > 0)//update
                {
                    Bizcs.BLL.act_activitymain actBll = new Bizcs.BLL.act_activitymain();
                    Bizcs.Model.act_activitymain actModel = actBll.GetModel(actID);
                    if (actModel != null)
                    {
                        actModel.actName = reqModel.reqData[0].actName;
                        actModel.actType = reqModel.reqData[0].actType;
                        actModel.actStartTime = Convert.ToDateTime(reqModel.reqData[0].actStartTime);
                        actModel.actEndTime = Convert.ToDateTime(reqModel.reqData[0].actEndTime);
                        actModel.signupStartTime = Convert.ToDateTime(reqModel.reqData[0].signupStartTime);
                        actModel.signupEndTime = Convert.ToDateTime(reqModel.reqData[0].signupEndTime);
                        actModel.actAddr = reqModel.reqData[0].actAddr;
                        actModel.actDesc = reqModel.reqData[0].actDesc;
                        actModel.actStatus = reqModel.reqData[0].actStatus == "true" ? 1 : 0;
                        actBll.Update(actModel);

                        result.status = "success";
                        result.message = "The data you submit has already updated!";
                        result.resData = null;
                    }
                    else
                    {
                        result.status = "fail";
                        result.message = "Error occured when update!";
                        result.resData = null;
                    }
                }
                else//add
                {
                    Bizcs.Model.act_activitymain actModel = new act_activitymain();
                    actModel.actName = reqModel.reqData[0].actName;
                    actModel.actType = reqModel.reqData[0].actType;
                    actModel.actStartTime = Convert.ToDateTime(reqModel.reqData[0].actStartTime);
                    actModel.actEndTime = Convert.ToDateTime(reqModel.reqData[0].actEndTime);
                    actModel.signupStartTime = Convert.ToDateTime(reqModel.reqData[0].signupStartTime);
                    actModel.signupEndTime = Convert.ToDateTime(reqModel.reqData[0].signupEndTime);
                    actModel.actAddr = reqModel.reqData[0].actAddr;
                    actModel.actDesc = reqModel.reqData[0].actDesc;
                    actModel.actStatus = reqModel.reqData[0].actStatus == "true" ? 1 : 0;
                    int iss = new Bizcs.BLL.act_activitymain().Add(actModel);
                    if (iss > 0)
                    {
                        result.status = "success";
                        result.message = "The data you submit has already added!";
                        result.resData = null;
                    }
                    else
                    {
                        result.status = "fail";
                        result.message = "Error occured when add data!";
                        result.resData = null;
                    }
                }
            }

            return result;
        }

        [HttpPost(Name = "getActDetail")]
        public commonResult<act_activitymain> getActDetail([FromBody] detailRequest reqModel)
        {
            commonResult<act_activitymain> result = new commonResult<act_activitymain>();

            if (reqModel.uid == "" || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                result.status = "fail";
                result.message = "Uid is incorrect!";
                result.resData = null;
            }
            else if (!Common.UtilsHelper.isSafe(reqModel.uid) || !Common.UtilsHelper.isSafe(reqModel.objID) || !Common.UtilsHelper.isSafe(reqModel.condition))
            {
                result.status = "fail";
                result.message = "High risk characters in paras!";
                result.resData = null;
            }
            else
            {
                Bizcs.BLL.act_activitymain actbll = new Bizcs.BLL.act_activitymain();

                int actID = Int32.Parse(reqModel.objID);
                Bizcs.Model.act_activitymain actModel = actbll.GetModel(actID);

                if (actModel != null)
                {
                    result.status = "success";
                    result.message = "The data is in resData";
                    result.number = 1;
                    result.resData = [actModel];
                }
                else
                {
                    result.status = "success";
                    result.message = "No data";
                    result.resData = null;
                }
            }
            return result;
        }

        [HttpPost(Name = "getActList")]
        public commonResult<act_activitymain> getActList([FromBody] listRequest reqModel)
        {
            commonResult<act_activitymain> result = new commonResult<act_activitymain>();

            if (reqModel.uid == "" || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                result.status = "fail";
                result.message = "Uid is incorrect!";
                result.resData = null;
            }
            else if (!Common.UtilsHelper.isSafe(reqModel.uid) || !Common.UtilsHelper.isSafe(reqModel.kw) || !Common.UtilsHelper.isSafe(reqModel.type)
                || !Common.UtilsHelper.isSafe(reqModel.start) || !Common.UtilsHelper.isSafe(reqModel.end) || !Common.UtilsHelper.isSafe(reqModel.status))
            {
                result.status = "fail";
                result.message = "High risk characters in paras!";
                result.resData = null;
            }
            else
            {
                Bizcs.BLL.act_activitymain actbll = new Bizcs.BLL.act_activitymain();

                int pageIndex = Math.Max(reqModel.pageIndex, 1);
                int pageSize = Math.Max(reqModel.pageSize, 10);
                int sIndex = (pageIndex - 1) * pageSize + 1;
                int eIndex = pageIndex * pageSize;

                StringBuilder strWhere = new StringBuilder();
                List<MySqlParameter> parms = new List<MySqlParameter>();
                strWhere.Append(" 1=1 ");
                if (!string.IsNullOrEmpty(reqModel.kw))
                {
                    strWhere.Append(" and actName like @actName ");
                    parms.Add(new MySqlParameter("@actName", $"%{reqModel.kw}%" ));
                }
                if (!string.IsNullOrEmpty(reqModel.start) && DateTime.TryParse(reqModel.start, out var st))
                {
                    strWhere.Append(" and actStartTime>= @actStartTime1");
                    parms.Add(new MySqlParameter("@actStartTime1", DateTime.Parse(reqModel.start)));
                }
                if (!string.IsNullOrEmpty(reqModel.end) && DateTime.TryParse(reqModel.end, out var et))
                {
                    strWhere.Append(" and actStartTime< @actStartTime2");
                    parms.Add(new MySqlParameter("@actStartTime2", DateTime.Parse(reqModel.end).AddDays(1)));
                }
                if (!string.IsNullOrEmpty(reqModel.status))
                {
                    strWhere.Append(" and actStatus=@actStatus");
                    parms.Add(new MySqlParameter("@actStatus", reqModel.status));
                }
                if (!string.IsNullOrEmpty(reqModel.type))
                {
                    strWhere.Append(" and actType=@actType");
                    parms.Add(new MySqlParameter("@actType", reqModel.type));
                }

                DataSet dsPsn = actbll.GetListByPage(strWhere.ToString(), "", sIndex, eIndex,parms.ToArray());
                DataSet dsAll = actbll.GetList(strWhere.ToString(),parms.ToArray());
                if (dsPsn != null)
                {
                    List<act_activitymain> actlist = Common.TBToList<act_activitymain>.ConvertToList(dsPsn.Tables[0]);
                    result.status = "success";
                    result.message = "The data is in resData";
                    result.number = dsAll.Tables[0].Rows.Count;
                    result.resData = actlist;
                }
                else
                {
                    result.status = "success";
                    result.message = "No data";
                    result.resData = null;
                }
            }
            return result;
        }

        [HttpPost(Name = "dlActList")]
        public IActionResult dlActList([FromBody] listRequest reqModel)
        {

            if (reqModel.uid == "" || Common.UtilsHelper.checkUser(reqModel.uid) == false)
            {
                return new JsonResult(new { status = "fail", message = "Uid is incorrect!" });
            }
            else if (!Common.UtilsHelper.isSafe(reqModel.uid) || !Common.UtilsHelper.isSafe(reqModel.kw) || !Common.UtilsHelper.isSafe(reqModel.type)
                || !Common.UtilsHelper.isSafe(reqModel.start) || !Common.UtilsHelper.isSafe(reqModel.end) || !Common.UtilsHelper.isSafe(reqModel.status))
            {
                return new JsonResult(new { status = "fail", message = "High risk characters in paras!" });
            }
            else
            {
                Bizcs.BLL.act_activitymain actbll = new Bizcs.BLL.act_activitymain();

                StringBuilder strWhere = new StringBuilder();
                List<MySqlParameter> parms = new List<MySqlParameter>();
                strWhere.Append(" 1=1 ");
                if (!string.IsNullOrEmpty(reqModel.kw))
                {
                    strWhere.Append(" and actName like @actName ");
                    parms.Add(new MySqlParameter("@actName", $"%{reqModel.kw}%"));
                }
                if (!string.IsNullOrEmpty(reqModel.start) && DateTime.TryParse(reqModel.start, out var st))
                {
                    strWhere.Append(" and actStartTime>= @actStartTime1");
                    parms.Add(new MySqlParameter("@actStartTime1", DateTime.Parse(reqModel.start)));
                }
                if (!string.IsNullOrEmpty(reqModel.end) && DateTime.TryParse(reqModel.end, out var et))
                {
                    strWhere.Append(" and actStartTime< @actStartTime2");
                    parms.Add(new MySqlParameter("@actStartTime2", DateTime.Parse(reqModel.end).AddDays(1)));
                }
                if (!string.IsNullOrEmpty(reqModel.status))
                {
                    strWhere.Append(" and actStatus=@actStatus");
                    parms.Add(new MySqlParameter("@actStatus", reqModel.status));
                }
                if (!string.IsNullOrEmpty(reqModel.type))
                {
                    strWhere.Append(" and actType=@actType");
                    parms.Add(new MySqlParameter("@actType", reqModel.type));
                }

                DataSet dsObj = actbll.exportList(strWhere.ToString(), " actStartTime desc ",parms.ToArray());
                if (dsObj.Tables[0] != null && dsObj.Tables[0].Rows.Count > 0)
                {
                    string fileInfo = Common.ExcelHelper.DataToExcel(dsObj.Tables[0], "list" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx", "Activity List");
                    string filePath = Directory.GetCurrentDirectory() + fileInfo;
                    var fileObj = Path.GetFileName(filePath);
                    // read file content
                    byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

                    // set file name and MIME type
                    string fileName = Path.GetFileName(filePath);
                    string mimeType = "application/vnd.ms-excel"; // set MIME type
                    Response.Headers.Add("fileName", fileName);

                    //create FileContentResult and return
                    return File(fileBytes, mimeType, fileName);
                }
                else
                {
                    return new JsonResult(new { status = "fail", message = "High risk characters in paras!" });
                }
            }
        }
    }

}
