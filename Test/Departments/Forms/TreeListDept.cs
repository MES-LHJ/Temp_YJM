using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Test.Departments.Models;
using Test.Employees.Models;

namespace Test.Departments.Forms
{
    public partial class TreeListDept : Form
    {
        public TreeListDept()
        {
            InitializeComponent();

            this.Load += TreeListDept_Load;
        }

        private void TreeListDept_Load(object sender, EventArgs e)
        {
            List<DepartmentDto> mainList = DepartmentRepository.DeptRepo.GetMainDeptInfo();  // DTO 반환
            List<DepartmentDto> subList = DepartmentRepository.DeptRepo.GetSubDeptInfo();    // DTO 반환
            List<EmployeeDto> empList = EmployeeRepository.EmpRepo.TreeListEmp();    // DTO 반환
            List<TreeListDto> allList = mainList.Select(d => new TreeListDto
            {
                Id = d.DepartmentId.ToString(),
                DepartmentCode = d.DepartmentCode,
                DepartmentName = d.DepartmentName,
                Memo = d.Memo,

            })
                                                    .Concat(subList.Select(s => new TreeListDto
                                                    {
                                                        Id = $"S_{s.SubDeptId}",
                                                        ParentId = s.DepartmentId.ToString(),
                                                        DepartmentCode = s.SubDeptCode,
                                                        DepartmentName = s.SubDeptName,
                                                        Memo = s.Memo,
                                                    }))
                                                    .Concat(empList.Select(em => new TreeListDto
                                                    {
                                                        ParentId = $"S_{em.SubDeptId}",
                                                        Id = $"E_{em.EmployeeId}",
                                                        DepartmentName = em.EmployeeName,
                                                        DepartmentCode = em.EmployeeCode
                                                    }))
                                                    .ToList();

            deptTreeList.DataSource = allList;
            deptTreeList.KeyFieldName = "Id";
            deptTreeList.ParentFieldName = "ParentId";
        }
    }
}
