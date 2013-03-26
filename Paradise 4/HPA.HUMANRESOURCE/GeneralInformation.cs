using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HPA.Component;
using HPA.Common;
using System.IO;
using System.Diagnostics;

namespace HPA.HumanResource
{
    public partial class GeneralInformation : HPA.Component.Framework.CCommonForm
    {
        protected DataTable dtEmployeeTypeList = null;
        protected DataTable dtAttendanceRegisterList = null;
        protected DataTable dtBranch = null;
        protected DataTable dtContractType = null;
        protected DataTable dtDivision = null;
        protected DataTable dtDepartment = null;
        protected DataTable dtSection = null;
        protected DataTable dtGroup = null;
        protected DataTable dtPosition = null;
        protected DataTable dtProvince = null;
        protected DataTable dtTmpProvince = null;
        protected DataTable dtIDProvince = null;
        protected DataTable dtDistrict = null;
        protected DataTable dtTmpDistrict = null;
        protected DataTable dtLevel = null;
        protected DataTable dtRate = null;
        protected DataTable dtWorkingPlace = null;
        protected DataTable dtArea = null;
        protected DataTable dtAreaSup = null;
        protected bool isOnDelete = false;


        protected const string FalseDay = "FalseDay";
        protected bool isAddNewEmployee = false;
        protected bool isNewContract = false;

        private DataTable dtEmployeeInfo = null;
        protected DataTable dtOldEmployeeInfo = null;

        protected DataTable dtFamilyinformation = null;
        protected DataTable dtRelation = null;

        protected DataView dvBranch = null;
        protected DataView dvDivision = null;
        protected DataView dvDepartment = null;
        protected DataView dvSection = null;
        protected DataView dvGroup = null;

        // For Health
        protected DataTable dtHealthList = null;
        protected DataTable dtHealthStatusList = null;
        protected DataTable dtLoodList = null;
        protected const string HealthID = "HealthID";
        protected const string ExaminationDate = "ExaminationDate";
        protected const string HospitalName = "HospitalName";
        protected const string Height_D = "Height";
        protected const string Weight = "Weight";
        protected const string BloodID = "BloodID";
        protected const string Note = "Note";
        protected const string CompanyPay = "CompanyPay";
        protected const string Vision = "Vision";
        protected const string ChildrenNumber = "ChildrenNumber";
        protected const string HealthStatusID = "HealthStatusID";

        //For Education
        protected DataTable dtEducationList = null;
        protected DataTable dtSchoolType = null;
        protected DataTable dtGraduateLeval = null;

        protected const string TypeSchoolID = "TypeSchoolID";
        protected const string MainSubject = "MainSubject";
        protected const string StudyFrom = "StudyFrom";
        protected const string StudyTo = "StudyTo";
        protected const string GraduateLevelID = "GraduateLevelID";
        protected const string EducationHistoryID = "EducationHistoryID";
        protected const string Place = "Place";

        // For Internaltraining
        protected DataTable dtTrainingList = null;
        protected DataTable dtTrainingCourse = null;

        protected const string InternalTrainingID = "InternalTrainingID";
        protected const string DepartmentID = "DepartmentID";
        protected const string InternalTrainingCourseID = "InternalTrainingCourseID";
        protected const string FromDate = "FromDate";
        protected const string ToDate = "ToDate";
        protected const string CompanyPaid = "CompanyPaid";
        protected const string ComAmount = "ComAmount";
        protected const string EmpAmount = "EmpAmount";
        protected const string SubmitCertificate = "SubmitCertificate";
        protected const string CommitFrom = "CommitFrom";
        protected const string CommitTo = "CommitTo";
        // For Experience
        protected DataTable dtExperience = null;
        protected const string WorkingHistoryID = "WorkingHistoryID";
        protected const string CompanyName_D = "CompanyName";
        protected const string CompanyAddress = "CompanyAddress";
        protected const string Jobtitle = "Jobtitle";
        protected const string Department = "Department";
        protected const string WorkPosition = "WorkPosition";
        protected const string LastSalary = "LastSalary";
        protected const string WorkFrom = "WorkFrom";
        protected const string WorkTo = "WorkTo";
        protected const string ReasonResign = "ReasonResign";
        protected const string RefName = "RefName";
        protected const string RefEmail = "RefEmail";
        protected const string RefPhone = "RefPhone";
        protected const string RefAddress = "RefAddress";
        protected const string RefPosition = "RefPosition";
        protected const string WorkingPlaceID = "WorkingPlaceID";
        protected const string AreaID = "AreaID";
        protected const string LineManagerID = "LineManagerID";
        protected const string LineManagerName = "LineManagerName";
        protected const string AreaSupID = "AreaSupID";
        protected const string BankID = "BankID";
        protected const string TaxRegNo = "TaxRegNo";
        protected const string BankName = "BankName";
        protected const string AccountNo = "AccountNo";
        protected const string DAB = "dab";
        // For Options
        protected DataTable dtOptions = null;

        private string[] employeeInfo = null;
        private bool IsAutoID = false;
        
        public GeneralInformation()
        {
            InitializeComponent();
            //Load title
            Control.ControlCollection ctrls = this.Controls;
            HPA.Common.UIMessage.LoadLableName(ref ctrls);
            HPA.Common.FocusControlsIndicator fc = new FocusControlsIndicator();
            fc.LoadAddGotFocus(this);
            if (UIMessage.ENTER_TO_TAB)
                fc.key_enter(this);
        }
        public override bool InitializeData()
        {
            try
            {
                
                if (!initFomrsData())
                    return false;
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".InitializeData()", null);
                return false;
            }

            return true;
        }
        public override void SetData(object objParam)
        {
            string strFormTitle = "";
            try
            {
                strFormTitle = UIMessage.Get_Message("MnuHRS012");
                if (strFormTitle.Equals(objParam.ToString()) || "".Equals(objParam.ToString()))
                {
                    this.Text = strFormTitle;
                    return;
                }
                employeeInfo = (string[])objParam;
                if (employeeInfo != null)
                {
                    txtEmployeeID.Text = employeeInfo[0];
                    this.Text = string.Format("{0} : {1} - {2}", strFormTitle, employeeInfo[0], employeeInfo[1]);
                }
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".SetData()", null);
                return;
            }
        }
        private bool initFomrsData()
        {
            try
            {
                //Nhan dien su dung cap phat tu dong Ma nhan vien
                if (HPA.Common.Methods.getParameterValue("EMPLOYEEIDAUTO").ToString() == "0")
                {
                    btnIDauto.Visible = false;
                }
                //Load combobox data
                txtEmployeeID.Focus();
                LoadComboboxData();
                // get param
                if (!txtEmployeeID.Text.Trim().Equals(""))
                {
                    LoadEmployeeInformation();
                    //DirtyData = false;
                }
                cbxDivision.EditValue = 0;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadOptions()
        {
            dtOptions = DBEngine.execReturnDataTable("sp_get_Employee_Options_List", "@EmployeeID", txtEmployeeID.Text, "@LanguageID", UIMessage.languageID.ToString(), CommonConst.A_LoginID, UserID);
            grdEmpOptions.DataSource = dtOptions;
        }
        private void ResetOptions()
        {
            try
            {
                if (DirtyData == true)
                {
                    dtOptions.RejectChanges();
                    grdEmpOptions.DataSource = dtOptions;
                    DirtyData = false;
                    btnFWAdd.Enabled = false;
                    btnFWDelete.Enabled = false;
                }
            }
            catch (Exception)
            {
                //HPA.Common.Helper.ShowException(e, this.Name + ".OnReset()", null);
                MessageBox.Show(this.Name + ".OnReset");
            }
        }
        private bool CommitOptions()
        {
            try
            {

                try
                {
                    DBEngine.beginTransaction();
                    // delete tranfer history
                    if (dtOptions != null && dtOptions.Rows.Count > 0)
                        foreach (DataRow dr in dtOptions.Rows)
                        {

                                  DBEngine.exec("sp_save_Employee_Options",
                                    "@EmployeeID", dr[CommonConst.EmployeeID],
                                    "@OptionName", dr["OptionName"],
                                    "@OptValue", dr["OptValue"],
                                    
                                   CommonConst.A_LoginID, UserID
                                    );
                        }
                    DBEngine.commit();
                }
                catch (Exception ex)
                {
                    // dtEmployeeInformation.RejectChanges();
                    DBEngine.rollback();
                    throw (ex);
                }

            }
            catch (Exception e)
            {

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".Commit()", null);

                return false;
            }
            LoadOptions();
            this.DirtyData = false;
            btnFWDelete.Enabled = false;
            btnFWAdd.Enabled = false;
            return true;
            //fghjk
        }


        private void LoadFamilyInformation()
        {
            //Load Rlation List
            dtRelation = DBEngine.execReturnDataTable("Gen_Relation_List");
            cbxRelation.Properties.DataSource = dtRelation;
            cbxRelation.EditValue = -1;
            rpRelationID.DataSource = dtRelation;
            dtFamilyinformation = DBEngine.execReturnDataTable("HR_person_Family_List","@EmployeeID",txtEmployeeID.Text,HPA.Common.CommonConst.SQL_LoginID,UIMessage.userID);
            grdFamilyInfo.DataSource = dtFamilyinformation;
            // register data change information
            dtFamilyinformation.ColumnChanged += new DataColumnChangeEventHandler(DataColumnChanged);
            dtFamilyinformation.RowChanged += new DataRowChangeEventHandler(DataRowChange);
            if (dtFamilyinformation.Rows.Count <= 0)
                CRowUtility.addNewRow(dtFamilyinformation, "EmployeeID", txtEmployeeID.Text);
            /*
            //Binding data
            txtFullName.DataBindings.Clear();
            //dtpBirthday.DataBindings.Clear();
            cbxRelation.DataBindings.Clear();
            txtTaxNo.DataBindings.Clear();
            txtCareer.DataBindings.Clear();
            txtWorkingPlace.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtIncome.DataBindings.Clear();
            ckbDependance.DataBindings.Clear();

            txtFullName.DataBindings.Add(CommonConst.EDIT_VALUE, dtFamilyinformation, "Name");
           // dtpFamilyBirthday.DataBindings.Add(CommonConst.EDIT_VALUE, dtFamilyinformation, "Birthday");
            const string strRelation = "RelationID";
            if (dtFamilyinformation.Rows[0][strRelation] == DBNull.Value) dtFamilyinformation.Rows[0][strRelation] = -1;
            cbxRelation.DataBindings.Add(CommonConst.EDIT_VALUE, dtFamilyinformation, strRelation);
            txtTaxNo.DataBindings.Add(CommonConst.EDIT_VALUE, dtFamilyinformation, "TaxNo");
            txtCareer.DataBindings.Add(CommonConst.EDIT_VALUE, dtFamilyinformation, "Career");
            txtWorkingPlace.DataBindings.Add(CommonConst.EDIT_VALUE, dtFamilyinformation, "WorkingPlace");
            txtAddress.DataBindings.Add(CommonConst.EDIT_VALUE, dtFamilyinformation, "Address");
            txtIncome.DataBindings.Add(CommonConst.EDIT_VALUE, dtFamilyinformation, "Income");
            ckbDependance.DataBindings.Add(CommonConst.EDIT_VALUE, dtFamilyinformation, "TaxDependant");
             * */
            DirtyData = false;
            
        }

        void DataRowChange(object sender, DataRowChangeEventArgs e)
        {
            DirtyData = true;
        }

        void DataColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }

        private void LoadEmployeeInformation()
        {
            
            dtEmployeeInfo = DBEngine.execReturnDataTable("HR_Employee_General_List",CommonConst.A_EmployeeID,txtEmployeeID.Text,
                CommonConst.A_LoginID, UserID);
            dtOldEmployeeInfo = dtEmployeeInfo.Copy();
            //if (dtEmployeeInfo.Rows.Count <= 0)
            //    return;
            dtEmployeeInfo.RowChanged += new DataRowChangeEventHandler(dtEmployeeInformation_RowChanged);
            dtEmployeeInfo.ColumnChanged += new DataColumnChangeEventHandler(dtEmployeeInformation_ColumnChanged);

            if (dtEmployeeInfo.Rows.Count <= 0)
            {
                if (!IsAutoID)
                {
                    CRowUtility.addNewRow(dtEmployeeInfo, CommonConst.EmployeeID, txtEmployeeID.Text, "Sex", true
                        , "Nationality", "Việt Nam", "Ethnic", "Kinh");
                    txtLastname.Focus();
                    isAddNewEmployee = true;
                }
                else
                {
                    if (isAddNewEmployee == true)
                    {
                        CRowUtility.addNewRow(dtEmployeeInfo, CommonConst.EmployeeID, txtEmployeeID.Text, "Sex", true
                          , "Nationality", "Việt Nam", "Ethnic", "Kinh");
                        txtLastname.Focus();
                    }
                    else
                    {
                        txtEmployeeID.SelectAll();
                        txtEmployeeID.Focus();
                    }
                }
            }
            else
            {
                isAddNewEmployee = false;
                if (dtEmployeeInfo.Rows[0]["ContractCode"] == DBNull.Value || dtEmployeeInfo.Rows[0]["ContractCode"].ToString().Equals("004") || dtEmployeeInfo.Rows[0]["ContractCode"].ToString().Equals("006"))
                isNewContract = true;
            else
                isNewContract = false;
            }
            BindingEmployeeInfo();
            cbxContractType.Enabled = (isAddNewEmployee||isNewContract);
        }
        private void BindingEmployeeInfo()
        {
            // biding data
            if (dtEmployeeInfo != null && dtEmployeeInfo.Rows.Count > 0)
            {
                // dtEmployeeInfo.Rows[0].BeginEdit();
                // general information:
                txtResidentAdd.DataBindings.Clear();
                txtTitle.DataBindings.Clear();
                txtFirstName.DataBindings.Clear();
                txtLastname.DataBindings.Clear();
                radSex.DataBindings.Clear();
                cbxBranch.DataBindings.Clear();
                cbxDivision.DataBindings.Clear();
                cbxDepartment.DataBindings.Clear();
                cbxSection.DataBindings.Clear();
                cbxGroup.DataBindings.Clear();
                txtWard.DataBindings.Clear();
                txtTmpWard.DataBindings.Clear();
                cbxRate.DataBindings.Clear();
                cbxLevel.DataBindings.Clear();
                cbxProvince.DataBindings.Clear();
                cbxDistrict.DataBindings.Clear();
                cbxTmpProvince.DataBindings.Clear();
                cbxID_Province.DataBindings.Clear();
                cbxTmpDistrict.DataBindings.Clear();

                txtEmployeeCard.DataBindings.Clear();
                txtEmployeeID.DataBindings.Clear();
                txtOfficeEmail.DataBindings.Clear();
                txtMobilePhone.DataBindings.Clear();
                dtpJoinDate.DataBindings.Clear();
                cbxPosition.DataBindings.Clear();
                dtpPositionChangedDate.DataBindings.Clear();
                dtpDivDeptChangedDate.DataBindings.Clear();
                txtOfficeExt.DataBindings.Clear();
                txtNoteBasicInformation.DataBindings.Clear();
                dtpBirthday.DataBindings.Clear();
                ckbMarried.DataBindings.Clear();
                txtNationality.DataBindings.Clear();
                txtBirthPlace.DataBindings.Clear();
                txtNative.DataBindings.Clear();
                txtEthnic.DataBindings.Clear();
                txtReligion.DataBindings.Clear();
                txtHomephone.DataBindings.Clear();
                txtHomeEmail.DataBindings.Clear();
                txtResidentAddress.DataBindings.Clear();
                txtTemporaryPhone.DataBindings.Clear();
                txtTemporaryAddress.DataBindings.Clear();
                txtHomeAddressNotes.DataBindings.Clear();
                txtIDForBankTransfer.DataBindings.Clear();
                txtIDNumber.DataBindings.Clear();
                txtIDIssuePlace.DataBindings.Clear();
                dtpIDIssueDate.DataBindings.Clear();
                txtTaxNo.DataBindings.Clear();
                cbxBankName.DataBindings.Clear();
                txtBankAccountNo.DataBindings.Clear();
                txtPassportNumber.DataBindings.Clear();
                dtpPassportExpire.DataBindings.Clear();
                dtpPassportIssueDate.DataBindings.Clear();
                txtPassportPlace.DataBindings.Clear();
                imgEmployeeImage.DataBindings.Clear();
                txtEducationalBase.DataBindings.Clear();
                ckbFalseDay.DataBindings.Clear();
                cbxContractType.DataBindings.Clear();
                dtpProbationEndDate.DataBindings.Clear();
                dtpContractFromDate.DataBindings.Clear();
                dtpContractToDate.DataBindings.Clear();
                cbxWorkingPlace.DataBindings.Clear();
                cbxArea.DataBindings.Clear();
                txtLineManager.DataBindings.Clear();
                txtLineManagerName.DataBindings.Clear();
                cbxAreaSup.DataBindings.Clear();
                cbxEmployeeTypeList.DataBindings.Clear();
                cbxAccCodeList.DataBindings.Clear();

                txtResidentAdd.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "ResidentAdd");
                txtTitle.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "Title");
                txtFirstName.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "FirstName");
                txtLastname.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "LastName");
                radSex.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "Sex");
                const string strBranchID = "BranchID";
                if (dtEmployeeInfo.Rows[0][strBranchID] == DBNull.Value) dtEmployeeInfo.Rows[0][strBranchID] = -1;
                cbxBranch.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, strBranchID);
                const string strDivision = "DivisionID";
                if (dtEmployeeInfo.Rows[0][strDivision] == DBNull.Value) dtEmployeeInfo.Rows[0][strDivision] = -1;
                cbxDivision.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, strDivision);
                const string strDepartment = "DepartmentID";
                if (dtEmployeeInfo.Rows[0][strDepartment] == DBNull.Value) dtEmployeeInfo.Rows[0][strDepartment] = -1;
                cbxDepartment.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, strDepartment);
                const string strSection = "SectionID";
                if (dtEmployeeInfo.Rows[0][strSection] == DBNull.Value) dtEmployeeInfo.Rows[0][strSection] = -1;
                cbxSection.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, strSection);
                const string strGroup = "GroupID";
                if (dtEmployeeInfo.Rows[0][strGroup] == DBNull.Value) dtEmployeeInfo.Rows[0][strGroup] = "-1";
                cbxGroup.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, strGroup);
                const string strProvinceID = "ProvinceID";
                if (dtEmployeeInfo.Rows[0][strProvinceID] == DBNull.Value) dtEmployeeInfo.Rows[0][strProvinceID] = "-1";
                cbxProvince.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, strProvinceID);
                const string strDistrictID = "DistrictID";
                if (dtEmployeeInfo.Rows[0][strDistrictID] == DBNull.Value) dtEmployeeInfo.Rows[0][strDistrictID] = "-1";
                cbxDistrict.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, strDistrictID);
                const string tmpProvinceID = "tmpProvinceID";
                if (dtEmployeeInfo.Rows[0][tmpProvinceID] == DBNull.Value) dtEmployeeInfo.Rows[0][tmpProvinceID] = "-1";
                cbxTmpProvince.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, tmpProvinceID);
                const string ID_ProvinceID = "ID_ProvinceID";
                if (dtEmployeeInfo.Rows[0][ID_ProvinceID] == DBNull.Value) dtEmployeeInfo.Rows[0][ID_ProvinceID] = "-1";
                cbxID_Province.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, ID_ProvinceID);

                const string tmpDistrictID = "tmpDistrictID";
                if (dtEmployeeInfo.Rows[0][tmpDistrictID] == DBNull.Value) dtEmployeeInfo.Rows[0][tmpDistrictID] = "-1";
                cbxTmpDistrict.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, tmpDistrictID);

                txtEmployeeCard.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "CardID");
                txtEmployeeID.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "EmployeeID");
                txtOfficeEmail.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "Email");
                txtMobilePhone.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "MobilePhone");
                dtpJoinDate.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "HireDate");
                const string strPosition = "PositionID";
                if (dtEmployeeInfo.Rows[0][strPosition] == DBNull.Value) dtEmployeeInfo.Rows[0][strPosition] = -1;
                cbxPosition.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, strPosition);
                dtpPositionChangedDate.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "PositionChangedDate");
                dtpDivDeptChangedDate.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "SectionChangedDate");
                txtOfficeExt.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "Extension");
                txtNoteBasicInformation.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "BasicInfoNotes");
                dtpBirthday.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "Birthday");
                ckbMarried.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "Marital");
                txtNationality.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "Nationality");
                txtBirthPlace.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "BirthPlace");
                txtNative.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "NativeCountry");
                txtEthnic.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "Ethnic");
                txtReligion.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "Religion");
                txtHomephone.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "HomePhone");
                txtHomeEmail.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "HomeEmail");
                txtResidentAddress.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "HomeAddress");
                txtTemporaryPhone.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "TemporaryPhone");
                txtTemporaryAddress.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "TemporaryAddress");
                txtHomeAddressNotes.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "HomeNotes");
                txtIDForBankTransfer.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "IDForBankTransfer");
                txtIDNumber.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "ID_Number");
                txtIDIssuePlace.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "ID_Issue_Place");
                dtpIDIssueDate.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "ID_Issue_Date");
                txtPassportNumber.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "PassportNo");
                dtpPassportExpire.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "PassportExpiredDate");
                dtpPassportIssueDate.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "PassportIssueDate");
                txtPassportPlace.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "PassportPlace");
                imgEmployeeImage.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "PhotoImage");
                txtWard.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "Ward");
                txtTmpWard.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "tmpWard");
                txtEducationalBase.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "EducationalBase");
                cbxLevel.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "LevelID");
                cbxRate.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "RateID");
                ckbFalseDay.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, FalseDay);

                if (dtEmployeeInfo.Rows[0]["ContractCode"] == DBNull.Value) dtEmployeeInfo.Rows[0]["ContractCode"] = "-1";
                cbxContractType.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "ContractCode");
                dtpProbationEndDate.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "ProbationEndDate");
                dtpContractFromDate.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "ContractStartDay");
                dtpContractToDate.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "ContractEndDay");
                //dtEmployeeInfo.Rows[0].EndEdit();
                if (dtEmployeeInfo.Rows[0][WorkingPlaceID] == DBNull.Value) dtEmployeeInfo.Rows[0][WorkingPlaceID] = -1;
                cbxWorkingPlace.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, WorkingPlaceID);
                if (dtEmployeeInfo.Rows[0][AreaID] == DBNull.Value) dtEmployeeInfo.Rows[0][AreaID] = -1;
                cbxArea.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, AreaID);
                txtLineManager.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, LineManagerID);
                txtLineManagerName.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, LineManagerName);
                cbxAreaSup.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, AreaSupID);
                cbxEmployeeTypeList.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "EmployeeTypeID");
                cbxAccCodeList.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, "BADGENUMBER");

                txtTaxNo.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, TaxRegNo);
                if (dtEmployeeInfo.Rows[0][BankID] == DBNull.Value) dtEmployeeInfo.Rows[0][BankID] = -1;
                cbxBankName.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, BankID);
                txtBankAccountNo.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeInfo, AccountNo);

                DirtyData = false;
            }
        }
        void dtEmployeeInformation_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }

        void dtEmployeeInformation_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DirtyData = true;
        }

        private void LoadComboboxData()
        {
            try
            { 
                //Load bank lisk
                cbxBankName.Properties.DataSource = DBEngine.execReturnDataTable("MD_BankSetting_List");
                //Load Contract Type
                dtContractType = DBEngine.execReturnDataTable("MD_ContractType_List");
                cbxContractType.Properties.DataSource = dtContractType;

                //Load Employee Type
                dtEmployeeTypeList = DBEngine.execReturnDataTable("sp_EmployeeTypeList",CommonConst.A_LoginID,UserID);
                cbxEmployeeTypeList.Properties.DataSource = dtEmployeeTypeList;

                
                dtContractType.PrimaryKey = new DataColumn[] { dtContractType.Columns["ContractCode"] };
                // load Banch
                dtBranch = DBEngine.execReturnDataTable("Gen_Branch_List");
                dvBranch = dtBranch.DefaultView;
                // biding data
                cbxBranch.Properties.DataSource = dvBranch;
                cbxBranch.EditValue = 2;
                //Load division
                dtDivision = DBEngine.execReturnDataTable("Gen_Division_List");
                dvDivision = dtDivision.DefaultView;
                // biding data
                cbxDivision.Properties.DataSource = dvDivision;
                cbxDivision.EditValue = 12;
                //Load department
                dtDepartment = DBEngine.execReturnDataTable("Gen_Department_List", CommonConst.A_LoginID, UserID);
                dvDepartment = dtDepartment.DefaultView;
                // biding data
                cbxDepartment.Properties.DataSource = dvDepartment;
                cbxDepartment.EditValue = -1;
                //Load section
                dtSection = DBEngine.execReturnDataTable("Gen_Section_List", CommonConst.A_LoginID, UserID);
                dvSection = dtSection.DefaultView;
                // biding data
                cbxSection.Properties.DataSource = dvSection;
                cbxSection.EditValue = -1;
                //Load group
                dtGroup = DBEngine.execReturnDataTable("Gen_Group_List", CommonConst.A_LoginID, UserID);
                dvGroup = dtGroup.DefaultView;
                // biding data
                cbxGroup.Properties.DataSource = dvGroup;
                cbxGroup.EditValue = -1;
                //Load position
                dtPosition = DBEngine.execReturnDataTable("Gen_Position_List");
                // biding data
                cbxPosition.Properties.DataSource = dtPosition;
                cbxPosition.EditValue = -1;

                dtDistrict = DBEngine.execReturnDataTable("Gen_District_List", CommonConst.A_LoginID, UserID);
                dtProvince = DBEngine.execReturnDataTable("Gen_Province_List", CommonConst.A_LoginID, UserID);
                dtTmpDistrict = DBEngine.execReturnDataTable("Gen_District_List", CommonConst.A_LoginID, UserID);
                dtTmpProvince = DBEngine.execReturnDataTable("Gen_Province_List", CommonConst.A_LoginID, UserID);
                dtIDProvince = DBEngine.execReturnDataTable("Gen_Province_List", CommonConst.A_LoginID, UserID);
                dtLevel = DBEngine.execReturnDataTable("Gen_Level_List", CommonConst.A_LoginID, UserID);
                dtRate = DBEngine.execReturnDataTable("Gen_Rate_List", CommonConst.A_LoginID, UserID);
                dtWorkingPlace = DBEngine.execReturnDataTable("Select * from tblWorkingPlace");
                dtArea = DBEngine.execReturnDataTable("Select * from tblArea");
                dtAreaSup = DBEngine.execReturnDataTable("Select * from tblAreaSupervisor");
                cbxWorkingPlace.Properties.DataSource = dtWorkingPlace;
                cbxArea.Properties.DataSource = dtArea;
                cbxAreaSup.Properties.DataSource = dtAreaSup;
                cbxLevel.Properties.DataSource = dtLevel;
                cbxRate.Properties.DataSource = dtRate;
                cbxDistrict.Properties.DataSource = dtDistrict;
                cbxDistrict.EditValue = "-1";
                cbxTmpDistrict.Properties.DataSource = dtTmpDistrict;
                cbxTmpDistrict.EditValue = "-1";
                cbxTmpProvince.Properties.DataSource = dtTmpProvince;
                cbxTmpProvince.EditValue = "-1";
                cbxProvince.Properties.DataSource = dtProvince;
                cbxProvince.EditValue = "-1";

                cbxID_Province.Properties.DataSource = dtProvince;
                cbxID_Province.EditValue = "-1";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void cbxBranch_EditValueChanged(object sender, EventArgs e)
        {
            if (dvDivision != null)
            {
                string brachID = cbxBranch.EditValue.ToString();
                dvDivision.RowFilter = string.Format("BranchID = {0}", brachID);
            }
        }

        private void cbxDivision_EditValueChanged(object sender, EventArgs e)
        {
            if (dvDepartment != null)
            {
                string divisionID = cbxDivision.EditValue.ToString();
                dvDepartment.RowFilter = string.Format("DivisionID = {0}", divisionID);
                
            }
        }

        private void cbxDepartment_EditValueChanged(object sender, EventArgs e)
        {
            if (dvSection != null)
            {
                string departmentID = cbxDepartment.EditValue.ToString();
                dvSection.RowFilter = string.Format("DepartmentID = {0}", departmentID);
                const string strSection = "SectionID";
                dtEmployeeInfo.Rows[0][strSection] = CommonConst.NAG_ONCE;
                cbxSection.EditValue = CommonConst.NAG_ONCE;
            }
            //else
            //{
            //    const string strSection = "SectionID";
            //    dtEmployeeInfo.Rows[0][strSection] = -1;
            //}
        }

        private void cbxSection_EditValueChanged(object sender, EventArgs e)
        {
            if (dvGroup != null)
            {
                string sectionID = cbxSection.EditValue.ToString();
                dvGroup.RowFilter = string.Format("DivisionID = {0}", sectionID);
                const string strGroup = "GroupID";
                dtEmployeeInfo.Rows[0][strGroup] = CommonConst.NAG_ONCE;
                cbxGroup.EditValue = CommonConst.NAG_ONCE;
            }
        }

        private void txtEmployeeID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                try
                {
                    // show employeeID list
                    object obj;
                    CommonForm.EmployeeIDList employeeList = new CommonForm.EmployeeIDList();
                    OpenObject("HPA.CommonForm", "EmployeeIDList", true, null, out obj);
                    txtEmployeeID.Text = ((string [])obj)[0];
                    if (txtEmployeeID.Text.Trim().Equals(string.Empty))
                        return;
                    //Show infomation
                    //LoadEmployeeInformation();
                    txtLastname.Focus();
                    //LoadFamilyInformation();
                }
                catch (Exception ex)
                {
                    HPA.Common.Helper.ShowException(ex, this.Name, "txtEmployeeID_KeyUp");
                    return;
                }
            }
        }

        private void txtEmployeeID_Leave(object sender, EventArgs e)
        {
            if (!txtEmployeeID.Text.Trim().Equals(""))
            {
                dtAttendanceRegisterList = DBEngine.execReturnDataTable("sp_AttendanceRegister_List", CommonConst.A_LoginID, UserID, CommonConst.A_EmployeeID, txtEmployeeID.Text);
                cbxAccCodeList.Properties.DataSource = dtAttendanceRegisterList;
                LoadEmployeeInformation();
                if (btnIDauto.Visible == true)
                {
                    if (txtFirstName.Text == "")
                    {
                        txtEmployeeID.SelectAll();
                        txtEmployeeID.Focus();
                    }
                    else
                        txtLastname.Focus();
                }
                LoadEmployeeInformation();
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            EnableGrid();
           // dtDocs.PrimaryKey = null;
            dtDocs = DBEngine.execReturnDataTable("sp_getEmployeeDocs",
                                                                "@EmployeeID", txtEmployeeID.Text);
            dtDocs.PrimaryKey = new DataColumn[] { dtDocs.Columns[ID_DB] };
            if (xtraTabControl1.SelectedTabPageIndex == 0 || xtraTabControl1.SelectedTabPageIndex ==1)// family information
            {
                btnFWAdd.Visible = false ;
                btnFWDelete.Visible = false;
                //btnExport.Visible = false;
            }
            else
            {
                LoadFamilyInformation();
                btnFWAdd.Visible = true;
                btnFWDelete.Visible = true;
                //btnExport.Visible = true;
            }
            switch (xtraTabControl1.SelectedTabPage.Name)
            {
                case "Health":
                    if (xtraTabControl1.SelectedTabPage.Name == Health.Name)
                    {
                        //LoadHealth here
                        //loadHealthList();
                        //Load Health Insurance data
                        if (loadHealthList())
                        {
                            //Load contract type
                            dtHealthStatusList = DBEngine.execReturnDataTable("HR_person_HealthStatus_List");
                            rpHealthStatusList.DataSource = dtHealthStatusList;
                            cbxHealthStatusID.Properties.DataSource = dtHealthStatusList;

                            dtLoodList = DBEngine.execReturnDataTable("HR_person_Blood_List");
                            rpBloodList.DataSource = dtLoodList;
                            cbxBloodID.Properties.DataSource = dtLoodList;
                            //success full
                        }
                    }
                    break;
                case "Education":
                    //Load combobox data
                    cbxEduCerDocList.Properties.DataSource = dtDocs;
                    LoadEducationComboboxData();
                    // get param
                    if (!txtEmployeeID.Text.Trim().Equals(""))
                    {
                        LoadEducationInformation();
                        //DirtyData = false;
                    }
                    break;
                case "InternalEducation":
                    //Load combobox data
                    LoadInternalTrainComboboxData();
                    // get param
                    if (!txtEmployeeID.Text.Trim().Equals(""))
                    {
                        LoadInternalEducationInformation();
                        //DirtyData = false;
                    }
                    break;
                case "Experience":
                    if (!txtEmployeeID.Text.Trim().Equals(""))
                    {
                        LoadExperienceInformation();
                        //DirtyData = false;
                    }
                    break;
                case "Skill":
                    if (!txtEmployeeID.Text.Trim().Equals(""))
                    {
                        cbxSkillCerDoc.Properties.DataSource = dtDocs;
                        LoadSkillInformation();
                        //DirtyData = false;
                    }
                    break;
                case "Documents":
                    if (!txtEmployeeID.Text.Trim().Equals(""))
                    {
                        loadEmployeeDocs();
                        //DirtyData = false;
                    }
                    break;
                case "Options":
                    if (!txtEmployeeID.Text.Trim().Equals(""))
                    {
                        LoadOptions();
                        btnFWDelete.Enabled = false;
                        btnFWAdd.Enabled = false;
                    }
                    break;
            }


        }
        #region Document storage
        private DataTable dtDocs;
        private DataTable dtTypeDocs;
        private const string FileName = "FileName";
        private const string DocsID = "DocsID";
        private const string Information = "Information";
        private const string Date_DB = "Date";
        private const string ID_DB = "ID";
        private const string ext = "ext";
        private void ResetDocument()
        {
            // TODO:  Add InsuranceInfo.OnReset implementation
            try
            {
                dtDocs.RejectChanges();
                BindingDocumentData();
                foreach (DataRow dr in dtDocs.GetErrors())
                {
                    dr.ClearErrors();
                }
                txtDocName.Focus();
                DirtyData = false;
            }
            catch (Exception)
            {
                //HPA.Common.Helper.ShowException(e, this.Name + ".OnReset()", null);
                MessageBox.Show(this.Name + ".OnReset");
            }
        }
        private bool loadEmployeeDocs()
        {
            xbeFileName.Text = "";
            try
            {
                if (txtEmployeeID.Text.Trim().Equals(""))
                    return false;
                dtTypeDocs = DBEngine.execReturnDataTable("sp_getDocs_Setting");
                grdEmpDocs.DataSource = dtDocs;

                cbxTypeDocs.Properties.DataSource = dtTypeDocs;
                BindingDocumentData();

            }
            catch (Exception ex)
            {
                UIMessage.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        void dtDocs_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }

        void dtDocs_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DirtyData = true;
        }

        private void BindingDocumentData()
        {
            dtDocs.RowChanged -= new DataRowChangeEventHandler(dtDocs_RowChanged);
            dtDocs.RowChanged += new DataRowChangeEventHandler(dtDocs_RowChanged);
            dtDocs.ColumnChanged -= new DataColumnChangeEventHandler(dtDocs_ColumnChanged);
            dtDocs.ColumnChanged += new DataColumnChangeEventHandler(dtDocs_ColumnChanged);

            txtDocName.DataBindings.Clear();
            cbxTypeDocs.DataBindings.Clear();
            txtInformation.DataBindings.Clear();
            dtpDocumentDate.DataBindings.Clear();
            tblID.DataBindings.Clear();
            txtextfile.DataBindings.Clear();

            txtDocName.DataBindings.Add(CommonConst.EDIT_VALUE, dtDocs, FileName);
            cbxTypeDocs.DataBindings.Add(CommonConst.EDIT_VALUE, dtDocs, DocsID);
            txtInformation.DataBindings.Add(CommonConst.EDIT_VALUE, dtDocs, Information);
            dtpDocumentDate.DataBindings.Add(CommonConst.EDIT_VALUE, dtDocs, Date_DB);
            tblID.DataBindings.Add(CommonConst.EDIT_VALUE, dtDocs, ID_DB);
            txtextfile.DataBindings.Add(CommonConst.EDIT_VALUE, dtDocs, ext);
            
        }
        private bool AddDocument()
        {
            if (txtEmployeeID.Text.Trim().Equals(""))
                return true;
            try
            {
                grvDocuments.ClearSorting();
                CRowUtility.addNewRow(dtDocs, CommonConst.EmployeeID, txtEmployeeID.Text, ID_DB, -1);
                grvDocuments.Focus();
                grvDocuments.ClearSelection();
                grvDocuments.FocusedRowHandle = grvDocuments.RowCount - 1;
                grvDocuments.SelectRow(grvDocuments.RowCount - 1);
                txtDocName.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
        private bool DeleteDocument()
        {
            grvDocuments.CloseEditor();
            grvDocuments.UpdateCurrentRow();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (dtDocs != null)
                {

                    if (UIMessage.ShowMessage(3, System.Windows.Forms.MessageBoxButtons.YesNo,
                         System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        int[] iDelRows = grvDocuments.GetSelectedRows();
                        DataRow[] drDel = new DataRow[iDelRows.Length];
                        int iCount = 0;
                        dtDocs.PrimaryKey = new DataColumn[] { dtDocs.Columns[ID_DB] };
                        foreach (int rh in iDelRows)
                        {
                            drDel[iCount++] = dtDocs.Rows.Find(grvDocuments.GetDataRow(rh)[ID_DB]);
                        }
                        foreach (DataRow drDelSub in drDel)
                        {
                            drDelSub.Delete();
                            DirtyData = true;
                        }
                    }

                }
                // restore cursor
                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {
                grvDocuments.EndUpdate();
                // restore cursor
                this.Cursor = Cursors.Default;

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".OnDelete()", null);

                return false;
            }
            return true;
        }
        private bool CommitDocument()
        {
            string filePath = "";
            string extfile = "";
            if (!isOnDelete && !ValidateDocument())
            {
                return false;
            }
            try
            {
                DBEngine.beginTransaction();
                // delete tranfer history
                if (dtDocs != null && dtDocs.Rows.Count > 0)
                {
                    if (isOnDelete)
                    {
                        foreach (DataRow drEmpSkill in dtDocs.Rows)
                        {

                            if (drEmpSkill.RowState == DataRowState.Deleted)
                            {
                                DBEngine.exec("deleteFile",
                                    "@id", drEmpSkill[ID_DB, DataRowVersion.Original],
                                    CommonConst.A_LoginID, this.UserID);
                            }
                        }
                    }
                }
                if (!isOnDelete)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (tblID.Text.Equals("-1") || !xbeFileName.Text.Trim().Equals(string.Empty))
                    {
                        filePath = "";
                        extfile = "";
                        FileInfo fInfo = new FileInfo(xbeFileName.Text);
                        extfile = fInfo.Extension.ToString();
                        filePath = fInfo.Name.ToString();
                        byte[] fileSave = ReadFile(xbeFileName.Text);
                        DBEngine.exec("saveFile",
                                        "@EmployeeID", txtEmployeeID.Text,
                                        "@id", tblID.Text,
                                        "@TypeDocs", cbxTypeDocs.EditValue,
                                        "@date", dtpDocumentDate.DateTime.Date,
                                        "@Infor", txtInformation.Text.Trim(),
                                        "@FileName", txtDocName.Text.Trim(),
                                        "@File", fileSave,
                                        "@extFile", extfile,
                                        CommonConst.A_LoginID, UserID);
                    }
                    else
                    {
                        DBEngine.exec("saveFile",
                                        "@EmployeeID", txtEmployeeID.Text,
                                        "@id", tblID.Text,
                                        "@TypeDocs", cbxTypeDocs.EditValue,
                                        "@date", dtpDocumentDate.DateTime.Date,
                                        "@Infor", txtInformation.Text.Trim(),
                                        "@FileName", txtDocName.Text.Trim(),
                                        "@File", DBNull.Value,
                                        "@extFile", txtextfile.Text,
                                        CommonConst.A_LoginID, UserID);
                    }

                }
                this.Cursor = Cursors.Default;
                DBEngine.commit();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                // dtEmployeeInformation.RejectChanges();
                DBEngine.rollback();
                throw (ex);
            }
            loadEmployeeDocs();
            this.DirtyData = false;
            return true;
        }

        private bool ValidateDocument()
        {
            if (txtDocName.Text.Trim().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocName.Focus();
                return false;
            }
            if (cbxTypeDocs.EditValue.ToString().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxTypeDocs.Focus();
                return false;
            }
            
            if (dtpDocumentDate.EditValue.ToString().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDocumentDate.Focus();
                return false;
            }
            return true;
        }
        private void xbeFileName_MouseClick(object sender, MouseEventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    xbeFileName.Text = dlg.FileName.ToString();

                }
                catch (Exception ex)
                {
                    UIMessage.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            dlg.Dispose();
        }
        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open,
                                                    FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to 

            //supply number of bytes to read from file.
            //In this case we want to read entire file. 

            //So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        #endregion
        #region Skill
        protected const string EmployeeSkillID = "EmployeeSkillID";
        protected const string SkillID = "SkillID";
        protected const string GradeID = "GradeID";
        protected const string EffectiveDate = "EffectiveDate";
        protected const string Notes = "Notes";
        protected const string DocID = "DocID";

        protected DataTable dtEmployeeSkillList = null;
        protected DataTable dtSkillList = null;
        protected DataTable dtGradeList = null;
        private bool CommitSkill()
        {
            if (!isOnDelete && !ValidateSkill())
            {
                return false;
            }
            try
            {
                DBEngine.beginTransaction();
                // delete tranfer history
                if (dtEmployeeSkillList != null && dtEmployeeSkillList.Rows.Count > 0)
                    foreach (DataRow drEmpSkill in dtEmployeeSkillList.Rows)
                    {

                        if (drEmpSkill.RowState == DataRowState.Deleted)
                        {
                            DBEngine.exec("HR_person_Skill_Delete",
                                "@EmployeeSkillID", drEmpSkill[EmployeeSkillID, DataRowVersion.Original],
                                CommonConst.A_LoginID, this.UserID
                                );
                        }
                        else
                        {
                            // save data
                            DBEngine.exec("HR_person_Skill_Save", "@EmployeeSkillID", drEmpSkill[EmployeeSkillID],
                                CommonConst.A_EmployeeID, drEmpSkill[CommonConst.EmployeeID],
                                "@SkillID", drEmpSkill[SkillID],
                                "@GradeID", drEmpSkill[GradeID],
                                "@EffectiveDate", drEmpSkill[EffectiveDate],
                                "@Notes", drEmpSkill[Notes],
                                "@CerDocID",drEmpSkill[DocID],
                               CommonConst.A_LoginID, UserID
                                );
                        }
                    }
                DBEngine.commit();
            }
            catch (Exception ex)
            {
                // dtEmployeeInformation.RejectChanges();
                DBEngine.rollback();
                throw (ex);
            }
            LoadSkillInformation();
            this.DirtyData = false;
            return true;
        }

        private bool ValidateSkill()
        {
            if (cbxSkill.EditValue.ToString().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxSkill.Focus();
                return false;
            }
            if (cbxGrade.EditValue.ToString().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxGrade.Focus();
                return false;
            }
            if (dtpEffectiveDate.EditValue.ToString().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEffectiveDate.Focus();
                return false;
            }
            return true;
        }
        private void ResetSkill()
        {
            dtEmployeeSkillList.RejectChanges();
            foreach (DataRow dr in dtEmployeeSkillList.GetErrors())
            {
                dr.ClearErrors();
            }
            DirtyData = false;
        }
        private bool DeleteSkill()
        {
            grvSkillList.CloseEditor();
            grvSkillList.UpdateCurrentRow();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (dtEmployeeSkillList != null)
                {

                    if (UIMessage.ShowMessage(3, System.Windows.Forms.MessageBoxButtons.YesNo,
                         System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        int[] iDelRows = grvSkillList.GetSelectedRows();
                        DataRow[] drDel = new DataRow[iDelRows.Length];
                        int iCount = 0;
                        dtEmployeeSkillList.PrimaryKey = new DataColumn[] { dtEmployeeSkillList.Columns[EmployeeSkillID] };
                        foreach (int rh in iDelRows)
                        {
                            drDel[iCount++] = dtEmployeeSkillList.Rows.Find(grvSkillList.GetDataRow(rh)[EmployeeSkillID]);
                        }
                        foreach (DataRow drDelSub in drDel)
                        {
                            drDelSub.Delete();
                            DirtyData = true;
                        }
                    }

                }
                // restore cursor
                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {
                grvSkillList.EndUpdate();
                // restore cursor
                this.Cursor = Cursors.Default;

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".OnDelete()", null);

                return false;
            }
            return true;
        }
        private void LoadSkillInformation()
        {
            if (txtEmployeeID.Text.Trim().Equals(""))
                return ;
            try
            {
                // get full name
               // txtFullName.Text = DBEngine.execReturnDataTable("sp_hr_get_fullname", CommonConst.A_EmployeeID, txtEmployeeID.Text, CommonConst.A_LoginID, UserID).Rows[0][0].ToString();
                // HR_PositionHis_List
                dtEmployeeSkillList = DBEngine.execReturnDataTable("HR_person_Skill_List", CommonConst.A_EmployeeID, txtEmployeeID.Text);
                if (dtEmployeeSkillList != null && dtEmployeeSkillList.Rows.Count <= 0)
                    AddSkill();
                grdSkillList.DataSource = dtEmployeeSkillList;

                dtEmployeeSkillList.RowChanged -= new DataRowChangeEventHandler(dtEmployeeSkillList_RowChanged);
                dtEmployeeSkillList.ColumnChanged -= new DataColumnChangeEventHandler(dtEmployeeSkillList_ColumnChanged);
                dtEmployeeSkillList.RowChanged += new DataRowChangeEventHandler(dtEmployeeSkillList_RowChanged);
                dtEmployeeSkillList.ColumnChanged += new DataColumnChangeEventHandler(dtEmployeeSkillList_ColumnChanged);
                BindingSkillData();
                dtGradeList = DBEngine.execReturnDataTable("MD_Grade_List");
                rpGrade.DataSource = dtGradeList;
                cbxGrade.Properties.DataSource = dtGradeList;

                dtSkillList = DBEngine.execReturnDataTable("MD_Skill_List");
                rpSkill.DataSource = dtSkillList;
                cbxSkill.Properties.DataSource = dtSkillList;

            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "loadSkillList()");
            }
            return ;
        }
        void dtEmployeeSkillList_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }

        void dtEmployeeSkillList_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DirtyData = true;
        }
        private void BindingSkillData()
        {
            cbxGrade.DataBindings.Clear();
            cbxSkill.DataBindings.Clear();
            dtpEffectiveDate.DataBindings.Clear();
            txtNotes.DataBindings.Clear();
            cbxSkillCerDoc.DataBindings.Clear();

            cbxGrade.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeSkillList, GradeID);
            cbxSkill.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeSkillList, SkillID);
            dtpEffectiveDate.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeSkillList, EffectiveDate);
            txtNotes.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeSkillList, Notes);
            cbxSkillCerDoc.DataBindings.Add(CommonConst.EDIT_VALUE, dtEmployeeSkillList, DocID);
        }

        private bool AddSkill()
        {
            if (txtEmployeeID.Text.Trim().Equals(""))
                return true;
            try
            {
                CRowUtility.addNewRow(dtEmployeeSkillList, CommonConst.EmployeeID, txtEmployeeID.Text);
                grvSkillList.Focus();
                grvSkillList.ClearSelection();
                grvSkillList.FocusedRowHandle = grvSkillList.RowCount - 1;
                grvSkillList.SelectRow(grvSkillList.RowCount - 1);
                cbxSkill.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        
        #endregion
        #region Experience
        private void ResetExperience()
        {
            try
            {
                if (DirtyData == true)
                {
                        dtExperience.RejectChanges();
                        BindingExperienceData();
                        foreach (DataRow dr in dtExperience.GetErrors())
                        {
                            dr.ClearErrors();
                        }
                        txtCompanyName.Focus();
                        DirtyData = false;
                }
            }
            catch (Exception)
            {
                //HPA.Common.Helper.ShowException(e, this.Name + ".OnReset()", null);
                MessageBox.Show(this.Name + ".OnReset");
            }
        }
        private void DeleteExperience()
        {
            grvExperience.CloseEditor();
            grvExperience.UpdateCurrentRow();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (dtExperience != null)
                {

                    if (UIMessage.ShowMessage(3, System.Windows.Forms.MessageBoxButtons.YesNo,
                         System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        int[] iDelRows = grvExperience.GetSelectedRows();
                        DataRow[] drDel = new DataRow[iDelRows.Length];
                        int iCount = 0;
                        dtExperience.PrimaryKey = new DataColumn[] { dtExperience.Columns[WorkingHistoryID] };
                        foreach (int rh in iDelRows)
                        {
                            drDel[iCount++] = dtExperience.Rows.Find(grvExperience.GetDataRow(rh)[WorkingHistoryID]);
                        }
                        foreach (DataRow drDelSub in drDel)
                        {
                            drDelSub.Delete();
                            DirtyData = true;
                        }
                    }

                }
                // restore cursor
                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {
                grvExperience.EndUpdate();
                // restore cursor
                this.Cursor = Cursors.Default;

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".OnDelete()", null);

            }
        }
        private bool AddNewExperience()
        {
            if (txtEmployeeID.Text.Trim().Equals(""))
                return true;
            try
            {
                grvExperience.ClearSorting();
                CRowUtility.addNewRow(dtExperience, CommonConst.EmployeeID, txtEmployeeID.Text);
                grvExperience.Focus();
                grvExperience.ClearSelection();
                grvExperience.FocusedRowHandle = grvExperience.RowCount - 1;
                grvExperience.SelectRow(grvExperience.RowCount - 1);
                txtCompanyName.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        private void LoadExperienceInformation()
        {
            if (txtEmployeeID.Text.Trim().Equals(""))
                return;
            try
            {
                dtExperience = DBEngine.execReturnDataTable("HR_person_previous_job_List", CommonConst.A_EmployeeID, txtEmployeeID.Text);
                if (dtExperience != null && dtExperience.Rows.Count <= 0)
                    OnAdd();
                grdExpericence.DataSource = dtExperience;
                BindingExperienceData();
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "LoadExperienceInformation()");
            }
        }

        private void BindingExperienceData()
        {
            dtExperience.ColumnChanged -= new DataColumnChangeEventHandler(dtExperience_ColumnChanged);
            dtExperience.ColumnChanged += new DataColumnChangeEventHandler(dtExperience_ColumnChanged);

            dtExperience.RowChanged -= new DataRowChangeEventHandler(dtExperience_RowChanged);
            dtExperience.RowChanged += new DataRowChangeEventHandler(dtExperience_RowChanged);

            txtJobTitle.DataBindings.Clear();
            txtLastSalary.DataBindings.Clear();
            txtWorkPosition.DataBindings.Clear();
            txtCompanyAddress.DataBindings.Clear();
            txtCompanyName.DataBindings.Clear();
            txtDepartment.DataBindings.Clear();
            txtReasonResign.DataBindings.Clear();
            txtRefAddress.DataBindings.Clear();
            txtRefFullName.DataBindings.Clear();
            txtRefPosition.DataBindings.Clear();
            txtRefEmail.DataBindings.Clear();
            txtRefPhone.DataBindings.Clear();
            dtpLastCompFrom.DataBindings.Clear();
            dtpLastCompTo.DataBindings.Clear();

            txtJobTitle.DataBindings.Add(CommonConst.EDIT_VALUE, dtExperience, Jobtitle);
            txtLastSalary.DataBindings.Add(CommonConst.EDIT_VALUE, dtExperience, LastSalary);
            txtWorkPosition.DataBindings.Add(CommonConst.EDIT_VALUE, dtExperience, WorkPosition);
            txtCompanyAddress.DataBindings.Add(CommonConst.EDIT_VALUE, dtExperience, CompanyAddress);
            txtCompanyName.DataBindings.Add(CommonConst.EDIT_VALUE, dtExperience, CompanyName_D);
            txtDepartment.DataBindings.Add(CommonConst.EDIT_VALUE, dtExperience, Department);
            txtReasonResign.DataBindings.Add(CommonConst.EDIT_VALUE, dtExperience, ReasonResign);
            txtRefAddress.DataBindings.Add(CommonConst.EDIT_VALUE, dtExperience, RefAddress);
            txtRefFullName.DataBindings.Add(CommonConst.EDIT_VALUE, dtExperience, RefName);
            txtRefPosition.DataBindings.Add(CommonConst.EDIT_VALUE, dtExperience, RefPosition);
            txtRefEmail.DataBindings.Add(CommonConst.EDIT_VALUE, dtExperience, RefEmail);
            txtRefPhone.DataBindings.Add(CommonConst.EDIT_VALUE, dtExperience, RefPhone);
            dtpLastCompFrom.DataBindings.Add(CommonConst.EDIT_VALUE, dtExperience, WorkFrom);
            dtpLastCompTo.DataBindings.Add(CommonConst.EDIT_VALUE, dtExperience, WorkTo);

        }

        void dtExperience_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DirtyData = true;
        }

        void dtExperience_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }
        private bool CommitExperience()
        {
            if (!isOnDelete &&!ValidateExperience() )
                return false;
            try
            {
                
                try
                {
                    DBEngine.beginTransaction();
                    // delete tranfer history
                    if (dtExperience != null && dtExperience.Rows.Count > 0)
                        foreach (DataRow drExper in dtExperience.Rows)
                        {

                            if (drExper.RowState == DataRowState.Deleted)
                            {
                                DBEngine.exec("HR_person_previous_job_Delete",
                                    "@WorkingHistoryID", drExper[WorkingHistoryID, DataRowVersion.Original],
                                    CommonConst.A_LoginID, this.UserID
                                    );
                            }
                            else
                            {
                                
                                // save data
                                DBEngine.exec("HR_person_previous_job_Save",
                                    "@WorkingHistoryID", drExper[WorkingHistoryID],
                                    "@EmployeeID", drExper[CommonConst.EmployeeID],
                                    "@CompanyName", drExper[CompanyName_D],
                                    "@CompanyAddress", drExper[CompanyAddress],
                                    "@JobTitle", drExper[Jobtitle],
                                    "@Department", drExper[Department],
                                    "@WorkPosition", drExper[WorkPosition],
                                    "@LastSalary", drExper[LastSalary],
                                    "@WorkFrom", drExper[WorkFrom],
                                    "@WorkTo", drExper[WorkTo],
                                    "@ReasonResign", drExper[ReasonResign],
                                    "@RefName", drExper[RefName],
                                    "@RefEmail", drExper[RefEmail],
                                    "@RefPhone", drExper[RefPhone],
                                    "@RefAddress", drExper[RefPhone],
                                    "@RefPosition", drExper[RefPosition],
                                   CommonConst.A_LoginID, UserID
                                    );
                            }
                        }
                    DBEngine.commit();
                }
                catch (Exception ex)
                {
                    // dtEmployeeInformation.RejectChanges();
                    DBEngine.rollback();
                    throw (ex);
                }

            }
            catch (Exception e)
            {

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".Commit()", null);

                return false;
            }
            LoadExperienceInformation();
            this.DirtyData = false;
            return true;
        }

        private bool ValidateExperience()
        {
            if (txtCompanyName.Text.Trim().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCompanyName.Focus();
                return false;
            }
            if (txtJobTitle.Text.Trim().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJobTitle.Focus();
                return false;
            }
            if (txtLastSalary.Text.Trim().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastSalary.Focus();
                return false;
            }
            if (dtpLastCompFrom.EditValue.ToString().Trim().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpLastCompFrom.Focus();
                return false;
            }
            if (dtpLastCompTo.EditValue.ToString().Trim().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpLastCompTo.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region Education
        private void LoadEducationComboboxData()
        {
            dtGraduateLeval = DBEngine.execReturnDataTable("HR_GraduateLevel_List");
            rpGraduateLevel.DataSource = dtGraduateLeval;
            cbxGraduateLeval.Properties.DataSource = dtGraduateLeval;

            dtSchoolType = DBEngine.execReturnDataTable("MD_SchoolType_List");
            redTypeSchoolID.DataSource = dtSchoolType;
            cbxSchoolType.Properties.DataSource = dtSchoolType;
        }
        private void LoadEducationInformation()
        {
            if (txtEmployeeID.Text.Trim().Equals(""))
                return;
            try
            {
                dtEducationList = DBEngine.execReturnDataTable("hr_person_education_list", CommonConst.A_EmployeeID, txtEmployeeID.Text, CommonConst.A_LoginID, UserID);
                if (dtEducationList != null && dtEducationList.Rows.Count <= 0)
                    OnAdd();
                grdHIList.DataSource = dtEducationList;
                BindingEducation();
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "LoadEducationInformation()");
            }
        }
        private bool CommitEducation()
        {
            if (!isOnDelete && !ValidateEducation())
                return false;
            try
            {
                // switch to COMMITING state
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    DBEngine.beginTransaction();
                    // delete tranfer history
                    if (dtEducationList != null && dtEducationList.Rows.Count > 0)
                        foreach (DataRow drEdu in dtEducationList.Rows)
                        {

                            if (drEdu.RowState == DataRowState.Deleted)
                            {
                                DBEngine.exec("HR_Person_Education_Delete",
                                    "@EducationID", drEdu[EducationHistoryID, DataRowVersion.Original],
                                    CommonConst.A_LoginID, this.UserID
                                    );
                            }
                            else
                            {
                                // save data
                                DBEngine.exec("HR_Person_Education_Save", "@EducationHistoryID", drEdu[EducationHistoryID],
                                    "@EmployeeID", drEdu[CommonConst.EmployeeID],
                                    "@TypeSchool", drEdu[TypeSchoolID],
                                    "@StudyFrom", drEdu[StudyFrom],
                                    "@StudyTo", drEdu[StudyTo],
                                    "@GraduateLevelID", drEdu[GraduateLevelID],
                                    "@Place", drEdu[Place],
                                    "@CerDocID", drEdu[DocID],
                                    "@MainSubject", drEdu[MainSubject],
                                   CommonConst.A_LoginID, UserID
                                    );
                            }
                        }
                    DBEngine.commit();
                }
                catch (Exception ex)
                {
                    // dtEmployeeInformation.RejectChanges();
                    DBEngine.rollback();
                    throw (ex);
                }

                // restore cursor
                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {
                // restore cursor
                this.Cursor = Cursors.Default;

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".Commit()", null);

                return false;
            }
            LoadEducationInformation();
            this.DirtyData = false;
            // commit successfully
            return true;
        }

        private bool ValidateEducation()
        {
            if (cbxSchoolType.EditValue.ToString().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxSchoolType.Focus();
                return false;
            }
            if (txtMainSubject.Text.Trim().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMainSubject.Focus();
                return false;
            }
            if (dtpFromDate.EditValue.ToString().Trim().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFromDate.Focus();
                return false;
            }
            if (dtpTodate.EditValue.ToString().Trim().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpTodate.Focus();
                return false;
            }
            if (cbxGraduateLeval.EditValue.ToString().Trim().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxGraduateLeval.Focus();
                return false;
            }
            return true;
        }
        private void BindingEducation()
        {
            dtEducationList.ColumnChanged -= new DataColumnChangeEventHandler(dtEducationList_ColumnChanged);
            dtEducationList.ColumnChanged += new DataColumnChangeEventHandler(dtEducationList_ColumnChanged);
            dtEducationList.RowChanged -= new DataRowChangeEventHandler(dtEducationList_RowChanged);
            dtEducationList.RowChanged += new DataRowChangeEventHandler(dtEducationList_RowChanged);

            txtMainSubject.DataBindings.Clear();
            txtPlace.DataBindings.Clear();
            cbxGraduateLeval.DataBindings.Clear();
            cbxSchoolType.DataBindings.Clear();
            dtpFromDate.DataBindings.Clear();
            dtpTodate.DataBindings.Clear();
            cbxEduCerDocList.DataBindings.Clear();

            txtMainSubject.DataBindings.Add(CommonConst.EDIT_VALUE, dtEducationList, MainSubject);
            txtPlace.DataBindings.Add(CommonConst.EDIT_VALUE, dtEducationList, Place);
            cbxGraduateLeval.DataBindings.Add(CommonConst.EDIT_VALUE, dtEducationList, GraduateLevelID);
            cbxSchoolType.DataBindings.Add(CommonConst.EDIT_VALUE, dtEducationList, TypeSchoolID);
            dtpFromDate.DataBindings.Add(CommonConst.EDIT_VALUE, dtEducationList, StudyFrom);
            dtpTodate.DataBindings.Add(CommonConst.EDIT_VALUE, dtEducationList, StudyTo);
            cbxEduCerDocList.DataBindings.Add(CommonConst.EDIT_VALUE, dtEducationList, DocID);
        }
        private void ResetEducation()
        {
            // TODO:  Add InsuranceInfo.OnReset implementation
            try
            {
                dtEducationList.RejectChanges();
                BindingEducation();
                foreach (DataRow dr in dtEducationList.GetErrors())
                {
                    dr.ClearErrors();
                }
                cbxSchoolType.Focus();
                DirtyData = false;
            }
            catch (Exception)
            {
                //HPA.Common.Helper.ShowException(e, this.Name + ".OnReset()", null);
                MessageBox.Show(this.Name + ".OnReset");
            }

        }
        void dtEducationList_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DirtyData = true;
        }
        private bool AddNewEducation()
        {
            if (txtEmployeeID.Text.Trim().Equals(""))
                return true;
            try
            {
                grvEducationList.ClearSorting();
                CRowUtility.addNewRow(dtEducationList, CommonConst.EmployeeID, txtEmployeeID.Text);
                // Forcus to new row
                grvEducationList.Focus();
                grvEducationList.ClearSelection();
                grvEducationList.FocusedRowHandle = grvEducationList.RowCount - 1;
                grvEducationList.SelectRow(grvEducationList.RowCount - 1);
                cbxSchoolType.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        void dtEducationList_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }
        private void DeleteEducation()
        {
            grvEducationList.CloseEditor();
            grvEducationList.UpdateCurrentRow();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (dtEducationList != null)
                {

                    if (UIMessage.ShowMessage(3, System.Windows.Forms.MessageBoxButtons.YesNo,
                         System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        int[] iDelRows = grvEducationList.GetSelectedRows();
                        DataRow[] drDel = new DataRow[iDelRows.Length];
                        int iCount = 0;
                        dtEducationList.PrimaryKey = new DataColumn[] { dtEducationList.Columns[EducationHistoryID] };
                        foreach (int rh in iDelRows)
                        {
                            drDel[iCount++] = dtEducationList.Rows.Find(grvEducationList.GetDataRow(rh)[EducationHistoryID]);
                        }
                        foreach (DataRow drDelSub in drDel)
                        {
                            drDelSub.Delete();
                            DirtyData = true;
                        }
                    }

                }
                // restore cursor
                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {
                grvEducationList.EndUpdate();
                // restore cursor
                this.Cursor = Cursors.Default;

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".OnDelete()", null);

            }
        }
        #endregion

        #region Health
        private bool CommitHealth()
        {
            if (!isOnDelete && !ValidateHealth())
                return false;
            try
            {
                try
                {
                    DBEngine.beginTransaction();
                    // delete tranfer history
                    if (dtHealthList != null && dtHealthList.Rows.Count > 0)
                        foreach (DataRow drHealth in dtHealthList.Rows)
                        {

                            if (drHealth.RowState == DataRowState.Deleted)
                            {
                                DBEngine.exec("HR_person_Health_Delete",
                                    "@HealthID", drHealth[HealthID, DataRowVersion.Original],
                                    CommonConst.A_LoginID, this.UserID
                                    );
                            }
                            else
                            {
                                
                                // save data
                                DBEngine.exec("HR_person_Health_Save",
                                    "@HealthID", drHealth[HealthID],
                                    CommonConst.A_EmployeeID, drHealth[CommonConst.EmployeeID],
                                    "@ExaminationDate", drHealth[ExaminationDate],
                                    "@HospitalName", drHealth[HospitalName],
                                    "@Height", drHealth[Height_D],
                                    "@Weight", drHealth[Weight],
                                    "@BloodID", drHealth[BloodID],
                                    "@Vision", drHealth[Vision],
                                    "@ChildrenNumber", drHealth[ChildrenNumber],
                                    "@HealthStatusID", drHealth[HealthStatusID],
                                    "@Note", drHealth[Note],
                                    "@CompanyPay", drHealth[CompanyPay],
                                   CommonConst.A_LoginID, UserID
                                    );
                            }
                        }
                    DBEngine.commit();
                }
                catch (Exception ex)
                {
                    // dtEmployeeInformation.RejectChanges();
                    DBEngine.rollback();
                    throw (ex);
                }
            }
            catch (Exception e)
            {
               
                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".Commit()", null);

                return false;
            }

            
            loadHealthList();
            // commit successfully
            return true;
        }

        private bool ValidateHealth()
        {
            if (dtpExaminationDate.EditValue.ToString().Equals(String.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpExaminationDate.Focus();
                return false;
            }
            if (cbxBloodID.EditValue.ToString().Equals(String.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxBloodID.Focus();
                return false;
            }
            if (cbxHealthStatusID.EditValue.ToString().Equals(String.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxHealthStatusID.Focus();
                return false;
            }
            if (cbxHealthStatusID.EditValue.ToString().Equals(String.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxHealthStatusID.Focus();
                return false;
            }
            if (txtNote.Text.Equals(String.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNote.Focus();
                return false;
            }
            return true;
        }
        private void ResetHealth()
        {
            dtHealthList.RejectChanges();
            foreach (DataRow dr in dtHealthList.GetErrors())
            {
                dr.ClearErrors();
            }
        }
        private void DeleteHealth()
        {
            grvHealthList.CloseEditor();
            grvHealthList.UpdateCurrentRow();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (dtHealthList != null)
                {

                    if (UIMessage.ShowMessage(3, System.Windows.Forms.MessageBoxButtons.YesNo,
                         System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        int[] iDelRows = grvHealthList.GetSelectedRows();
                        DataRow[] drDel = new DataRow[iDelRows.Length];
                        int iCount = 0;
                        dtHealthList.PrimaryKey = new DataColumn[] { dtHealthList.Columns[HealthID] };
                        foreach (int rh in iDelRows)
                        {
                            if (grvHealthList.GetDataRow(rh)[HealthID] != DBNull.Value)
                                drDel[iCount++] = dtHealthList.Rows.Find(grvHealthList.GetDataRow(rh)[HealthID]);
                        }
                        foreach (DataRow drDelSub in drDel)
                        {
                            drDelSub.Delete();
                            DirtyData = true;
                        }
                    }

                }
                // restore cursor
                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {
                grvHealthList.EndUpdate();
                // restore cursor
                this.Cursor = Cursors.Default;

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".OnDelete()", null);
            }
        }
        private bool AddNewHealth()
        {
            if (txtEmployeeID.Text.Trim().Equals(""))
                return true;
            try
            {
                grvHealthList.ClearSorting();
                CRowUtility.addNewRow(dtHealthList, CommonConst.EmployeeID, txtEmployeeID.Text);
                grvHealthList.Focus();
                grvHealthList.ClearSelection();
                grvHealthList.FocusedRowHandle = grvHealthList.RowCount - 1;
                grvHealthList.SelectRow(grvHealthList.RowCount - 1);
                dtpExaminationDate.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        private bool loadHealthList()
        {
            if (txtEmployeeID.Text.Trim().Equals(""))
                return true;
            try
            {
                dtHealthList = DBEngine.execReturnDataTable("HR_person_Health_List", CommonConst.A_LoginID, UserID, CommonConst.A_EmployeeID, txtEmployeeID.Text);
                if (dtHealthList != null && dtHealthList.Rows.Count <= 0)
                    CRowUtility.addNewRow(dtHealthList, CommonConst.EmployeeID, txtEmployeeID.Text);
                grdHealthList.DataSource = dtHealthList;
                BindingHealthData();

            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "loadHealthList()");
            }
            return true;
        }
        private void BindingHealthData()
        {
            dtHealthList.ColumnChanged -= new DataColumnChangeEventHandler(dtHealthList_ColumnChanged);
            dtHealthList.RowChanged -= new DataRowChangeEventHandler(dtHealthList_RowChanged);
            dtHealthList.ColumnChanged += new DataColumnChangeEventHandler(dtHealthList_ColumnChanged);
            dtHealthList.RowChanged += new DataRowChangeEventHandler(dtHealthList_RowChanged);
            txtChildrenNumber.DataBindings.Clear();
            txtHeight.DataBindings.Clear();
            txtHospitalName.DataBindings.Clear();
            txtVision.DataBindings.Clear();
            txtWeight.DataBindings.Clear();
            txtNote.DataBindings.Clear();
            ckbCpnPaidFee.DataBindings.Clear();
            dtpExaminationDate.DataBindings.Clear();
            cbxBloodID.DataBindings.Clear();
            cbxHealthStatusID.DataBindings.Clear();

            txtChildrenNumber.DataBindings.Add(CommonConst.EDIT_VALUE, dtHealthList, ChildrenNumber);
            txtHeight.DataBindings.Add(CommonConst.EDIT_VALUE, dtHealthList, Height_D);
            txtHospitalName.DataBindings.Add(CommonConst.EDIT_VALUE, dtHealthList, HospitalName);
            txtVision.DataBindings.Add(CommonConst.EDIT_VALUE, dtHealthList, Vision);
            txtWeight.DataBindings.Add(CommonConst.EDIT_VALUE, dtHealthList, Weight);

            dtpExaminationDate.DataBindings.Add(CommonConst.EDIT_VALUE, dtHealthList, ExaminationDate);
            cbxBloodID.DataBindings.Add(CommonConst.EDIT_VALUE, dtHealthList, BloodID);
            cbxHealthStatusID.DataBindings.Add(CommonConst.EDIT_VALUE, dtHealthList, HealthStatusID);
            txtNote.DataBindings.Add(CommonConst.EDIT_VALUE, dtHealthList, Note);
            ckbCpnPaidFee.DataBindings.Add(CommonConst.EDIT_VALUE, dtHealthList, CompanyPay);
        }

        void dtHealthList_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DirtyData = true;
        }

        void dtHealthList_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }
        #endregion

        #region Internal training
        private void LoadInternalTrainComboboxData()
        {
            //dtGraduateLeval = DBEngine.execReturnDataTable("HR_GraduateLevel_List");
            //rpGraduateLevel.DataSource = dtGraduateLeval;
            //cbxGraduateLeval.Properties.DataSource = dtGraduateLeval;

            dtTrainingCourse = DBEngine.execReturnDataTable("sp_TrainingCourse");
            repTrainingCourse.DataSource = dtTrainingCourse;
            cbxTraniningCourse.Properties.DataSource = dtTrainingCourse;
        }
        private void LoadInternalEducationInformation()
        {
            if (txtEmployeeID.Text.Trim().Equals(""))
                return;
            try
            {
                dtTrainingList = DBEngine.execReturnDataTable("hr_person_InternalTraining_list", CommonConst.A_EmployeeID, txtEmployeeID.Text, CommonConst.A_LoginID, UserID);
                if (dtTrainingList != null && dtTrainingList.Rows.Count <= 0)
                    OnAdd();
                grdTraining.DataSource = dtTrainingList;
                BindingInternalTraining();
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "LoadEducationInformation()");
            }
        }

        private void BindingInternalTraining()
        {
            dtTrainingList.ColumnChanged -= new DataColumnChangeEventHandler(dtTrainingList_ColumnChanged);
            dtTrainingList.ColumnChanged += new DataColumnChangeEventHandler(dtTrainingList_ColumnChanged);
            dtTrainingList.RowChanged -= new DataRowChangeEventHandler(dtTrainingList_RowChanged);
            dtTrainingList.RowChanged += new DataRowChangeEventHandler(dtTrainingList_RowChanged);

            txtTrainPlace.DataBindings.Clear();
            txtTrainNote.DataBindings.Clear();
            cbxTraniningCourse.DataBindings.Clear();
            dtpTrainTo.DataBindings.Clear();
            dtpTrainFrom.DataBindings.Clear();
            ckbCompanyPaid.DataBindings.Clear();
            ckbSubmitCertificate.DataBindings.Clear();
            dtpCommitFrom.DataBindings.Clear();
            dtpCommitTo.DataBindings.Clear();
            txtComAmount.DataBindings.Clear();
            txtEmpAmount.DataBindings.Clear();

            txtTrainPlace.DataBindings.Add(CommonConst.EDIT_VALUE, dtTrainingList, Place);
            txtTrainNote.DataBindings.Add(CommonConst.EDIT_VALUE, dtTrainingList, Note);
            cbxTraniningCourse.DataBindings.Add(CommonConst.EDIT_VALUE, dtTrainingList, InternalTrainingCourseID);
            dtpTrainFrom.DataBindings.Add(CommonConst.EDIT_VALUE, dtTrainingList, FromDate);
            dtpTrainTo.DataBindings.Add(CommonConst.EDIT_VALUE, dtTrainingList, ToDate);
            ckbCompanyPaid.DataBindings.Add(CommonConst.EDIT_VALUE, dtTrainingList, CompanyPaid);
            ckbSubmitCertificate.DataBindings.Add(CommonConst.EDIT_VALUE, dtTrainingList, SubmitCertificate);
            dtpCommitFrom.DataBindings.Add(CommonConst.EDIT_VALUE, dtTrainingList, CommitFrom);
            dtpCommitTo.DataBindings.Add(CommonConst.EDIT_VALUE, dtTrainingList, CommitTo);
            txtComAmount.DataBindings.Add(CommonConst.EDIT_VALUE, dtTrainingList, ComAmount);
            txtEmpAmount.DataBindings.Add(CommonConst.EDIT_VALUE, dtTrainingList, EmpAmount);
        }

        void dtTrainingList_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DirtyData = true;
        }

        void dtTrainingList_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            DirtyData = true;
        }
        private bool AddNewInternalTraining()
        {
            if (txtEmployeeID.Text.Trim().Equals(""))
                return true;
            try
            {
                grvTraining.ClearSorting();
                CRowUtility.addNewRow(dtTrainingList, CommonConst.EmployeeID, txtEmployeeID.Text);
                grvTraining.Focus();
                grvTraining.ClearSelection();
                grvTraining.FocusedRowHandle = grvTraining.RowCount - 1;
                grvTraining.SelectRow(grvTraining.RowCount - 1);
                cbxTraniningCourse.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        private void DeleteInternalEducation()
        {
            grvTraining.CloseEditor();
            grvTraining.UpdateCurrentRow();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (dtTrainingList != null)
                {

                    if (UIMessage.ShowMessage(3, System.Windows.Forms.MessageBoxButtons.YesNo,
                         System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        int[] iDelRows = grvTraining.GetSelectedRows();
                        DataRow[] drDel = new DataRow[iDelRows.Length];
                        int iCount = 0;
                        dtTrainingList.PrimaryKey = new DataColumn[] { dtTrainingList.Columns[InternalTrainingID] };
                        foreach (int rh in iDelRows)
                        {
                            drDel[iCount++] = dtTrainingList.Rows.Find(grvTraining.GetDataRow(rh)[InternalTrainingID]);
                        }
                        foreach (DataRow drDelSub in drDel)
                        {
                            drDelSub.Delete();
                            DirtyData = true;
                        }
                    }

                }
                // restore cursor
                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {
                grvTraining.EndUpdate();
                // restore cursor
                this.Cursor = Cursors.Default;

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".OnDelete()", null);

            }
        }
        private void ResetInternalEducation()
        {
            try
            {
                dtTrainingList.RejectChanges();
                BindingInternalTraining();
                foreach (DataRow dr in dtTrainingList.GetErrors())
                {
                    dr.ClearErrors();
                }
                cbxTraniningCourse.Focus();
                DirtyData = false;
            }
            catch (Exception)
            {
                //HPA.Common.Helper.ShowException(e, this.Name + ".OnReset()", null);
                MessageBox.Show(this.Name + ".OnReset");
            }
        }

        private bool CommitInternalEducation()
        {
            if (!isOnDelete && !ValidateInternalEdu())
                return false;
            try
            {
                // switch to COMMITING state
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    DBEngine.beginTransaction();
                    // delete tranfer history
                    if (dtTrainingList != null && dtTrainingList.Rows.Count > 0)
                        foreach (DataRow drEdu in dtTrainingList.Rows)
                        {

                            if (drEdu.RowState == DataRowState.Deleted)
                            {
                                DBEngine.exec("HR_Person_Training_Delete",
                                    "@InternalTrainingID", drEdu[InternalTrainingID, DataRowVersion.Original],
                                    CommonConst.A_LoginID, this.UserID
                                    );
                            }
                            else
                            {
                                // save data
                                DBEngine.exec("HR_Person_Training_Save", "@InternalTrainingID", drEdu[InternalTrainingID],
                                    CommonConst.A_EmployeeID, drEdu[CommonConst.EmployeeID],
                                    "@InternalTrainingCourseID", drEdu[InternalTrainingCourseID],
                                    "@FromDate", drEdu[FromDate],
                                    "@ToDate", drEdu[ToDate],
                                    "@CompanyPaid", drEdu[CompanyPaid],
                                    "@ComAmount", drEdu[ComAmount],
                                    "@EmpAmount", drEdu[EmpAmount],
                                    "@Place", drEdu[Place],
                                    "@CommitFrom", drEdu[CommitFrom],
                                    "@CommitTo", drEdu[CommitTo],
                                    "@Note", drEdu[Note],
                                    "@SubmitCertificate", drEdu[SubmitCertificate],
                                   CommonConst.A_LoginID, UserID
                                    );
                            }
                        }
                    DBEngine.commit();
                }
                catch (Exception ex)
                {
                    // dtEmployeeInformation.RejectChanges();
                    DBEngine.rollback();
                    throw (ex);
                }

                // restore cursor
                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {
                // restore cursor
                this.Cursor = Cursors.Default;

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".Commit()", null);

                return false;
            }
            LoadInternalEducationInformation();
            // commit successfully
            DirtyData = false;
            return true;
        }

        private bool ValidateInternalEdu()
        {
            if (cbxTraniningCourse.EditValue.ToString().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxTraniningCourse.Focus();
                return false;
            }
            if (txtTrainPlace.Text.Trim().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTrainPlace.Focus();
                return false;
            }
            if (dtpTrainFrom.EditValue.ToString().Trim().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTrainPlace.Focus();
                return false;
            }
            if (dtpTrainTo.EditValue.ToString().Trim().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_DATA_REQUIRED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpTrainTo.Focus();
                return false;
            }
            if (dtpTrainFrom.DateTime.Date > dtpTrainTo.DateTime.Date)
            {
                UIMessage.ShowMessage(CommonConst.FROMDATE_TODATE_ERR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpTrainFrom.Focus();
                return false;
            }
            return true;
        }

        #endregion
        public override bool OnDelete()
        {
            isOnDelete = true;
            if (!base.OnDelete())
                return false;
            if (xtraTabControl1.SelectedTabPage.Name == Documents.Name)
            {
                DeleteDocument();

            }else
            if (xtraTabControl1.SelectedTabPage.Name == Skill.Name)
            {
                DeleteSkill();
                
            }
            else
            if (xtraTabControl1.SelectedTabPage.Name == Health.Name)
            {
                DeleteHealth();
            }
            else
            if (xtraTabControl1.SelectedTabPage.Name == Education.Name)
            {
                DeleteEducation();
            }
            else
            if (xtraTabControl1.SelectedTabPage.Name == InternalEducation.Name)
            {
                DeleteInternalEducation();
            }
            else
            if (xtraTabControl1.SelectedTabPage.Name == Experience.Name)
            {
                DeleteExperience();
            }
            else
            {
                // remember current Action State
                HPA.Component.Framework.Base.EActionState eOldActionState = ActionState;
                grvFamilyInfor.CloseEditor();
                grvFamilyInfor.UpdateCurrentRow();
                try
                {
                    // switch to DELETING state
                    ActionState = HPA.Component.Framework.Base.EActionState.BUSY;

                    // wait-cursor
                    this.Cursor = Cursors.WaitCursor;
                    if (dtFamilyinformation != null)
                    {

                        if (UIMessage.ShowMessage(3, System.Windows.Forms.MessageBoxButtons.YesNo,
                             System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            int[] iDelRows = grvFamilyInfor.GetSelectedRows();
                            DataRow[] drDel = new DataRow[iDelRows.Length];
                            int iCount = 0;
                            dtFamilyinformation.PrimaryKey = new DataColumn[] { dtFamilyinformation.Columns["FamilyInfoID"] };
                            foreach (int rh in iDelRows)
                            {
                                drDel[iCount++] = dtFamilyinformation.Rows.Find(grvFamilyInfor.GetDataRow(rh)["FamilyInfoID"]);

                            }
                            foreach (DataRow drDelSub in drDel)
                            {
                                drDelSub.Delete();
                                DirtyData = true;
                            }
                        }

                    }
                    // restore cursor
                    this.Cursor = Cursors.Default;

                    // restore action state
                    ActionState = eOldActionState;
                }
                catch (Exception e)
                {
                    grvFamilyInfor.EndUpdate();
                    DBEngine.rollback();
                    // restore cursor
                    this.Cursor = Cursors.Default;

                    // show error
                    HPA.Common.Helper.ShowException(e, this.Name + ".OnDelete()", null);

                    // restore action state
                    ActionState = eOldActionState;

                    // unable to delete
                    return false;
                }
            }
            
            // delete successfully
            return true;
        }

        

        
        
        public override bool OnAdd()
        {
            if (!base.OnAdd())
                return false;

            try
            {
                if (xtraTabControl1.SelectedTabPage.Name == Documents.Name)
                {
                    if (!AddDocument())
                        return false;
                }
                else
                if (xtraTabControl1.SelectedTabPage.Name == Skill.Name)
                {
                    if (!AddSkill())
                        return false;
                }else
                if (xtraTabControl1.SelectedTabPage.Name == Health.Name)
                {
                    if (!AddNewHealth())
                        return false;
                }
                else
                if (xtraTabControl1.SelectedTabPage.Name == Education.Name)
                {
                    if (!AddNewEducation())
                        return false;
                }
                else
                if (xtraTabControl1.SelectedTabPage.Name == InternalEducation.Name)
                {
                    if (!AddNewInternalTraining())
                        return false;
                }
                else
                if (xtraTabControl1.SelectedTabPage.Name == pageFamilyInfo.Name)
                {
                    if (!addNewFamilyInfo())
                        return false;
                }
                else
                    if (xtraTabControl1.SelectedTabPage.Name == Experience.Name)
                    {
                        if (!AddNewExperience())
                            return false;
                    }
                    else
                     if (xtraTabControl1.SelectedTabPage.Name == "Options")
                        {
                            if (!AddNewExperience())
                                return false;
                        }
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnAdd()", null);
                return false;
            }
            DisableGrid();
            return true;
        }

        private void DisableGrid()
        {
            grdEmpDocs.Enabled = false;
            grdExpericence.Enabled = false;
            //grdFamilyInfo.Enabled = false;
            grdHealthList.Enabled = false;
            grdHIList.Enabled = false;
            grdSkillList.Enabled = false;
            grdTraining.Enabled = false;
        }
        private void EnableGrid()
        {
            grdEmpDocs.Enabled = true;
            grdExpericence.Enabled = true;
            grdFamilyInfo.Enabled = true;
            grdHealthList.Enabled = true;
            grdHIList.Enabled = true;
            grdSkillList.Enabled = true;
            grdTraining.Enabled = true;
        }
        private bool addNewFamilyInfo()
        {
            // update the current row
                try
                {
                    grvFamilyInfor.ClearSorting();
                    // add a new empty row
                    CRowUtility.addNewRow(dtFamilyinformation, "FamilyInfoID", DBNull.Value, "EmployeeID", txtEmployeeID.Text);
                    // Forcus to new row
                    grvFamilyInfor.Focus();
                    grvFamilyInfor.ClearSelection();
                    grvFamilyInfor.FocusedRowHandle = grvFamilyInfor.RowCount - 1;
                    grvFamilyInfor.SelectRow(grvFamilyInfor.RowCount - 1);
                }
                catch (Exception)
                {
                    return false;
                }
            return true;
        }
        public override bool OnValidate()
        {
            try
            {
                // TODO - add code here to validate data before saving
                if (!validateFormsData())
                    return false;
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnValidate()", null);
                return false;
            }

            // validate ok
            return true;
        }
        private bool validateFormsData()
        {
            try
            {
                if (xtraTabControl1.SelectedTabPage.Name == pageGeneral.Name)
                if (dtEmployeeInfo != null)
                {
                    DataRow dr = dtEmployeeInfo.Rows[0];
                    if (dr != null)
                    {
                        // check sex field:
                        if (dr["Sex"] == DBNull.Value)
                        {
                            // assign default value:
                            dr["Sex"] = true;
                        }
                        if (dr["Product"] == DBNull.Value || dr["Product"] == DBNull.Value)
                        {
                            // assign default value:
                            dr["Product"] = true;
                        }
                        if (dr["FirstName"] == DBNull.Value)
                        {
                            focusFormsItem(2260, txtFirstName);
                            return false;
                        }
                        if (dr["LastName"] == DBNull.Value)
                        {
                            focusFormsItem(2261, txtLastname);
                            return false;
                        }
                        if (dr["HireDate"] == DBNull.Value)
                        {
                            focusFormsItem(2263, dtpJoinDate);
                            return false;
                        }
                        if (dr["PositionID"] == DBNull.Value || dr["PositionID"].ToString() == "-1")
                        {
                            focusFormsItem(2262, cbxPosition);
                            return false;
                        }
                        
                        if(dr["EmployeeTypeID"] == DBNull.Value)
                        {
                            focusFormsItem(CommonConst.INPUT_DATA_REQUIRED,cbxEmployeeTypeList );
                            return false;
                        }
                        //if (dr["PositionChangedDate"] == DBNull.Value)
                        //{
                        //    focusFormsItem(2264, dtpPositionChangedDate);
                        //    return false;
                        //}
                        
                        if (dr["DepartmentID"] == DBNull.Value ||
                            Convert.ToInt32(dr["DepartmentID"].ToString()) == -1)
                        {
                            focusFormsItem(2266, cbxDepartment);
                            return false;
                        }
                        //if (dr["SectionChangedDate"] == DBNull.Value)
                        //{
                        //    focusFormsItem(2268, dtpDivDeptChangedDate);
                        //    return false;
                        //}
                        //if (dr["WorkingPlaceID"].ToString() == "-1")
                        //{
                        //    focusFormsItem(CommonConst.INPUT_DATA_REQUIRED, cbxWorkingPlace);
                        //    return false;
                        //}
                        //if (dr["AreaID"].ToString() == "-1")
                        //{
                        //    focusFormsItem(CommonConst.INPUT_DATA_REQUIRED, cbxArea);
                        //    return false;
                        //}
                        if (dr["Birthday"] == DBNull.Value)
                        {
                            focusFormsItem(CommonConst.INPUT_DATA_REQUIRED, dtpBirthday);
                            return false;
                        }
                        
                        //						if(dr["CardID"] == DBNull.Value)
                        //						{
                        //							focusFormsItem(2269,xteTMCardNo);
                        //							return false;
                        //						}
                    }
                }
            if (isRequiredInputIDForBankTransfer && bankCode.Equals(DAB) && txtIDNumber.Text.Trim().Equals(string.Empty))
            
            {
                focusFormsItem(CommonConst.INPUT_DATA_REQUIRED, txtIDNumber);
                return false;
            }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            return true;
        }
        private void focusFormsItem(object objMessageID, DevExpress.XtraEditors.BaseEdit xle)
        {
            UIMessage.ShowMessage(objMessageID, System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Warning);
            xle.Focus();
        }
        public override bool OnReset()
        {
            try
            {
                if (DirtyData == true)
                {
                    if (UIMessage.ShowMessage(5, System.Windows.Forms.MessageBoxButtons.OKCancel,
                        System.Windows.Forms.MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        EnableGrid();
                        if (xtraTabControl1.SelectedTabPage.Name == Documents.Name)
                        {
                            ResetDocument();
                        }else
                        if (xtraTabControl1.SelectedTabPage.Name == Skill.Name)
                        {
                            ResetSkill();
                        }else
                        if (xtraTabControl1.SelectedTabPage.Name == Health.Name)
                        {
                            ResetHealth();
                        }else
                        if (xtraTabControl1.SelectedTabPage.Name == Education.Name)
                        {
                            ResetEducation();
                        }else
                        if (xtraTabControl1.SelectedTabPage.Name == InternalEducation.Name)
                        {
                            ResetInternalEducation();
                        }else
                        if (xtraTabControl1.SelectedTabPage.Name == Experience.Name)
                        {
                            ResetExperience();
                        }
                        else
                            if (xtraTabControl1.SelectedTabPage.Name == "Options")
                            {
                                ResetOptions();
                            }
                        else
                        {
                            // refresh 	
                            //if (dtEmployeeInfo != null)
                            //    dtEmployeeInfo.RejectChanges();
                            //if (dtFamilyinformation != null)
                            //    dtFamilyinformation.RejectChanges();
                            LoadEmployeeInformation();
                            LoadFamilyInformation();
                        }
                        DirtyData = false;
                    }
                }
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnReset()", null);
                return false;
            }

            return true;
        }

        

        

        

        public override bool OnExport()
        {
            try
            {
                HPA.Common.ExportData exp = new HPA.Common.ExportData(grvFamilyInfor);
                exp.ShowDialog();
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".OnExport()", null);
                return false;
            }
            return true;


        }
        public override bool Commit()
        {
            int pCheck = 0;
            try
            {

                try
                {
                    EnableGrid();
                    if (xtraTabControl1.SelectedTabPage.Name == Documents.Name)
                    {
                        if (!CommitDocument())
                            return false;
                    }
                    else
                    if (xtraTabControl1.SelectedTabPage.Name == Skill.Name)
                    {
                        if (!CommitSkill())
                            return false;
                    }
                    else
                    if (xtraTabControl1.SelectedTabPage.Name == Health.Name)
                    {
                        if (!CommitHealth())
                            return false;
                    }
                    else
                        if (xtraTabControl1.SelectedTabPage.Name == Education.Name)
                        {
                            if (!CommitEducation())
                                return false;
                        }
                        else
                            if (xtraTabControl1.SelectedTabPage.Name == InternalEducation.Name)
                            {
                                if (!CommitInternalEducation())
                                    return false;
                            }
                            else
                                if (xtraTabControl1.SelectedTabPage.Name == Experience.Name)
                                {
                                    if (!CommitExperience())
                                        return false;
                                }

                                else
                                    if (xtraTabControl1.SelectedTabPage.Name == "Options")
                                    {
                                        if (!CommitOptions())
                                            return false;
                                    }
                                else
                                {
                                    // wait-cursor
                                    this.Cursor = Cursors.WaitCursor;
                                    DBEngine.beginTransaction();
                                    if (dtEmployeeInfo != null)
                                    {
                                        byte[] Picture = new byte[0];
                                        foreach (DataRow dr in dtEmployeeInfo.Rows)
                                        {
                                            if (dr["PhotoImage"] != DBNull.Value)
                                                Picture = (byte[])dr["PhotoImage"];
                                            if (isAddNewEmployee)
                                            {
                                                if ((int.Parse(dr["SectionID"].ToString()) == -1)) { dr["SectionID"] = DBNull.Value; }
                                                if ((int.Parse(dr["GroupID"].ToString()) == -1)) { dr["GroupID"] = DBNull.Value; }
                                                isAddNewEmployee = false;
                                                DBEngine.exec("HR_Employee_Insert",
                                                    "@EmployeeID", dr["EmployeeID"],
                                                    "@Title", txtTitle.EditValue,
                                                    "@FirstName", txtFirstName.EditValue,
                                                    "@LastName", dr["LastName"],
                                                    "@Sex", dr["Sex"],
                                                    "@BranchID", dr["BranchID"],
                                                    "@DivisionID", dr["DivisionID"],
                                                    "@DepartmentID", dr["DepartmentID"],
                                                    "@SectionID", dr["SectionID"],
                                                    "@GroupID", dr["GroupID"],
                                                    "@SectionChangedDate", dr["SectionChangedDate"],
                                                    "@PositionID", dr["PositionID"],
                                                    "@PositionChangedDate", dr["PositionChangedDate"],
                                                    "@CardNo", dr["CardID"],
                                                    "@PhoneExtension", dr["Extension"],
                                                    "@OfficeEmail", dr["Email"],
                                                    "@MobilePhone", dr["MobilePhone"],
                                                    "@PhotoImage", Picture,
                                                    "@BasicInfoNotes", dr["BasicInfoNotes"],
                                                    "@Birthday", dr["Birthday"],
                                                    "@FalseDay", dr[FalseDay],
                                                    "@BirthPlace", dr["BirthPlace"],
                                                    "@Nationality", dr["Nationality"],
                                                    "@NativeCountry", dr["NativeCountry"],
                                                    "@Religion", dr["Religion"],
                                                    "@Marital", dr["Marital"],
                                                    "@HomePhone", dr["HomePhone"],
                                                    "@HomeEmail", dr["HomeEmail"],
                                                    "@HomeAddress", dr["HomeAddress"],
                                                    "@TemporaryPhone", dr["TemporaryPhone"],
                                                    "@TemporaryAddress", dr["TemporaryAddress"],
                                                    "@ID_Number", dr["ID_Number"],
                                                    "@ID_Issue_Place", dr["ID_Issue_Place"],
                                                    "@ID_ProvinceID", dr["ID_ProvinceID"],
                                                    "@ID_Issue_Date", dr["ID_Issue_Date"],
                                                    "@PassportNo", dr["PassportNo"],
                                                    "@PassportPlace", dr["PassportPlace"],
                                                    "@PassportIssueDate", dr["PassportIssueDate"],
                                                    "@PassportExpiredDate", dr["PassportExpiredDate"],
                                                    "@WorkPermitNo", dr["WorkPermitNo"],
                                                    "@WorkPermitIssueDate", dr["WorkPermit_IssueDate"],
                                                    "@WorkPermitExpireDate", dr["WorkPermit_ExpireDate"],
                                                    "@HireDate", dr["HireDate"],
                                                    "@Ethnic", dr["Ethnic"],
                                                    "@Product", dr["Product"],
                                                    "@HomeNotes", dr["HomeNotes"],
                                                    "@ProvinceID", dr["ProvinceID"],
                                                    "@Ward", dr["Ward"],
                                                    "@DistrictID", dr["DistrictID"],
                                                    "@tmpWard", dr["tmpWard"],
                                                    "@tmpDistrictID", dr["tmpDistrictID"],
                                                    "@tmpProvinceID", dr["tmpProvinceID"],
                                                    "@RateID", dr["RateID"],
                                                    "@LevelID", dr["LevelID"],
                                                    "@LineManagerID", dr[LineManagerID],
                                                    "@AreaSupID", dr[AreaSupID],
                                                    "@ContractCode", dr["ContractCode"],
                                                    "@ContractStartDate", dr["ContractStartDay"],
                                                    "@ContractEndDate", dr["ContractEndDay"],
                                                    "@ProbationEndDate", dr["ProbationEndDate"],
                                                    "@WorkingPlaceID", dr[WorkingPlaceID],
                                                    "@AreaID", dr[AreaID],
                                                    "@BankID", dr[BankID],
                                                    "@EmployeeTypeID", dr["EmployeeTypeID"],
                                                    "@AccountNo", dr[AccountNo],
                                                    "@TaxRegNo", dr[TaxRegNo],
                                                    "@Badgenumber", dr["Badgenumber"],
                                                    "@EducationalBase", dr["EducationalBase"], "@ResidentAdd", dr["ResidentAdd"],
                                                    CommonConst.A_LoginID, this.UserID);
                                                int iResult = Convert.ToInt32(DBEngine.getParamValue("@Result"));
                                                if (iResult == 1)
                                                {
                                                    UIMessage.ShowMessage(CommonConst.EmployeeCardNotSaved,
                                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    DBEngine.rollback();
                                                    // restore cursor
                                                    this.Cursor = Cursors.Default;
                                                    // unable to commit
                                                    return false;
                                                }
                                                else if (iResult == 2)
                                                {
                                                    UIMessage.ShowMessage(CommonConst.EmployeeCardNotSaved,
                                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    txtEmployeeCard.Focus();
                                                }
                                                else if (!iResult.ToString().Equals(txtEmployeeID.Text) && !iResult.ToString().Equals("0"))
                                                {
                                                    txtEmployeeID.Text = iResult.ToString();
                                                    txtEmployeeID_Leave(null, null);
                                                }
                                                else
                                                {
                                                    pCheck = 0;
                                                }
                                                UIMessage.EZLog(dtEmployeeInfo.Rows[0], dr, "tblEmployee", this.AssemblyName, "GeneralInformation", UserID);
                                            }
                                            else if (!isAddNewEmployee)
                                            {
                                                if ((int.Parse(dr["SectionID"].ToString()) == -1)) { dr["SectionID"] = DBNull.Value; }
                                                if ((int.Parse(dr["GroupID"].ToString()) == -1)) { dr["GroupID"] = DBNull.Value; }
                                                DBEngine.exec("HR_Employee_General_Update",
                                                    "@EmployeeID", dr["EmployeeID", DataRowVersion.Current],
                                                    "@Title", dr["Title"],
                                                    "@FirstName", dr["FirstName"],
                                                    "@LastName", dr["LastName"],
                                                    "@Sex", dr["Sex"],
                                                    "@BranchID", dr["BranchID"],
                                                    "@DivisionID", dr["DivisionID"],
                                                    "@DepartmentID", dr["DepartmentID"],
                                                    "@SectionID", dr["SectionID"],
                                                    "@GroupID", dr["GroupID"],
                                                    "@SectionChangedDate", dr["SectionChangedDate"],
                                                    "@PositionID", dr["PositionID"],
                                                    "@PositionChangedDate", dr["PositionChangedDate"],
                                                    "@CardNo", dr["CardID"],
                                                    "@PhoneExtension", dr["Extension"],
                                                    "@OfficeEmail", dr["Email"],
                                                    "@MobilePhone", dr["MobilePhone"],
                                                    "@PhotoImage", Picture,
                                                    "@BasicInfoNotes", dr["BasicInfoNotes"],
                                                    "@Birthday", dr["Birthday"],
                                                    "@FalseDay", dr[FalseDay],
                                                    "@BirthPlace", dr["BirthPlace"],
                                                    "@Nationality", dr["Nationality"],
                                                    "@NativeCountry", dr["NativeCountry"],
                                                    "@Religion", dr["Religion"],
                                                    "@Marital", dr["Marital"],
                                                    "@HomePhone", dr["HomePhone"],
                                                    "@HomeEmail", dr["HomeEmail"],
                                                    "@HomeAddress", dr["HomeAddress"],
                                                    "@TemporaryPhone", dr["TemporaryPhone"],
                                                    "@TemporaryAddress", dr["TemporaryAddress"],
                                                    "@IDForBankTransfer", dr["IDForBankTransfer"],
                                                    "@ID_Number", dr["ID_Number"],
                                                    "@ID_Issue_Place", dr["ID_Issue_Place"],
                                                    "@ID_ProvinceID", dr["ID_ProvinceID"],
                                                    "@ID_Issue_Date", dr["ID_Issue_Date"],
                                                    "@PassportNo", dr["PassportNo"],
                                                    "@PassportPlace", dr["PassportPlace"],
                                                    "@PassportIssueDate", dr["PassportIssueDate"],
                                                    "@PassportExpiredDate", dr["PassportExpiredDate"],
                                                    "@WorkPermitNo", dr["WorkPermitNo"],
                                                    "@WorkPermitIssueDate", dr["WorkPermit_IssueDate"],
                                                    "@WorkPermitExpireDate", dr["WorkPermit_ExpireDate"],
                                                    "@EmployeeStatusID", dr["EmployeeStatusID"],
                                                    "@TerminateDate", (dr["EmployeeStatusID"].ToString() == "20") ? dr["TerminateDate"] : DBNull.Value,
                                                    "@HireDate", dr["HireDate"],
                                                    "@Ethnic", dr["Ethnic"],
                                                    "@Product", dr["Product"],
                                                    "@ProvinceID", dr["ProvinceID"],
                                                    "@Ward", dr["Ward"],
                                                    "@DistrictID", dr["DistrictID"],
                                                    "@tmpWard", dr["tmpWard"],
                                                    "@tmpDistrictID", dr["tmpDistrictID"],
                                                    "@tmpProvinceID", dr["tmpProvinceID"],
                                                    "@HomeNotes", dr["HomeNotes"],
                                                    "@EducationalBase", dr["EducationalBase"],
                                                    "@ResidentAdd", dr["ResidentAdd"],
                                                    "@RateID", dr["RateID"],
                                                    "@LevelID", dr["LevelID"],
                                                    "@AreaSupID", dr[AreaSupID],
                                                    "@LineManagerID", dr[LineManagerID],
                                                    "@BankID", dr[BankID],
                                                    "@AccountNo", dr[AccountNo],
                                                    "@TaxRegNo", dr[TaxRegNo],
                                                    "@Badgenumber", dr["Badgenumber"],
                                                    "@EmployeeTypeID", dr["EmployeeTypeID"],
                                                    "@ContractCode", dr["ContractCode"],
                                                    "@ContractStartDate", dr["ContractStartDay"],
                                                    "@ContractEndDate", dr["ContractEndDay"],
                                                    "@ProbationEndDate", dr["ProbationEndDate"],
                                                    "@WorkingPlaceID", dr[WorkingPlaceID],
                                                    "@AreaID", dr[AreaID],
                                                    CommonConst.A_LoginID, this.UserID);	//HieuBH : 10/03/2009
                                                int iResult = Convert.ToInt32(DBEngine.getReturnValue());
                                                if (iResult == 3) // ID number is duplicated
                                                {
                                                    //get EmployeeID by ID number
                                                    string strOldEmployeID;
                                                    string strMess;
                                                    DataTable dtDuplicateID = DBEngine.execReturnDataTable(string.Format("select EmployeeID from tblEmployee where ID_Number = '{0}' and EmployeeID <> '{1}'", dr["ID_Number"].ToString().Trim(), txtEmployeeID.Text.Trim()));
                                                    if (dtDuplicateID != null && dtDuplicateID.Rows.Count > 0)
                                                    {
                                                        strOldEmployeID = dtDuplicateID.Rows[0][0].ToString();
                                                        strMess = UIMessage.Get_Message(CommonConst.ID_NUMBER_DUPLICATE);
                                                        MessageBox.Show(string.Format(strMess, txtEmployeeID.Text.Trim(), strOldEmployeID), this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    }


                                                }
                                                UIMessage.EZLog(dtOldEmployeeInfo.Rows[0], dr, "tblEmployee", this.AssemblyName, "GeneralInformation", UserID);
                                                //if (iResult == 1)
                                                //{
                                                //    UIMessage.ShowMessage(CommonConst.EmployeeCardNotSaved,
                                                //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                //    DBEngine.rollback();
                                                //    // restore cursor
                                                //    this.Cursor = Cursors.Default;
                                                //    // unable to commit
                                                //    return false;
                                                //}
                                                //else 
                                                //    if (iResult == 2)
                                                //{
                                                //    UIMessage.ShowMessage(CommonConst.EmployeeCardNotSaved,
                                                //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                //    txtEmployeeCard.Focus();
                                                //}
                                                //else
                                                {
                                                    pCheck = 1;
                                                }
                                            }
                                            
                                        }
                                    }
                                    dtEmployeeInfo.AcceptChanges();
                                    // save family information
                                    if (dtFamilyinformation != null && dtFamilyinformation.Rows.Count > 0)
                                        foreach (DataRow drFamily in dtFamilyinformation.Rows)
                                        {
                                            if (drFamily.RowState == DataRowState.Added)
                                            {
                                                if (drFamily["Name"] == DBNull.Value || drFamily["Name"].ToString().Equals(""))
                                                    continue;
                                                DBEngine.exec("HR_Person_Family_Insert",
                                                    "@EmployeeID", drFamily["EmployeeID"],
                                                    "@Name", drFamily["Name"],
                                                    "@BirthDay", drFamily["BirthDay"],
                                                    "@RelationID", drFamily["RelationID"],
                                                    "@Career", drFamily["Career"],
                                                    "@WorkingPlace", drFamily["WorkingPlace"],
                                                    "@Income", drFamily["Income"],
                                                    "@Address", drFamily["Address"],
                                                    "@TaxNo", drFamily["TaxNo"],
                                                    "@IDNumber", drFamily["IDNumber"],
                                                    "@TaxDependant", drFamily["TaxDependant"],
                                                    CommonConst.A_LoginID, this.UserID
                                                    );
                                            }
                                            else if (drFamily.RowState == DataRowState.Modified)
                                            {
                                                DBEngine.exec("HR_Person_Family_Update",
                                                    "@FamilyInfoID", drFamily["FamilyInfoID"],
                                                    "@EmployeeID", drFamily["EmployeeID"],
                                                    "@Name", drFamily["Name"],
                                                    "@BirthDay", drFamily["BirthDay"],
                                                    "@RelationID", drFamily["RelationID"],
                                                    "@Career", drFamily["Career"],
                                                    "@WorkingPlace", drFamily["WorkingPlace"],
                                                    "@Income", drFamily["Income"],
                                                    "@Address", drFamily["Address"],
                                                    "@TaxNo", drFamily["TaxNo"],
                                                     "@IDNumber", drFamily["IDNumber"],
                                                    "@TaxDependant", drFamily["TaxDependant"],
                                                    CommonConst.A_LoginID, this.UserID
                                                    );
                                            }
                                            else if (drFamily.RowState == DataRowState.Deleted)
                                            {
                                                DBEngine.exec("HR_Person_Family_Delete",
                                                    "@FamilyInfoID", drFamily["FamilyInfoID", DataRowVersion.Original],
                                                    "@EmployeeID", drFamily["EmployeeID", DataRowVersion.Original],
                                                    CommonConst.A_LoginID, this.UserID
                                                    );
                                            }
                                        }
                                    DBEngine.commit();
                                    LoadFamilyInformation();
                                    LoadEmployeeInformation();
                                }
                    isOnDelete = false;
                }
                catch (Exception ex)
                {
                    // dtEmployeeInformation.RejectChanges();
                    DBEngine.rollback();
                    throw (ex);
                }

                // restore cursor
                this.Cursor = Cursors.Default;

            }
            catch (Exception e)
            {
                // restore cursor
                this.Cursor = Cursors.Default;

                // show error
                HPA.Common.Helper.ShowException(e, this.Name + ".Commit()", null);

                return false;
            }
            if (pCheck == 0 ||pCheck == 1 )
                UIMessage.ShowMessage(HPA.Common.CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                UIMessage.ShowMessage(HPA.Common.CommonConst.DELETE_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DirtyData = false;
            // commit successfully
            return true;
        }

        private void cbxTmpProvince_EditValueChanged(object sender, EventArgs e)
        {
            string filter = string.Format("ProvinceID = '{0}'", cbxTmpProvince.EditValue);
            dtTmpDistrict.DefaultView.RowFilter = filter;
        }

        private void cbxProvince_EditValueChanged_1(object sender, EventArgs e)
        {
            string filter = string.Format("ProvinceID = '{0}'", cbxProvince.EditValue);
            dtDistrict.DefaultView.RowFilter = filter;
        }

        private void cbxSection_EditValueChanged_1(object sender, EventArgs e)
        {
            if (dvGroup != null)
            {
                string sectionID = cbxSection.EditValue.ToString();
                if(!sectionID.Trim().Equals(string.Empty))
                    dvGroup.RowFilter = string.Format("SectionID = {0}", sectionID);
            }
        }

        private void btnIDauto_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable a = DBEngine.execReturnDataTable("tl_getnewid");

                txtEmployeeID.Text = a.Rows[0][0].ToString();
                isAddNewEmployee = true;
                txtEmployeeID.Properties.ReadOnly = true;
                this.LoadEmployeeInformation();
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "btnIDauto_Click");
            }
        }

        private void txtLastname_Leave(object sender, EventArgs e)
        {
            txtLastname.Text = StandardName.TitleCase(txtLastname.Text.Trim());
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            txtFirstName.Text = StandardName.TitleCase(txtFirstName.Text.Trim());
        }

        private void GeneralInformation_Activated(object sender, EventArgs e)
        {
            if ((UIMessage.EmployeeID != null) )
            {
                if (txtEmployeeID.Text.Equals(UIMessage.EmployeeID))
                    return;
                txtEmployeeID.Text = UIMessage.EmployeeID;
                LoadEmployeeInformation();
            }
        }

        private void txtEmployeeID_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // show employeeID list
                object obj;
                CommonForm.EmployeeIDList employeeList = new CommonForm.EmployeeIDList();
                OpenObject("HPA.CommonForm", "EmployeeIDList", true, null, out obj);
                txtEmployeeID.Text = ((string[])obj)[0];
                txtLastname.Focus();
                //Show infomation
                //LoadEmployeeInformation();
                //LoadFamilyInformation();
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "txtEmployeeID_KeyUp");
                return;
            }
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (txtEmployeeID.Text.Trim().Equals(string.Empty))
            {
                UIMessage.ShowMessage(CommonConst.INPUT_EMPLOYEEID, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeID.Focus();
                e.Cancel = true;
                return;
            }
            if (DirtyData == true)
            {
                UIMessage.ShowMessage(CommonConst.SAVE_DATA_FIRST, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void xbeFileName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                xbeFileName_MouseClick(null, null);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            ViewCertificate(tblID.Text);
        }
        private void ViewCertificate(string docID)
        {
            if (dtDocs != null && dtDocs.Rows.Count > 0)
            {
                DataRow dr = dtDocs.Rows.Find(docID);
                string strext = dr[ext].ToString();
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = string.Format("Type {0} | *.{1}", strext, strext);
                dlg.DefaultExt = ext;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DataTable a = new DataTable();
                        string fileName = dlg.FileName.ToString();
                        FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                        BinaryWriter w = new BinaryWriter(file);
                        a = DBEngine.execReturnDataTable("sp_get_file",
                                                 "@id", docID
                                               );

                        w.Write((byte[])a.Rows[0]["File"]);
                        file.Close();
                        Process.Start(fileName);
                    }
                    catch (Exception ex)
                    {
                        UIMessage.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private void xbeFileName_EditValueChanged(object sender, EventArgs e)
        {
            DirtyData = true;
        }

        private void btnSkillViewCer_Click(object sender, EventArgs e)
        {
            DataRow dr = grvSkillList.GetDataRow(grvSkillList.FocusedRowHandle);
            string strDocID = dr[DocID].ToString();
            ViewCertificate(strDocID);
        }

        private void btnViewEducationCer_Click(object sender, EventArgs e)
        {
            DataRow dr = grvEducationList.GetDataRow(grvEducationList.FocusedRowHandle);
            string strDocID = dr[DocID].ToString();
            ViewCertificate(strDocID);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DirtyData = true;
        }

        private void dtpJoinDate_EditValueChanged(object sender, EventArgs e)
        {
            if (isAddNewEmployee)
            {
                dtpEffectiveDate.EditValue = dtpPositionChangedDate.EditValue = dtpDivDeptChangedDate.EditValue = dtpJoinDate.DateTime.Date;
                dtEmployeeInfo.Rows[0]["PositionChangedDate"] = dtEmployeeInfo.Rows[0]["SectionChangedDate"] = dtpJoinDate.DateTime.Date;
            }
        }

        private void cbxContractType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxContractType.EditValue.ToString().Equals("004") || cbxContractType.EditValue.ToString().Equals("006"))
                {dtEmployeeInfo.Rows[0]["ContractStartDay"] = dtpContractFromDate.EditValue = dtpJoinDate.EditValue;
                dtEmployeeInfo.Rows[0]["ContractEndDay"] = dtpContractToDate.EditValue = dtpContractFromDate.DateTime.Date.AddMonths(Convert.ToInt16(dtContractType.Rows.Find(cbxContractType.EditValue)["Duration"])).AddDays(-1);                
                }
                
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void dtpContractFromDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtEmployeeInfo.Rows[0]["ContractEndDay"] = dtpContractToDate.EditValue = dtpContractFromDate.DateTime.Date.AddMonths(Convert.ToInt16(dtContractType.Rows.Find(cbxContractType.EditValue)["Duration"])).AddDays(-1);                
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void dtpContractToDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxContractType.EditValue.ToString().Equals("004") || cbxContractType.EditValue.ToString().Equals("006"))
                {
                    dtEmployeeInfo.Rows[0]["ProbationEndDate"] = dtpProbationEndDate.EditValue = dtpContractToDate.DateTime.Date;
                }
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "");
            }
        }

        private void cbxContractType_EnabledChanged(object sender, EventArgs e)
        {
            dtpContractToDate.Enabled = dtpContractFromDate.Enabled = dtpProbationEndDate.Enabled = cbxContractType.Enabled;
        }

        private void txtLineManager_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // show employeeID list
                object obj;
                CommonForm.EmployeeIDList employeeList = new CommonForm.EmployeeIDList();
                OpenObject("HPA.CommonForm", "EmployeeIDList", true, null, out obj);
                txtLineManager.Text = ((string[])obj)[0];
                txtLineManagerName.Text = ((string[])obj)[1];
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, this.Name, "txtLineManager_DoubleClick");
                return;
            }
        }

        private void txtLineManager_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                try
                {
                    // show employeeID list
                    object obj;
                    CommonForm.EmployeeIDList employeeList = new CommonForm.EmployeeIDList();
                    OpenObject("HPA.CommonForm", "EmployeeIDList", true, null, out obj);
                    txtLineManager.Text = ((string[])obj)[0];
                    txtLineManagerName.Text = ((string[])obj)[1];
                }
                catch (Exception ex)
                {
                    HPA.Common.Helper.ShowException(ex, this.Name, "txtLineManager_DoubleClick");
                    return;
                }
            }
        }

        private void txtLineManager_Leave(object sender, EventArgs e)
        {
            if (!txtLineManager.Text.Trim().Equals(""))
            {
                DataTable dtFullName = DBEngine.execReturnDataTable("sp_hr_get_fullname", CommonConst.A_EmployeeID, txtLineManager.Text, CommonConst.A_LoginID, UserID);
                if (dtFullName != null && dtFullName.Rows.Count > 0)
                {
                    txtLineManagerName.Text = dtFullName.Rows[0][0].ToString();
                }
                else
                {
                    txtLineManager.Text = txtLineManagerName.Text = "";
                }
            }
            else
                txtLineManagerName.Text = "";
        }
        bool isRequiredInputIDForBankTransfer = false;
        string bankCode = string.Empty;
        private void cbxBankName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBank = (DataTable)cbxBankName.Properties.DataSource;
                bankCode = dtBank.Select(string.Format("BankID = '{0}'", cbxBankName.EditValue))[0]["BankCode"].ToString().ToLower();
                if (bankCode.ToLower().Equals(DAB))
                {
                    isRequiredInputIDForBankTransfer = true;
                    lblIDForBankTransfer.Visible = txtIDForBankTransfer.Visible = true;
                }
                else
                {
                    isRequiredInputIDForBankTransfer = false;
                    lblIDForBankTransfer.Visible = txtIDForBankTransfer.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
        bool isUserSet = false;
        private void imgEmployeeImage_EditValueChanged(object sender, EventArgs e)
        {
            if (isUserSet)
            {
                isUserSet = false;
                return;
            }
            if (imgEmployeeImage.Image != null)
            {
                isUserSet = true;
                imgEmployeeImage.EditValue = CImageUtility.ResizeImage(imgEmployeeImage.Image, imgEmployeeImage.Size.Width, imgEmployeeImage.Size.Height);
            }
            else
                isUserSet = false;
        }

    }
}