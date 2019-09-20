using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace task8
{
    public partial class databaseApp : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("check1");

            GridView2.Visible = false;
        }

        //protected void TextName_TextChanged(object sender, EventArgs e)
        //{
            //DataView dv = new DataView(dt);
            //dv.RowFilter = string.Format("Name like '%{0}%'", TextName.Text);
            //GridView1.DataSource = dv;
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True");
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into Employee(Id, Name, Role, MemberSince, Email) VALUES('" + TextId.Text + "','" + TextName.Text + "','" + TextRole.Text + "','" + TextMember.Text + "','" + TextEmail.Text + "')", con);
                SqlDataReader sqlr = cmd.ExecuteReader();

                //Console.WriteLine("check2");

                Response.Redirect("databaseApp.aspx");
                con.Close();
            }
            catch (Exception ex)
            {

                Label6.Text = "ERROR MSG: \r\n" + ex.Message;

                
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True");
                con.Open();

                

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("select * from Employee where name like '%" + TextBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                    GridView2.Visible = true;
                }


                else
                {
                    GridView2.Visible = false;
                    
                    Label7.Text = "not available in the record";

                }

                
                


                

                
                //con.Close();
            }
            catch (Exception ex)
            {

                Label6.Text = "ERROR MSG: \r\n" + ex.Message;


            }
        }



    }
}