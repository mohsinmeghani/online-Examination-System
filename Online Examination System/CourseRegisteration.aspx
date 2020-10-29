<%@ Page Title="Course Registeration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseRegisteration.aspx.cs" Inherits="Online_Examination_System.CourseRegisteration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
          <h4>Course Registeration Form</h4>
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

                        <asp:Label runat="server" AssociatedControlID="lbl_UserID" CssClass="col-md-2 control-label">Student-ID</asp:Label>
                        <div class="col-md-10">
                            <asp:Label Name="lbl_UserID" Enabled="false"  runat="server" Text="SM-00929" ID="lbl_UserID" CssClass="col-md-5 form-control-static" />
                        </div>

                    </div>

                     <div class="form-group">

                        <asp:Label runat="server" AssociatedControlID="lbl_Name" CssClass="col-md-2 control-label">Student Name</asp:Label>
                        <div class="col-md-10">
                            <asp:Label Name="lbl_Name" Enabled="false"  runat="server" Text="Ali Karim" ID="lbl_Name" CssClass="col-md-5 form-control-static" />
                        </div>

                    </div>

                    <div class="form-group">

                        <asp:Label runat="server" AssociatedControlID="lbl_program" CssClass="col-md-2 control-label">Program</asp:Label>
                        <div class="col-md-10">
                            <asp:Label Name="lbl_program" Enabled="false"  runat="server" Text="-" ID="lbl_program" CssClass="col-md-5 form-control-static" />
                        </div>

                    </div>

                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="ddl_CourseCategory" CssClass="col-md-2 control-label">Category</asp:Label>                       
                        <div class="col-md-5">
                           

                         <asp:DropDownList runat="server" ID ="ddl_CourseCategory"  OnSelectedIndexChanged="ddl_CourseCategory_SelectedIndexChanged"  CssClass="form-control" AutoPostBack="True">
                            
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddl_CourseCategory"
                                CssClass="text-danger" ErrorMessage="The Course Category is required." />
                        </div>
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
