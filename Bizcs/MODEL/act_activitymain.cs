namespace app_act.Bizcs.Model
{
    public class act_activitymain
    {
        public act_activitymain()
        { }
        #region Model
        private int _key;
        private int _actid;
        private string _actname;
        private string _actdesc;
        private DateTime? _actstarttime;
        private DateTime? _actendtime;
        private DateTime? _signupstarttime;
        private DateTime? _signupendtime;
        private string _acttype;
        private string _actway;
        private string _acturl;
        private string _actaddr;
        private int? _actmemo1;
        private int? _actmemo2;
        private int? _actmemo3;
        private int? _actmemo4;
        private int? _actmemo5;
        private int? _actstatus;
        /// <summary>
        /// 
        /// </summary>
        /// 
        public int key
        {
            set { _key = value; }
            get { return _key; }
        }
        public int actID
        {
            set { _actid = value; }
            get { return _actid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string actName
        {
            set { _actname = value; }
            get { return _actname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string actDesc
        {
            set { _actdesc = value; }
            get { return _actdesc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? actStartTime
        {
            set { _actstarttime = value; }
            get { return _actstarttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? actEndTime
        {
            set { _actendtime = value; }
            get { return _actendtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? signupStartTime
        {
            set { _signupstarttime = value; }
            get { return _signupstarttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? signupEndTime
        {
            set { _signupendtime = value; }
            get { return _signupendtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string actType
        {
            set { _acttype = value; }
            get { return _acttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string actWay
        {
            set { _actway = value; }
            get { return _actway; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string actUrl
        {
            set { _acturl = value; }
            get { return _acturl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string actAddr
        {
            set { _actaddr = value; }
            get { return _actaddr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? actMemo1
        {
            set { _actmemo1 = value; }
            get { return _actmemo1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? actMemo2
        {
            set { _actmemo2 = value; }
            get { return _actmemo2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? actMemo3
        {
            set { _actmemo3 = value; }
            get { return _actmemo3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? actMemo4
        {
            set { _actmemo4 = value; }
            get { return _actmemo4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? actMemo5
        {
            set { _actmemo5 = value; }
            get { return _actmemo5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? actStatus
        {
            set { _actstatus = value; }
            get { return _actstatus; }
        }
        #endregion Model
    }
}
