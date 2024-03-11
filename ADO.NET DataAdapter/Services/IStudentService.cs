using ADO.NET_DataAdapter.Model;

namespace ADO.NET_DataAdapter.Services
{
    public interface IStudentService
    {
        public List<Student> GetAll();
        public string AddStudent(Student student);
    }
}
