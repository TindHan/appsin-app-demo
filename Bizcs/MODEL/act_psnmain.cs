namespace app_act.Bizcs.Model
{
    public class act_psnmain
    {
        #region Model
        private string _psnpk;
        private string _psnname;
        private string _unitpk;
        private string _deptpk;
        private string _postpk;
        private string _unitname;
        private string _deptname;
        private string _postname;
        private string _psnsex;
        private string _psncode;
        private DateTime _updatetime;
        private int _psnstatus = 0;
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
        public string psnName
        {
            set { _psnname = value; }
            get { return _psnname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string unitPK
        {
            set { _unitpk = value; }
            get { return _unitpk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string deptPK
        {
            set { _deptpk = value; }
            get { return _deptpk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string postPk
        {
            set { _postpk = value; }
            get { return _postpk; }
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
        public string psnSex
        {
            set { _psnsex = value; }
            get { return _psnsex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string psnCode
        {
            set { _psncode = value; }
            get { return _psncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime updateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int psnStatus
        {
            set { _psnstatus = value; }
            get { return _psnstatus; }
        }
        #endregion Model
    }
}
