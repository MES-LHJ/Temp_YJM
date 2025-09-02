using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.department.Models;
using WindowsFormsApp1.employee.Models;
using WindowsFormsApp1.Utiliity;

namespace WindowsFormsApp1
{
    public partial class DelEmployee : Form
    {
        private readonly int employeeId;
        private EmployeeDto DelEmpInfo = new EmployeeDto();
        private readonly Util util = new Util();//공통 코드

        public DelEmployee(int empId)
        {
            employeeId = empId;

            InitializeComponent();
            Click_Event();

            this.Load += DelEmployee_Load_1;
        }
        private void Click_Event()
        {
            delBtn.Click += Del_Button;//삭제 버튼
            cancelBtn.Click += Cancel_Button;//취소 버튼
        }

        private void DelEmployee_Load_1(object sender, EventArgs e)
        {
            DelEmpInfo = EmployeeRepository.EmpRepo.empDelInfo(employeeId);
            if (DelEmpInfo != null)
            {
                empCodeLabel.Text = "사원코드 : " + DelEmpInfo.EmployeeCode;
                empNameLabel.Text = "사원명 : " + DelEmpInfo.EmployeeName;
            }
            else
            {
                MessageBox.Show("사원 정보를 찾을 수 없습니다.");
                this.Close();
            }
        }

        private void Del_Button(object sender, EventArgs e)
        {

            //var delResult = EmployeeRepository.empRepo.DelEmp(employee.employeeId, employee.imgId);
            if (DelEmpInfo != null)
            {
                using (var context = new LinqContext())
                {
                    var delEmp = context.Employee.FirstOrDefault(a => a.employeeId == DelEmpInfo.EmployeeId);
                    var imgDel = context.img.FirstOrDefault(i => i.imgId == DelEmpInfo.ImgId);

                    Console.WriteLine(DelEmpInfo.EmployeeId);
                    Console.WriteLine(DelEmpInfo.ImgId);
                   
                    if (delEmp != null)
                    {
                        context.Employee.Remove(delEmp);
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("사원 삭제 실패");
                        return;
                    }

                    if (imgDel != null)
                    {
                        context.img.Remove(imgDel);
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("사진 삭제 실패");
                        return;
                    }
                 
                    string folderPath = util.ImgFolderPath() + DelEmpInfo.ImgId;

                    if (Directory.Exists(folderPath))
                    {

                        Directory.Delete(@"C:\NAS\" + DelEmpInfo.ImgId, true);

                    }
                    MessageBox.Show("삭제에 성공하였습니다.");
                    this.DialogResult = DialogResult.OK;
                }
            }
          
        }
        private void Cancel_Button(object sender, EventArgs e)
        {
            this.Close(); // 취소 버튼 클릭 시 폼 닫기

        }


    }
}
