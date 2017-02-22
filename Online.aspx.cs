using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Online : System.Web.UI.Page
{
    int tolQusn = 4;


    static float Marks = 0.0f, Attam = 0.0f, Uattam = 0.0f, currect = 0.0f, Wrong = 0.0f;



    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        SqlConnection bcs = new SqlConnection();
        bcs.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = bcs;
        cmd.CommandText = "Select * from ExamQusn1";
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(ds);
        bcs.Close();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string Qus11 = ds.Tables[0].Rows[i]["Qus"].ToString();     
             Call(Qus11);
        }
    }




    private void Call(string Qus11)
    {
         string Qus1 = rbtLstRating.SelectedValue;
        string Qus2 = RadioButtonList1.SelectedValue;
        string Qus3 = RadioButtonList2.SelectedValue;
        string Qus4 = RadioButtonList3.SelectedValue;

        string Ans1 = "By reference";
        string Ans2 = "TestFixtureAttribute";
        string Ans3 = "No";
        string Ans4 = "Deletes it from the memory";

        if (Qus11 == "In C#, by default structs are passed how?")
        {
            if (string.IsNullOrEmpty(Convert.ToString(Qus1)))
            {
                Uattam = Uattam + 1;
            }
            else
            {
                if (Qus1 == Ans1)
                {
                    Label1.ForeColor = System.Drawing.Color.Blue;
                    Label1.Text = "Your Ans Is Corrct";
                   
                    currect = currect + 1;
                }
                else
                {
                    Label1.ForeColor = System.Drawing.Color.Blue;
                    Label1.Text = "Your Ans Is Wrong";
                    Wrong = Wrong + 1;         
                }
                Attam = Attam + 1;
            }          
        }
        else
        {        
        }

        if (Qus11 == "IN The NUnit test FramWork")
        {
            if (string.IsNullOrEmpty(Convert.ToString(Qus2)))
            {
                Uattam = Uattam + 1;
            }
            else
            {
                if (Qus2 == Ans2)
                {
                    Label2.ForeColor = System.Drawing.Color.Blue;
                    Label2.Text = "Your Ans Is Corrct";

                    currect = currect + 1;
                }
                else
                {
                    Label2.ForeColor = System.Drawing.Color.Blue;
                    Label2.Text = "Your Ans Is Wrong";
                    Wrong = Wrong + 1;
                }
                Attam = Attam + 1;
            }
        }
        else
        {
        }

        if (Qus11 == "Is Possible to store multiple data type in system.Arry?")
        {
            if (string.IsNullOrEmpty(Convert.ToString(Qus3)))
            {
                Uattam = Uattam + 1;
            }
            else
            {
                if (Qus3 == Ans3)
                {
                    Label3.ForeColor = System.Drawing.Color.Blue;
                    Label3.Text = "Your Ans Is Corrct";

                    currect = currect + 1;
                }
                else
                {
                    Label3.ForeColor = System.Drawing.Color.Blue;
                    Label3.Text = "Your Ans Is Wrong";
                    Wrong = Wrong + 1;
                }
                Attam = Attam + 1;
            }
        }
        else
        {
        }
        if (Qus11 == "What Dose Dispose Method do with Connection Object")
        {
            if (string.IsNullOrEmpty(Convert.ToString(Qus4)))
            {
                Uattam = Uattam + 1;
            }
            else
            {
                if (Qus4 == Ans4)
                {
                    Label4.ForeColor = System.Drawing.Color.Blue;
                    Label4.Text = "Your Ans Is Corrct";

                    currect = currect + 1;
                }
                else
                {
                    Label4.ForeColor = System.Drawing.Color.Blue;
                    Label4.Text = "Your Ans Is Wrong";
                    Wrong = Wrong + 1;
                }
                Attam = Attam + 1;
            }
        }
        else
        {
        }

        Marks = ((float)(float) (currect) / (tolQusn) * 100);

        if (Marks > 50)
        {
            Label10.Text = "Pass =" + Marks;
        }
        else
        {
            Label10.Text = "Failed =" + Marks;
        }

                
            
        Label6.Text = "UmAttem Qus =" + Uattam;
        Label7.Text = "Arttem Qus =" + Attam;
        Label8.Text = "Currect Qus =" + currect;
        Label9.Text = "Wrong Qus =" + Wrong;
        
    }

   
}

    
