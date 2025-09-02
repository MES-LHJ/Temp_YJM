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

namespace WindowsFormsApp1
{
    public partial class DelEmployee : Form
    {
        private readonly EmployeeDto employee = new EmployeeDto();

        public DelEmployee(int empId)
        {
            employee.EmployeeId = empId;

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
            var delInfo = EmployeeRepository.EmpRepo.empDelInfo(employee.EmployeeId);
            if (delInfo != null)
            {
                empCodeLabel.Text = "사원코드 : " + delInfo.EmployeeCode;
                empNameLabel.Text = "사원명 : " + delInfo.EmployeeName;
                employee.ImgId = delInfo.ImgId;
                employee.ImgName = delInfo.ImgName;
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
            //string delImgSql = "DELETE FROM img WHERE imgId = @imgId";
            //string sql = "DELETE FROM employee WHERE employeeId = @employeeId";
            using(var context = new LinqContext())
            {
                var delEmp = context.Employee.FirstOrDefault(a=>a.employeeId == employee.EmployeeId);
                if(delEmp != null)
                {
                    context.Employee.Remove(delEmp);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("사원 삭제 실패");
                    return;
                }
                    var imgDel = context.img.FirstOrDefault(i => i.imgId == employee.ImgId);
                if(imgDel != null){
                    context.img.Remove(imgDel);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("사진 삭제 실패");
                    return;
                }

                string folderPath = @"C:\NAS\" + employee.ImgId;
                if (Directory.Exists(folderPath))
                {
                  
                    Directory.Delete(@"C:\NAS\" + employee.ImgId, true);

                }
                MessageBox.Show("삭제에 성공하였습니다.");
                this.DialogResult = DialogResult.OK;
            }
            //if (delResult == 1)
            //{
            //    if (!string.IsNullOrEmpty(employee.imgId.ToString()))
            //    {
                    
            //        Directory.Delete(@"C:\NAS\" + employee.imgId, true);

            //        //File.Delete(@"C:\NAS\" + employee.employeeId + @"\" + employee.imgName);
            //    }
            //    MessageBox.Show("삭제에 성공하였습니다.");
            //    this.DialogResult = DialogResult.OK;
            //}
            //else
            //{
            //    MessageBox.Show("삭제에 실패하였습니다.");
            //}
        }
        private void Cancel_Button(object sender, EventArgs e)
        {
            this.Close(); // 취소 버튼 클릭 시 폼 닫기

        }


    }
}
