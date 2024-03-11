using ADO.NET_DataAdapter.Model;
using System.Data;
using System.Data.SqlClient;
namespace ADO.NET_DataAdapter.Services
{
    public class StudentService : IStudentService
    {
        public readonly IConfiguration _Configuration;
        public string CString { get; set; }
        public StudentService(IConfiguration configuration)
        {
            _Configuration = configuration;
            CString = _Configuration["ConnectionStrings:DefaultConnection"];
        }
        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(CString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from STUDENTS", connection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "studentTable");
                foreach (DataRow row in dataSet.Tables["studentTable"].Rows)
                {
                    students.Add
                        (
                            new Student
                            {
                                Id = Convert.ToInt32(row["StudentID"]),
                                FirstName = row["FirstName"].ToString(),
                                LastName = row["LastName"].ToString(),
                                Age = Convert.ToInt32(row["Age"])
                            }
                        );
                }
                return students;
            }
        }
        public string AddStudent(Student student)
        {
            Student std = new Student();
            using(SqlConnection connection = new SqlConnection(CString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from students", connection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "NewRow");
                DataRow newrow = dataSet.Tables["NewRow"].NewRow();
                newrow["FirstName"] = student.FirstName.ToString();
                newrow["LastName"] = student.LastName.ToString();
                newrow["Age"] = Convert.ToInt32(student.Age);
                dataSet.Tables["NewRow"].Rows.Add(newrow);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataSet, "NewRow");
            }
            return "Inserted Sucessfully";
        }
    }
}
