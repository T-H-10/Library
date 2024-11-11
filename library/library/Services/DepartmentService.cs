using library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace library.Services
{
    public class DepartmentService
    {
        public List<Department> GetDepartments() => DataContext.Departments;
        public Department GetDepartment(int code) =>
            DataContext.Departments.Find(department => department.Code == code);
        //{
        //    foreach (var department in DataContext.Departments)
        //    {
        //        if (department.Code == code)
        //            return department;
        //    }
        //    return null;
        //}
        public bool AddDepartment([FromBody] Department department)
        {
            if (department == null) return false;
            DataContext.Departments.Add(department);
            return true;
        }
        public bool UpdateDepartment(int code, [FromBody] Department department)
        {
            if (department == null) { return false; }
            for (int i = 0; i < DataContext.Departments.Count; i++)
            {
                if (DataContext.Departments[i].Code == code)
                {
                    DataContext.Departments[i].Name = department.Name;
                    DataContext.Departments[i].Description = department.Description;
                    DataContext.Departments[i].Age = department.Age;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteDepartment(int code)=>
            DataContext.Departments.Remove(GetDepartment(code));
        //{
        //    for (int i = 0; i < DataContext.Departments.Count; i++)
        //    {
        //        if (DataContext.Departments[i].Code == code)
        //        {
        //            DataContext.Departments.RemoveAt(i);
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
