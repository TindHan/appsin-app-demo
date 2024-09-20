namespace app_act.Midcs
{
    public class jumpkey
    {
        public string key { get; set; }
    }
    public class commonRequest
    {
        public string uid { get; set; }
        public string args { get; set; }
    }
    public class commonResult<T>
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<T> resData { get; set; }
    }
}
