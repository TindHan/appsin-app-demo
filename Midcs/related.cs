using Microsoft.AspNetCore.Authorization;

namespace app_act.Midcs
{
    public class jumpkey
    {
        public string key { get; set; }
    }
    public class listRequest
    {
        public string uid { get; set; }
        public string kw { get; set; }
        public string type { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string status { get; set; }
        public int pageIndex {  get; set; }
        public int pageSize { get; set; }
    }
    public class detailRequest
    {
        public string uid { get; set; }
        public string objID { get; set; }
        public string condition { get; set; }
    }
    public class commonRequest<T>
    {
        public string uid { get; set; }
        public string args { get; set; }
        public List<T> reqData { get; set; }
    }
    public class commonResult<T>
    {
        public string status { get; set; }
        public string message { get; set; }
        public int number {  get; set; }
        public List<T> resData { get; set; }
    }
}
