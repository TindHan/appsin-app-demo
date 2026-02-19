namespace app_act.Bizcs.Model
{
    public class leave_list
    {
        #region Model
        private int _leaveid;
        private string _leavepk;
        private string _psnpk;
        private string _unitname;
        private string _deptname;
        private string _postname;
        private string _leavetype;
        private DateTime _starttime;
        private DateTime _endtime;
        private decimal _leavedays;
        private string _createpsnpk;
        private DateTime? _createtime;
        private int _approvestatus;
        private int _leavestatus;
        private string _leavereason;
        /// <summary>
        /// 
        /// </summary>
        public int leaveID
        {
            set { _leaveid = value; }
            get { return _leaveid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string leavePK
        {
            set { _leavepk = value; }
            get { return _leavepk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string psnPK
        {
            set { _psnpk = value; }
            get { return _psnpk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string unitName
        {
            set { _unitname = value; }
            get { return _unitname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string deptName
        {
            set { _deptname = value; }
            get { return _deptname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string postName
        {
            set { _postname = value; }
            get { return _postname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string leaveType
        {
            set { _leavetype = value; }
            get { return _leavetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime startTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime endTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal leaveDays
        {
            set { _leavedays = value; }
            get { return _leavedays; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string createPsnPk
        {
            set { _createpsnpk = value; }
            get { return _createpsnpk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int approveStatus
        {
            set { _approvestatus = value; }
            get { return _approvestatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int leaveStatus
        {
            set { _leavestatus = value; }
            get { return _leavestatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string leaveReason
        {
            set { _leavereason = value; }
            get { return _leavereason; }
        }
        #endregion Model
    }
}
