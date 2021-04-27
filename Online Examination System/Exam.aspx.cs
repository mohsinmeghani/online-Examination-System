using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data;

namespace Online_Examination_System
{
    public partial class Exam : System.Web.UI.Page
    {
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                Generate_DT();
                InitCounter();
                First();
            }
            else
            {
                var count = Convert.ToInt32( ViewState["counter"]);
                Display(count);
            }


        }

        protected void btn_prev_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            Previous();
            

        }


        private void First()
        {
            Display(1);
        }

        private void Last()
        {
            var dt = (DataTable)ViewState["dt"];
            var last = dt.Rows.Count -1;
            Display(last);


        }

        private void Next()
        {
            var counter = Convert.ToInt32(ViewState["counter"]);
            var total = Convert.ToInt32(ViewState["total"]);
            var n = counter;

            if (counter < total)
            {
                n = counter + 1;
                ViewState["counter"] = n;
            }

            Display(n);

        }
        private void Previous()
        {
            var counter = Convert.ToInt32(ViewState["counter"]);
            var n = counter;
            if (counter > 1)
            {
                n = counter - 1;
                ViewState["counter"] = n;
            }

            Display(n);


        }

        private void InitCounter()
        {
            ViewState["counter"] = 1;
            var dt = (DataTable)ViewState["dt"];
            ViewState["total"] = dt.Rows.Count;
        }



        private void Display(int counter)
        {
            var count =  ViewState["counter"];
            var dt = (DataTable)ViewState["dt"];
            var qtxt = dt.Rows[counter - 1]["Text"];
            lbl_qno.InnerText = "Q."+count.ToString()+":";
            lbl_question.Text = qtxt.ToString();
            GenerateOptions(counter);
        }
       
        private void GenerateOptions(int counter)
        {
            var dt = (DataTable)ViewState["dt"];
            var  opt_str = dt.Rows[counter - 1]["Options"];
            var  marked = dt.Rows[counter - 1]["Marked"].ToString();
            var options = new OES_BAL.Option(opt_str.ToString());
            
            RadioButton rd1 = new RadioButton();
            rd1.CssClass = "radio";
            rd1.ID = "rad_1";
            rd1.GroupName = "opts";
            rd1.Text = options.A;
            rd1.Checked = marked == "A" ? true : false;
            rd1.CheckedChanged +=  new EventHandler(Rd_CheckedChanged);
            rd1.AutoPostBack = true;
            panel.Controls.Add(rd1);

            RadioButton rd2 = new RadioButton();
            rd2.CssClass = "radio";
            rd2.ID = "rad_2";
            rd2.GroupName = "opts";
            rd2.Text = options.B;
            rd2.Checked = marked == "B" ? true : false;
            rd2.CheckedChanged += new EventHandler(Rd_CheckedChanged);
            rd2.AutoPostBack = true;
            panel.Controls.Add(rd2);

            RadioButton rd3 = new RadioButton();
            rd3.CssClass = "radio";
            rd3.ID = "rad_3";
            rd3.GroupName = "opts";
            rd3.Text = options.C;
            rd3.Checked = marked == "C" ? true : false;
            rd3.CheckedChanged += new EventHandler(Rd_CheckedChanged);
            rd3.AutoPostBack = true;
            panel.Controls.Add(rd3);

            RadioButton rd4 = new RadioButton();
            rd4.CssClass = "radio";
            rd4.ID = "rad_4";
            rd4.GroupName = "opts";
            rd4.Text = options.D;
            rd4.Checked = marked == "D" ? true : false;
            rd4.CheckedChanged += new EventHandler(Rd_CheckedChanged);
            rd4.AutoPostBack = true;
            panel.Controls.Add(rd4);




            // var html = RenderControlToHtml(rd1) + RenderControlToHtml(rd2) + RenderControlToHtml(rd3) + RenderControlToHtml(rd4);



            // div_options.InnerHtml = html;

        }

        private void Rd_CheckedChanged(object sender, EventArgs e)
        {
            var rd = (RadioButton)sender;
            var val = "";
            if (rd.Checked)
            {
                if (rd.ID=="rad_1")
                {
                    val = "A";
                }
                else if(rd.ID=="rad_2")
                {
                    val = "B";
                }
                else if (rd.ID == "rad_3")
                {
                    val = "C";
                }
                else if (rd.ID == "rad_4")
                {
                    val = "D";
                }

            }
            var dt = (DataTable)ViewState["dt"];
            var currentRow = Convert.ToInt32( ViewState["counter"]);
            dt.Rows[currentRow -1]["Marked"] = val;
            ViewState["dt"] = dt;
        }

        private string RenderControlToHtml(Control ControlToRender)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stWriter = new System.IO.StringWriter(sb);
            System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(stWriter);
            ControlToRender.RenderControl(htmlWriter);
            return sb.ToString();
        }

        private void Generate_DT()
        {
            var dt = new DataTable();

            dt.Columns.Add("ID");
            dt.Columns.Add("Text");
            dt.Columns.Add("Options");
            dt.Columns.Add("Marked");

            var exam = (OES_BAL.Exam)Session["exam"];
            var questions = exam.GetQuestions();

            foreach (var q in questions)
            {
              var dr = dt.NewRow();
                dr["ID"] = q.ID;
                dr["Text"] = q.QuestionText;
                dr["Options"] = q.Option.GetOptionJSON();
                dr["Marked"] = "0";

                dt.Rows.Add(dr);
                
            }

            ViewState["dt"] = dt;
        }

        protected void btn_next_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            Next();
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            SubmitExam();
            Response.Redirect("ExamCenter.aspx");
        }

        private void SubmitExam()
        {
            var std_answer = new OES_BAL.StudentAnswers();
            var exam = (OES_BAL.Exam)Session["exam"];
            var std = (OES_BAL.Student)Session["std"];
            var dt_answers = std_answer.GetDataTable();

            exam.MarkCompleted();

            std_answer.Exam = exam;
            std_answer.Student = std;

            var dt = (DataTable)ViewState["dt"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
               var dr =  dt_answers.NewRow();
                dr["QID"] = dt.Rows[i]["ID"];
                dr["Answer"] = dt.Rows[i]["Marked"];
                dt_answers.Rows.Add(dr);
            }

            std_answer.MarkedAnswers =dt_answers;
            std_answer.Add();

            exam.GenerateResult(dt_answers);
        }
    }
}