<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExamSetup.aspx.cs" Inherits="Online_Examination_System.ExamSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    

<div class="row">
        <div class="col-md-8">
            <section id="registrationForm">
                <div class="form-horizontal">
           
                    <h4>Exam Setup</h4>
                    <hr />

                       <%
                            if (IsSuccess)
                            {
                        %>
                        <div class="alert alert-success">
                            <strong>Success!</strong> User Successfully Created
                        </div>
                        <% }     
                        %>

                        <% if(IsError){ %>
                       <div id="lbl_error" class="alert alert-danger">
                           <strong>Error</strong><%=ErrorMessage %>
                        </div>
                        <%} %>
                    
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_exam_id" CssClass="col-md-2 control-label">Exam ID</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_exam_id" runat="server" Enabled="false" ID="txt_exam_id" CssClass="form-control" />
                          

                        </div>
                    </div>
                         <asp:Label runat="server" AssociatedControlID="txt_course_id" CssClass="col-md-2 control-label"> Course ID</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_course_id" runat="server" Enabled="false" ID="txt_course_id" CssClass="form-control" />
                          

                        </div>
                    </div>
                                    
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_exam_name" CssClass="col-md-2 control-label">Exam Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_exam_name" runat="server" ID="txt_exam_name" CssClass="form-control" />
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_exam_name"
                                CssClass="text-danger" ErrorMessage="The Exam Name field is required." />

                        </div>
                    </div>
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="txt_exam_details" CssClass="col-md-2 control-label">Exam Details</asp:Label>                       
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txt_exam_details" CssClass="form-control" />
                           
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="txt_exam_date" CssClass="col-md-2 control-label">Exam Date</asp:Label>                       
                        <div class="col-md-10">
                            <asp:Calendar ID="Calendar1" runat="server" CssClass="cal cal-default"></asp:Calendar>
                        </div>
                    </div>
              
                    
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="btn_save" name="btn_save" runat="server" OnClick="Save" Text="Save" CssClass="btn btn-default" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="btn_delete" name="btn_delete" runat="server" OnClick="delete" Text="Delete" CssClass="btn btn-default" />
                        </div>
                    </div>
                    </div>
               </section>
        </div>
        <div class="col-md-4">
            <section id="reg_form_gv">
               
                <div> 

                    <asp:GridView ID="gv_exam" CssClass="table table-striped" runat="server" 
                    AllowPaging="True" BorderStyle="None"
                    onpageindexchanging="gv_exam_PageIndexChanging" AllowSorting="True" 
                    onsorting="gv_exam_Sorting" 
                    BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                    <Columns>
                    <asp:HyperLinkField  DataTextField="ID" Text="EDIT"
                     HeaderText="Edit Item" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="items.aspx?acttype=edit&itmid={0}" />

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
