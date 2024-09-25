using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using System.Text.RegularExpressions;

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
                        psnModel.updateTime = DateTime.Now;
                        new Bizcs.BLL.act_psnmain().Update(psnModel);

                        //create new thread to reset platform token
                        Thread thread = new Thread(() => resetToken(uid));
                        thread.Start();
                        //end new thread

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

        public static async void resetToken(string uid)
        {
           await requestHelper.postRequest(
                        "/api/Appserv/resetToken",
                        "{\"aukey\":\"" + requestHelper.genAukey() + "\",\"args\":\"" + uid + "\"}"
                        );
        }

        public static bool isSafe(string sql)
        {
            string badStr = @"\b(select|update|delete|insert|or|not|like|trancate|into|exec|master|drop|execute|net user|xp_cmdshell|go|create|grant|group_concat|restore|backup|net +localgroup +administrators|iframe|cookie|location|prompt|confirm|script|<a.*|<img.*)\b";
            Regex reg = new Regex(badStr, RegexOptions.IgnoreCase);
            return !reg.IsMatch(sql);
        }
    }
}
