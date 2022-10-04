using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAppLab29_09_22.Models
{
    public class TeacherService
    {
        private SqlConnection _SqlConnection;
        private SqlCommand _command;
        private SqlDataAdapter _adapter;
        private DataTable _dataTable = new DataTable();
        public TeacherService()
        {
            string cons = "Data Source=DESKTOP-2V92DCR;Initial Catalog=Classlecture;Integrated Security=True";
            _SqlConnection = new SqlConnection(cons);
            _SqlConnection.Open();
        }
        public List<TeacherModel> GetAllTeacher()
        {
            var TeacherList = new List<TeacherModel>();
            _command = new SqlCommand("Select * from Teacher", _SqlConnection);
            _adapter = new SqlDataAdapter(_command);
            _adapter.Fill(_dataTable);
            _command.Dispose();
            _SqlConnection.Close();
            foreach (DataRow dr in _dataTable.Rows)
            {
                TeacherList.Add(new TeacherModel
                {
                    TID = Convert.ToInt32(dr["TID"]),
                    FirstName = Convert.ToString(dr["FirstName"]),
                    LastName = Convert.ToString(dr["LastName"]),
                    Subjects = Convert.ToString(dr["Subjects"])
                });
            }
            return TeacherList;
        }

        public void SetDataInDBINsert(TeacherModel obj)
        {
            obj.TID = Convert.ToInt32(obj.TID);
            obj.FirstName = Convert.ToString(obj.FirstName);
            obj.LastName = Convert.ToString(obj.LastName);
            obj.Subjects = Convert.ToString(obj.Subjects);
            _command = new SqlCommand("insert into Teacher (Tid,FirstName,LastName,Subjects) values ('" + obj.TID + "','" + obj.FirstName + "'," +
                ""    + "'" + obj.LastName + "', '" + obj.Subjects + "')", _SqlConnection);
            _command.ExecuteNonQuery();
            _command.Dispose();
            _SqlConnection.Close();
        }

        public void DeletDataFromDb(int id)
        {


            //id = Convert.ToInt32(id);
            _command= new SqlCommand("Delete  from Teacher where TID= " + id, _SqlConnection);
            //_cmd.Parameters.AddWithValue("@Sid", id);

            _command.ExecuteNonQuery();
            _command.Dispose();

            _SqlConnection.Close();
        }
        public void EditDataInDbt(int id, TeacherModel obj)
        {
            obj.TID = Convert.ToInt32(obj.TID);
            obj.FirstName = Convert.ToString(obj.FirstName);
            obj.LastName = Convert.ToString(obj.LastName);
            obj.Subjects = Convert.ToString(obj.Subjects);
            _command = new SqlCommand("Update Teacher set FirstName ='" + obj.FirstName + "' ,LastName = '" + obj.LastName + "'," +
                " Subjects= '" + obj.Subjects + "' where TID =" + id, _SqlConnection);
            _command.ExecuteNonQuery();
            _command.Dispose();
            _SqlConnection.Close();
        }



        public TeacherModel GetIDTeacher(int id)
        {
            var teacher = new TeacherModel();
            _command = new SqlCommand("Select * from Teacher where TID= " + id, _SqlConnection);
            _adapter = new SqlDataAdapter(_command);
            _adapter.Fill(_dataTable);
            _command.Dispose();
            _SqlConnection.Close();

            var dr = _dataTable.Rows[0];

            teacher.TID = Convert.ToInt32(dr[0]);
            teacher.FirstName = Convert.ToString(dr[1]);
            teacher.LastName = Convert.ToString(dr[2]);
            teacher.Subjects = Convert.ToString(dr[3]);

            return teacher;
        }
    }
}