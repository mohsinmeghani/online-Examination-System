﻿<%@ Page Title="Course Setup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseSetup.aspx.cs" Inherits="Online_Examination_System.CourseRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div class="row">
        <div class="col-md-8">
            <section id="registrationForm">
                <div class="form-horizontal">
           
                    <h4>Course Setup</h4>
                    <hr />

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

                      <ul class="nav nav-tabs">
                        <li class="active"><a data-toggle="tab" href="#home">Master</a></li>
                        <li><a data-toggle="tab" href="#menu1">Credit Hours</a></li>

                      </ul>

                    <div class="tab-content">
                         <div id="home" class="tab-pane fade in active">
                    
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_id" CssClass="col-md-2 control-label">ID</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_id" runat="server" Enabled="false" ID="txt_id" CssClass="form-control" />
                          

                        </div>
                    </div>
                                    
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_course_code" CssClass="col-md-2 control-label">CourseCode</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_course_code" runat="server" ID="txt_course_code" CssClass="form-control" />
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_course_code"
                                CssClass="text-danger" ErrorMessage="The Course Code field is required." />

                        </div>
                    </div>
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_course_name" CssClass="col-md-2 control-label">Course Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox name="txt_course_name" runat="server" ID="txt_course_name" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_course_name"
                                CssClass="text-danger" ErrorMessage="The Course Name field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="txt_course_details" CssClass="col-md-2 control-label">Course Details</asp:Label>                       
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txt_course_details" CssClass="form-control" />
                           
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="ddl_program" CssClass="col-md-2 control-label">Program</asp:Label>                       
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddl_program"  runat="server"  CssClass="form-control"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddl_program"
                                CssClass="text-danger" ErrorMessage="The Program is required." />
                           </div>
                    </div>

                      <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="ddl_course_category" CssClass="col-md-2 control-label">Category</asp:Label>                       
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddl_course_category"  runat="server"  CssClass="form-control"></asp:DropDownList>
                        
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddl_course_category"
                                CssClass="text-danger" ErrorMessage="The Program is required." />
                           </div>
                    </div>

                      <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="ddl_parent_course" CssClass="col-md-2 control-label">Parent Course</asp:Label>                       
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddl_parent_course"  runat="server"  CssClass="form-control"></asp:DropDownList>
                        
                        
                           </div>
                    </div>
              
                  
                    
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            
                        </div>
                    </div>
                             </div>

                        <div id="menu1" class="tab-pane fade">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txt_chTheory" CssClass="col-md-2 control-label">Credit Hours - Theory</asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox runat="server" ID="txt_chTheory" CssClass="form-control" Text="0" />
                                    
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txt_chPractical" CssClass="col-md-2 control-label">Course Details</asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox runat="server" ID="txt_chPractical" CssClass="form-control" Text="0" />
                                   
                                </div>
                            </div>
                        </div>

                          
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="btn_save" name="btn_save" runat="server" OnClick="Save" Text="Save" CssClass="btn btn-default" />
                            <asp:Button ID="btn_refresh" name="btn_refresh" runat="server" OnClick="btn_refresh_Click" Text="Refresh" CssClass="btn btn-default" />
                            <asp:Button ID="btn_delete" name="btn_delete" runat="server" OnClick="btn_delete_Click" Text="Delete" CssClass="btn btn-danger" />
                        </div>
                    </div>


                        </div>

                    </div>
               </section>
        </div>
        <div class="col-md-4">
            <section id="reg_form_gv">
               
                <div> 

                    <asp:GridView ID="gv_course" CssClass="table table-striped" runat="server" 
                    AllowPaging="True" BorderStyle="None"
                    onpageindexchanging="gv_course_PageIndexChanging" AllowSorting="True" 
                    onsorting="gv_course_Sorting" 
                    BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                    <Columns>
                    <asp:HyperLinkField  DataTextField="ID" Text="EDIT"
                     HeaderText="Edit Item" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="CourseSetup.aspx?acttype=edit&id={0}" />

                    </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
              
                    </div>
    
            </section>
        </div>
</div>

</asp:Content>