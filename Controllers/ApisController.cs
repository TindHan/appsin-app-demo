using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using app_act.Midcs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace app_act.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApisController : ControllerBase
    {
        [HttpPost(Name = "handShake")]
        public async Task<IActionResult> handShake([FromBody] jumpkey k)
        {
            string userInfo = "";
            if (!string.IsNullOrEmpty(k.key))
            {
                userInfo = await Common.requestHelper.postRequest
                    (
                    "/api/AppServ/handShake", 
                    "{\"aukey\":\"" + Common.requestHelper.genAukey() + "\",\"args\":\"" + k.key + "\"}"
                    );
            }
            var obj = JObject.Parse(userInfo);
            if (obj["status"].ToString().ToUpper() == "SUCCESS")
            {
                var userObj = obj["resData"][0];
                var psnPk = userObj["psnPK"].ToString();
                Bizcs.BLL.act_psnmain psnBll = new Bizcs.BLL.act_psnmain();
                Bizcs.Model.act_psnmain psnModel=psnBll.GetModel(psnPk);
                if(psnModel != null)
                {
                    psnModel.updateTime = DateTime.Now;
                    psnBll.Update(psnModel);
                }
                else
                {
                    psnModel = new Bizcs.Model.act_psnmain();
                    psnModel.psnPK = psnPk;
                    psnModel.psnName = userObj["psnName"].ToString();
                    psnModel.psnSex = userObj["psnSex"].ToString();
                    psnModel.psnCode = userObj["psnCode"].ToString();
                    psnModel.unitName = userObj["unitName"].ToString();
                    psnModel.deptName = userObj["deptName"].ToString();
                    psnModel.postName = userObj["postName"].ToString();
                    psnModel.unitPK = userObj["unitPK"].ToString();
                    psnModel.deptPK = userObj["deptPK"].ToString();
                    psnModel.psnPK = userObj["psnPK"].ToString();
                    psnModel.updateTime = DateTime.Now;
                    psnModel.psnStatus = 1;
                    psnBll.Add(psnModel);
                }
            }

            return Ok(userInfo);
        }
    }

}
