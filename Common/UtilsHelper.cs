using Newtonsoft.Json.Linq;
using System;

namespace app_act.Common
{
    public class UtilsHelper
    {
        public async static Task<bool> resetToken(string aukey, string uid) //uid===psnPK
        {
            string res = await requestHelper.postRequest
            (
                    "/api/Appserv/resetToken",
                    "{\"aukey\":\"" + requestHelper.genAukey() + "\",\"args\":\"" + uid + "\"}"
                    );
            var resObj = JObject.Parse(res);
            if (resObj["status"].ToString().ToLower() == "success")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkUser(string uid)
        {
            if (uid != null || uid != "")
            {
                Bizcs.Model.act_psnmain psnModel = new Bizcs.BLL.act_psnmain().GetModel(uid);
                if (psnModel != null)
                {
                    if (psnModel.updateTime.AddHours(1) >= DateTime.Now)//one hour valid,timeout will be log out
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            { return false; }

        }
    }
}
