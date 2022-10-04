using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppLab29_09_22.Models
{
    public class StudentService
    {
        private SqlConnection _SqlConnection;
        private SqlCommand _command;
        private SqlDataAdapter _adapter;
        private DataTable _dataTable=new DataTable();
        public StudentService()
        {
            string cons = "Data Source=DESKTOP-2V92DCR;Initial Catalog=Classlecture;Integrated Security=True";
            _SqlConnection = new SqlConnection(cons);
            _SqlConnection.Open();
        }
       
        public List<StudentModel> GetAllStudent()
        {
            var StudentList=new List<StudentModel>();
            _command = new SqlCommand("Select * from Student", _SqlConnection);
            _adapter = new SqlDataAdapter(_command);
            _adapter.Fill(_dataTable);
            _command.Dispose();
            _SqlConnection.Close();
            foreach (DataRow dr in _dataTable.Rows)
            {
                StudentList.Add(new StudentModel
                {
                    SID = Convert.ToInt32(dr["SID"]),
                    FirstName = Convert.ToString(dr["FirstName"]),
                    LastName = Convert.ToString(dr["LastName"]),
                    Subjects = Convert.ToString(dr["Subjects"])
                });
            }
            return StudentList;
        }
        public void SetDataInDBINsert(StudentModel obj)
        {
            obj.SID = Convert.ToInt32(obj.SID);
            obj.FirstName = Convert.ToString(obj.FirstName); 
            obj.LastName = Convert.ToString(obj.LastName);
            obj.Subjects = Convert.ToString(obj.Subjects);
            _command = new SqlCommand("insert into Student (FirstName,LastName,Subjects) values ('" + obj.FirstName + "',"
              + "'" + obj.LastName + "', '"+ obj.Subjects+"')", _SqlConnection);
            _command.ExecuteNonQuery();
            _command.Dispose();
            _SqlConnection.Close();
        }

        public void DeletDataFromDb(int id)
        {


            //id = Convert.ToInt32(id);
            _command = new SqlCommand("Delete  from Student where SID= " + id, _SqlConnection);
            //_cmd.Parameters.AddWithValue("@Sid", id);

            _command.ExecuteNonQuery();
            _command.Dispose();

            _SqlConnection.Close();
        }

     
        public void EditDataInDbt(int id,StudentModel obj)
        {
            obj.SID = Convert.ToInt32(obj.SID);
            obj.FirstName = Convert.ToString(obj.FirstName);
            obj.LastName = Convert.ToString(obj.LastName);
            obj.Subjects = Convert.ToString(obj.Subjects);
            _command = new SqlCommand("Update Student set FirstName ='" + obj.FirstName + "' ,LastName = '" + obj.LastName + "'," +
                " Subjects= '" + obj.Subjects + "' where SID =" + id, _SqlConnection);
            _command.ExecuteNonQuery();
            _command.Dispose();
            _SqlConnection.Close();
        }

       

        public StudentModel GetIDStudent(int id)
        {
            var student = new StudentModel();
            _command = new SqlCommand("Select * from Student where SID= " + id , _SqlConnection);
            _adapter = new SqlDataAdapter(_command);
            _adapter.Fill(_dataTable);
            _command.Dispose();
            _SqlConnection.Close();

            var dr = _dataTable.Rows[0];

            student.SID = Convert.ToInt32(dr[0]);
            student.FirstName = Convert.ToString(dr[1]);
            student.LastName = Convert.ToString(dr[2]);
            student.Subjects = Convert.ToString(dr[3]);

            return student;
        }
        
    }
}
//~StudentService()
//{
//    _command.Dispose();
//    _SqlConnection.Close();
//}

//public void EditDataInDb( int id)
//{
//    _command = new SqlCommand("update Student set FirstName='Hamza', Subjects='webEnginering' where SID= " + id, _SqlConnection);
//    _command.ExecuteNonQuery();
//    _command.Dispose();
//    _SqlConnection.Close();
//}