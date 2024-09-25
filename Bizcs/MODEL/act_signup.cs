namespace app_act.Bizcs.Model
{
    public class act_signup
    {
        #region Model
        private int _signid;
        private int? _actid;
        private string _psnpk;
        private DateTime? _signtime;
        private int? _ispay;
        private int? _isconfirm;
        private int? _signstatus;
        /// <summary>
        /// 
        /// </summary>
        /// 
        public int signID
        {
            set { _signid = value; }
            get { return _signid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? actID
        {
            set { _actid = value; }
            get { return _actid; }
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
        public DateTime? signTime
        {
            set { _signtime = value; }
            get { return _signtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isPay
        {
            set { _ispay = value; }
            get { return _ispay; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isConfirm
        {
            set { _isconfirm = value; }
            get { return _isconfirm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? signStatus
        {
            set { _signstatus = value; }
            get { return _signstatus; }
        }
        #endregion Model

    }
}
