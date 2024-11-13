using library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace library.Services
{
    public class DepartmentService
    {
        readonly IDataContext _dataContext;
        public DepartmentService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Department> GetDepartments() => _dataContext.LoadDepartments();
        public Department GetDepartment(int code)
        {
            List<Department> departments = _dataContext.LoadDepartments();
            if(departments == null) { return null; }
            return departments.Find(department => department.Code == code);
        }
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
            List<Department> departments = _dataContext.LoadDepartments();
            departments.Add(department);
            return _dataContext.SaveDepartments(departments);
        }
        public bool UpdateDepartment(int code, [FromBody] Department department)
        {
            if (department == null) { return false; }
            List<Department> departments = _dataContext.LoadDepartments();
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Code == code)
                {
                    departments[i].Name = department.Name;
                    departments[i].Description = department.Description;
                    departments[i].Age = department.Age;
                    return _dataContext.SaveDepartments(departments);
                }
            }
            return false;
        }
        public bool DeleteDepartment(int code)
        // DataContext.Departments.Remove(GetDepartment(code));
        {
            List<Department> departments = _dataContext.LoadDepartments();
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Code == code)
                {
                    departments.RemoveAt(i);
                    return _dataContext.SaveDepartments(departments);
                }
            }
            return false;
        }
    }
}
