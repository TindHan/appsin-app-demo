using app_act.Bizcs.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using app_act.Midcs;

namespace app_act.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActsController : ControllerBase
    {
        [HttpPost(Name = "getActList")]
        public commonResult<act_activitymain> getActList([FromBody] commonRequest reqModel)
        {
            commonResult<act_activitymain> result = new commonResult<act_activitymain>();

            if (reqModel.uid != "" && Common.UtilsHelper.checkUser(reqModel.uid))
            {
                Bizcs.BLL.act_activitymain actbll = new Bizcs.BLL.act_activitymain();
                DataSet dsPsn = actbll.GetList("");
                if (dsPsn != null)
                {
                    List<act_activitymain> actlist = Common.TBToList<act_activitymain>.ConvertToList(dsPsn.Tables[0]);
                    result.status = "success";
                    result.message = "The data is in resData";
                    result.resData = actlist;
                }
                else
                {
                    result.status = "success";
                    result.message = "No data";
                    result.resData = null;
                }
            }
            else
            {
                result.status = "fail";
                result.message = "It's not correct uid!";
                result.resData = null;
            }
            return result;
        }
    }
}
