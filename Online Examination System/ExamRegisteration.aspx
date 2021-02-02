<%@ Page Title="Course Registeration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExamRegisteration.aspx.cs" Inherits="Online_Examination_System.CourseRegisteration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
          <h4>Exam Registeration Form</h4>
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
                         <asp:Label runat="server" AssociatedControlID="dd_users" CssClass="col-md-2 control-label">Student Name</asp:Label>
                         <div class="col-md-5">
                             <asp:DropDownList runat="server" ID ="dd_users"  OnSelectedIndexChanged="dd_users_SelectedIndexChanged"  CssClass="form-control" AutoPostBack="True">
                            
                              </asp:DropDownList>
                          </div>
                     
                     </div>

                    <div class="form-group">

                        <asp:Label runat="server" AssociatedControlID="dd_program" CssClass="col-md-2 control-label">Program</asp:Label>
                        <div class="col-md-5">
                           <asp:DropDownList runat="server" ID ="dd_program"  OnSelectedIndexChanged="dd_program_SelectedIndexChanged"  CssClass="form-control" AutoPostBack="True">
                            
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
                         <asp:Label runat="server" AssociatedControlID="dd_course" CssClass="col-md-2 control-label">Course</asp:Label>                       
                        <div class="col-md-5">
                           

                         <asp:DropDownList runat="server" ID ="dd_course"   CssClass="form-control" AutoPostBack="True">
                            
                            </asp:DropDownList>
                           
                        </div>
                    </div>


                      <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="lbl_reg_date"  CssClass="col-md-2 control-label">Registeration Date</asp:Label>
                         <asp:Label ID="lbl_reg_date" runat="server"  CssClass="col-md-4 control-label"></asp:Label>
                      </div>

                     <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="lbl_exp_date"  CssClass="col-md-2 control-label">Expiration Date</asp:Label>
                         <asp:Label ID="lbl_exp_date" runat="server"  CssClass="col-md-4 control-label"></asp:Label>
                      </div>

                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="dd_course" CssClass="col-md-2 control-label"></asp:Label>                       
                      <asp:Button ID="btn_save" name="btn_save" runat="server" OnClick="btn_save_Click" Text="Save" CssClass="btn btn-default" />
                        
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
