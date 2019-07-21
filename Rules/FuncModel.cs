using System;

namespace Silt.Client.Rules
{
    /// <summary>
    /// 实体类sys_func 功能
    /// </summary>
    public class FuncModel
    {
        public FuncModel()
        { }
        #region Model
        private string _ffunc_id;
        private string _fparent_id;
        private string _fstatus;
        private string _fcreate_time;
        private string _fupdate_time;
        private string _fcreate_person_id;
        private string _fupdate_person_id;
        private string _fhelp;
        private string _fopen_page;
        private string _finclude_page;
        private string _ficon;
        private string _fopen_icon;
        private decimal _fsort_id;
        private string _fremark;
        private string _fbill_title;
        private string _fname;
        private string _fwinform;

        private string _fpluggableUnit;
        private string _fpluggableUnitName;
        private string _fpluggableUnitAssembly;
        /*
         1	fpluggableUnit	int	4	-1
0	fpluggableUnitName	varchar	200	-1
0	fpluggableUnitAssembly	varchar	200	-1
         */
        
        
        /// <summary>
        /// 
        /// </summary>
        public string ffunc_id
        {
            set { _ffunc_id = value; }
            get { return _ffunc_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fparent_id
        {
            set { _fparent_id = value; }
            get { return _fparent_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fstatus
        {
            set { _fstatus = value; }
            get { return _fstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fcreate_time
        {
            set { _fcreate_time = value; }
            get { return _fcreate_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fupdate_time
        {
            set { _fupdate_time = value; }
            get { return _fupdate_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fcreate_person_id
        {
            set { _fcreate_person_id = value; }
            get { return _fcreate_person_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fupdate_person_id
        {
            set { _fupdate_person_id = value; }
            get { return _fupdate_person_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fhelp
        {
            set { _fhelp = value; }
            get { return _fhelp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fopen_page
        {
            set { _fopen_page = value; }
            get { return _fopen_page; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string finclude_page
        {
            set { _finclude_page = value; }
            get { return _finclude_page; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ficon
        {
            set { _ficon = value; }
            get { return _ficon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fopen_icon
        {
            set { _fopen_icon = value; }
            get { return _fopen_icon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal fsort_id
        {
            set { _fsort_id = value; }
            get { return _fsort_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fremark
        {
            set { _fremark = value; }
            get { return _fremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fbill_title
        {
            set { _fbill_title = value; }
            get { return _fbill_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fname
        {
            set { _fname = value; }
            get { return _fname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fwinform
        {
            set { _fwinform = value; }
            get { return _fwinform; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string fpluggableUnit
        {
            set { _fpluggableUnit = value; }
            get { return _fpluggableUnit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fpluggableUnitName
        {
            set { _fpluggableUnitName = value; }
            get { return _fpluggableUnitName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fpluggableUnitAssembly
        {
            set { _fpluggableUnitAssembly = value; }
            get { return _fpluggableUnitAssembly; }
        }
        #endregion Model
    }
}