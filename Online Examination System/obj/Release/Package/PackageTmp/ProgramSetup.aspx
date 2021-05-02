<%@ Page Title="Program Setup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProgramSetup.aspx.cs" Inherits="Online_Examination_System.ProgramSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">
        <div class="col-md-8">
            <section id="registrationForm">
                <div class="form-horizontal">
           
                    <h4>Program Setup</h4>
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
                    
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_id" CssClass="col-md-2 control-label">ID</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_id" runat="server" Enabled="false" ID="txt_id" CssClass="form-control" />
                          

                        </div>
                    </div>
                                    
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_program_code" CssClass="col-md-2 control-label">Program Code</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_program_code" runat="server" ID="txt_program_code" CssClass="form-control" />
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_program_code"
                                CssClass="text-danger" ErrorMessage="The Program Code field is required." />

                        </div>
                    </div>
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_program_name" CssClass="col-md-2 control-label">Program Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox name="txt_program_name" runat="server" ID="txt_program_name" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_program_name"
                                CssClass="text-danger" ErrorMessage="The Program Name field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="txt_program_details" CssClass="col-md-2 control-label">Program Details</asp:Label>                       
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txt_program_details" CssClass="form-control" />
                           
                        </div>
                    </div>
              
                    
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="btn_save" name="btn_save" runat="server" OnClick="Save" Text="Save" CssClass="btn btn-default" />
                            <asp:Button ID="btn_refresh" name="btn_refresh" runat="server" OnClick="btn_refresh_Click" Text="Refresh" CssClass="btn btn-default" />
                            <asp:Button ID="btn_delete" name="btn_delete" runat="server" OnClick="btn_delete_Click" Text="Delete" CssClass="btn btn-danger" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            
                        </div>
                    </div>
                    </div>
               </section>
        </div>
        <div class="col-md-4">
            <section id="reg_form_gv">
               
                <div> 

                    <asp:GridView ID="gv_program" CssClass="table table-striped" runat="server" 
                    AllowPaging="True" BorderStyle="None"
                    onpageindexchanging="gv_program_PageIndexChanging" AllowSorting="True" 
                    onsorting="gv_program_Sorting" 
                    BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                    <Columns>
                    <asp:HyperLinkField  DataTextField="ID"   Text="EDIT"
                     HeaderText="Edit Item" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="ProgramSetup.aspx?acttype=edit&id={0}" />

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
