using app_act.Midcs;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json.Linq;
using System.Data;

namespace app_act.Common
{
    public class leaveHelper
    {
        public static async Task syncLeaveStatus()
        {
            Bizcs.BLL.leave_list leaveBll = new Bizcs.BLL.leave_list();
            DataSet dsLeave = leaveBll.GetList("approveStatus=0 && leaveStatus=1");

            if (dsLeave?.Tables[0] == null) return;

            List<leaveList> leList = Common.TBToList<leaveList>.ConvertToList(dsLeave.Tables[0]);
            if (leList.Count == 0) return;

            var invokeResult = "";
            foreach (var item in leList)
            {
                invokeResult = await Common.requestHelper.postRequest
                        (
                        "/api/AppServ/getFlowInstance",
                        "{\"aukey\":\"" + Common.requestHelper.genAukey() + "\",\"args\":\"" + item.leavePK + "\"}"
                        );
                var obj = JObject.Parse(invokeResult);
                if (obj["status"].ToString().ToUpper() == "SUCCESS")
                {
                    if (obj["resData"][0]["isEnd"].ToString() == "1"
                        && obj["resData"][0]["isPass"].ToString() == "1")
                    {
                        leaveBll.sycnApproveStatus(item.leavePK, 1);
                    }
                    if (obj["resData"][0]["isEnd"].ToString() == "1"
                        && obj["resData"][0]["isPass"].ToString() == "-1")
                    {
                        leaveBll.sycnApproveStatus(item.leavePK, 12);
                    }
                    if (obj["resData"][0]["isEnd"].ToString() == "0"
                        && obj["resData"][0]["isError"].ToString() == "1")
                    {
                        leaveBll.sycnApproveStatus(item.leavePK, 11);
                    }
                }
            }

        }


    }
}
