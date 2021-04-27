<%@ Page Title="Exam Result" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExamResult.aspx.cs" Inherits="Online_Examination_System.ExamResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
          <h4>Exam Result</h4>
         <hr />
    </div>

    <div class="row">
        <div class="col-md-8">
            <section id="registrationForm">
                <div class="form-horizontal">

                  

                    <%
                            if (IsSuccess)
                            {
                        %>
                        <div class="alert alert-success">
                            <strong>Success!</strong> <%= SuccessMessage %>
                        </div>
                        <% }     
                        %>

                        <% if(IsError){ %>
                       <div id="lbl_error" class="alert alert-danger">
                           <strong>Error!</strong> <%=ErrorMessage %>
                        </div>
                        <%} %>
                    
                  

                    

                     <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="dd_students" CssClass="col-md-2 control-label">Student Name</asp:Label>
                         <div class="col-md-5">
                             <asp:DropDownList runat="server" ID ="dd_students"  OnSelectedIndexChanged="dd_students_SelectedIndexChanged"  CssClass="form-control" AutoPostBack="True">
                            
                              </asp:DropDownList>
                          </div>
                     
                     </div>

                   
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="ddl_CourseCategory" CssClass="col-md-2 control-label">Category</asp:Label>                       
                        <div class="col-md-5">
                           

                         <asp:DropDownList runat="server" ID ="ddl_CourseCategory"  OnSelectedIndexChanged="ddl_CourseCategory_SelectedIndexChanged"  CssClass="form-control" AutoPostBack="True">
                            
                            </asp:DropDownList>
                            
                        </div>
                    </div>

                     <div class="form-group">

                        <asp:Label runat="server" AssociatedControlID="dd_exam" CssClass="col-md-2 control-label">Exam</asp:Label>
                        <div class="col-md-5">
                           <asp:DropDownList runat="server" ID ="dd_exam"  OnSelectedIndexChanged="dd_program_SelectedIndexChanged"  CssClass="form-control" >
                            
                            </asp:DropDownList>
                        </div>

                    </div>

                    <div class="form-group">

                        <asp:Label runat="server" AssociatedControlID="dd_report" CssClass="col-md-2 control-label">Report</asp:Label>
                        <div class="col-md-5">
                           <asp:DropDownList runat="server" ID ="dd_report"   CssClass="form-control" >
                             <asp:ListItem Text="Indivisual Score Card" Value="IndivisualScore"></asp:ListItem>
                             <asp:ListItem Text="Student Card" Value="StudentCard"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>




                      

                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="btn_generate" CssClass="col-md-2 control-label"></asp:Label>                       
                      <asp:Button ID="btn_generate" name="btn_generate" runat="server" OnClick="btn_generate_Click" Text="Generate" CssClass="btn btn-default" />
                        
                    </div>

                   
                </div>
            </section>
        </div>

        <div class="col-md-4">
           <div class="container" id="div_courses" runat="server">
               
           </div>
        </div>
    </div>

</asp:Content>
