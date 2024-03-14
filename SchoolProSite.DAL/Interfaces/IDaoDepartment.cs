

using SchoolProSite.DAL.Entities;

namespace SchoolProSite.DAL.Interfaces
{
    public interface IDaoDepartment
    {
void SaveDepartment(Department department);
        void UpdateDepartment(Department department);
        void RemoveDepartment(Department department);
        Department? GetDepartment(int id);
        List<Department> GetDepartments();
        bool ExistsDepartments(Func<Department,bool>filter);
        List<Department> GetDepartments(Func<Department, bool> filter);
    }
}
