using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ASP.NET_CURD_Application
{
    public partial class Default : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(" Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KapilDB.mdf;Integrated Security=True; MultipleActiveResultSets=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cmd= new SqlCommand("select emp_no from employee",con);
                con.Open();
                reader = cmd.ExecuteReader();
                DropDownList1.Items.Clear();

                while(reader.Read())
                {
                    DropDownList1.Items.Add(reader.GetValue(0).ToString());


                }
                con.Close();

            }
        }

       

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            add.Enabled = true;
            string dd = DropDownList1.Text;
            cmd=new SqlCommand("select * from employee where emp_no = '"+DropDownList1.Text+"'",con);
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    txtname.Text = reader.GetValue(1).ToString();
                    txtaddress.Text = reader.GetValue(2).ToString();
                    txtposition.Text = reader.GetValue(3).ToString();
                }

            }catch(SqlException ex)
            {
                Response.Write(ex.Message);
                string msg = "alert(\"Employee Registered Success\")";
                ScriptManager.RegisterStartupScript(this, GetType(), "server script", msg, true);       
            }finally { con.Close(); }

        }

        protected void add_Click(object sender, EventArgs e)
        {
            string insert;
            cmd.Connection = con;
            insert = "insert into employee(emp_name,emp_address,emp_position) values ('{0}','{1}','{2}') ";
            insert = insert.Replace("{0}",txtname.Text);
            insert = insert.Replace("{1}",txtaddress.Text);
            insert = insert.Replace("{2}",txtposition.Text);
            cmd.CommandText = insert;

            try
            {

                con.Open();
                cmd.ExecuteNonQuery();
                string msg = "alert(\"Employee Registered Success\")";
                ScriptManager.RegisterStartupScript(this, GetType(), "Serverscript", msg, true);
            }catch(SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally { con.Close(); }
        }

        protected void update_Click(object sender, EventArgs e)
        {

            string update;
            cmd.Connection = con;
            update = "update employee set emp_name= '{1}',emp_address='{2}',emp_position='{3}' where emp_no='{0}'";
            update = update.Replace("{1}", txtname.Text);
            update = update.Replace("{2}", txtaddress.Text);
            update = update.Replace("{3}", txtposition.Text);
            update = update.Replace("{0}", DropDownList1.Text);
            cmd.CommandText = update;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                string msg = "alert(\"Employee  Updated\")";
                ScriptManager.RegisterStartupScript(this, GetType(), "Serverscript", msg, true);
                txtname.Text = "";
                txtaddress.Text = "";
                txtposition.Text = "";
                DropDownList1.SelectedIndex = -1;
                add.Enabled = true;


            } catch (SqlException ex) 
            { Response.Write(ex.Message); }
            finally { con.Close(); }
        
        }

        protected void delete_Click(object sender, EventArgs e)
        {

            string delete;
            cmd.Connection = con;
            delete = "delete from employee where emp_no='{0}'";
            delete = delete.Replace("{0}", DropDownList1.Text);
            cmd.CommandText = delete;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                string msg ="alert(\"employee deleted\")";
                ScriptManager.RegisterStartupScript(this, GetType(), "Serverscript", msg, true);
                txtname.Text = "";
                txtaddress.Text = "";
                txtposition.Text = "";
                DropDownList1.SelectedIndex = -1;
                add.Enabled = true;

            }catch(SqlException ex)
            { Response.Write(ex.Message); } finally { con.Close(); }
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtaddress.Text = "";
            txtposition.Text = "";
           
        }
    }
}