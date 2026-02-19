using System;

namespace app_act.Midcs
{

    public class leaveFlow
    {
        public string aukey { get; set; }
        public string templatePK { get; set; }
        public string flowName { get; set; }
        public string flowDesc { get; set; }
        public string contentUrl { get; set; }
        public int? int1Value { get; set; }
        public string? str1Value { get; set; }
        public DateTime? date1Value { get; set; }
        public string psnPK { get; set; }
        public string createPsnPK { get; set; }
    }
    public class leaveEdit
    {
        public int leaveID { get; set; }
        public string psnPK { get; set; }
        public string leaveType { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public decimal leaveDays { get; set; }
        public string leaveReason { get; set; }
        public int leaveStatus { get; set; }
    }
    public class leaveList
    {
        public int id { get; set; }
        public string leavePK { get; set; }
        public string psnPK { get; set; }
        public string psnName { get; set; }
        public string unitName { get; set; }
        public string deptName { get; set; }
        public string postName { get; set; }
        public string leaveType { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public decimal leaveDays { get; set; }
        public string createPsnPK { get; set; }
        public DateTime createTime { get; set; }
        public int approveStatus { get; set; }
        public int leaveStatus { get; set; }
        public string leaveReason { get; set; }
    }
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
