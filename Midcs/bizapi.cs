using System;

namespace app_act.Midcs
{
    public class editActivity
    {
        public string actName { get; set; }
        public string actType { get; set; }
        public string actStartTime { get; set; }
        public string actEndTime { get; set; }
        public string signupStartTime { get; set; }
        public string signupEndTime { get; set; }
        public string actAddr { get; set; }
        public string actDesc { get; set; }
        public string actStatus { get; set; }
        public string actID { get; set; }
    }


    public class listActivity
    {

    }

    public class listSign
    {
        public int key { get; set; }
        public int signID { get; set; }
        public int actID { get; set; }
        public string actName { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string address { get; set; }
        public string psnPK { get; set; }
        public string psnName { get; set; }
        public string unitName { get; set; }
        public string deptName { get; set; }
        public string postName { get; set; }
        public DateTime signTime { get; set; }
        public string signWay { get; set; }
        public int isPay { get; set; }
        public int isConfirm { get; set; }
        public int signStatus { get; set; }
    }

}
