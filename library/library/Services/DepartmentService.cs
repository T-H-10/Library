using library.Entities;
using Microsoft.AspNetCore.Mvc;

namespace library.Services
{
    public class DepartmentService
    {
        private List<Department> departments = new List<Department>();

        public List<Department> GetDepartments()
        {
            return departments;
        }
        public Department GetDepartment(int code)
        {
            foreach (var department in departments)
            {
                if (department.Code == code)
                    return department;
            }
            return null;
        }
        public bool PostDepartment([FromBody] Department department)
        {
            if (department == null) return false;
            departments.Add(department);
            return true;
        }
        public bool PutDepartment(int code, [FromBody] Department department)
        {
            if (department == null) { return false; }
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Code == code)
                {
                    departments[i] = department;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteDepartment(int code)
        {
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Code == code)
                {
                    departments.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
