<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Program_Registration.aspx.cs" Inherits="Online_Examination_System.Program_Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">
        <div class="col-md-8">
            <section id="registrationForm">
                <div class="form-horizontal">
           
                    <h4>User's Program Registration Form</h4>
                    <hr />

                    
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_userid" CssClass="col-md-2 control-label">User ID</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_userid" runat="server" ID="txt_userid" CssClass="form-control" />
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_userid"
                                CssClass="text-danger" ErrorMessage="The User Name field is required." />

                        </div>
                    </div>
                                    
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_username" CssClass="col-md-2 control-label">Username</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_username" runat="server" ID="txt_username" CssClass="form-control" />
                           <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_username"
                                CssClass="text-danger" ErrorMessage="The User Name field is required." />

                        </div>
                    </div>
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_firstname" CssClass="col-md-2 control-label">First Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox name="txt_firstname" runat="server" ID="txt_firstname" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_firstname"
                                CssClass="text-danger" ErrorMessage="The First Name field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="txt_lastname" CssClass="col-md-2 control-label">Last Name</asp:Label>                       
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txt_lastname" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_lastname"
                                CssClass="text-danger" ErrorMessage="The Last Name field is required." />
                        </div>
                    </div>
                    
                    <%-- Drop down menu for the Program List  --%>
                    
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="ddl_program" CssClass="col-md-2 control-label">Program</asp:Label>                       
                        <div class="col-md-5">
                         <asp:DropDownList runat="server" ID ="ddl_program" runat="server" CssClass="form-control" >
                             <asp:ListItem Value="">Please Select</asp:ListItem>  
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddl_program"
                                CssClass="text-danger" ErrorMessage="The Program is required." />
                        </div>
                    </div>
              
                    
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button name="btn_register" runat="server" OnClick="Register" Text="Register" CssClass="btn btn-default" />
                        </div>
                        </div>
                    </div>
               </section>
        </div>
        <div class="col-md-4">
            <section id="reg_form_gv">
               
                <div> 

                    <asp:GridView ID="gv_items" CssClass="table table-striped" runat="server" 
                    AllowPaging="True" BorderStyle="None"
                    onpageindexchanged="gv_items_PageIndexChanged" 
                    onpageindexchanging="gv_items_PageIndexChanging" AllowSorting="True" 
                    onsorting="gv_items_Sorting" AutoGenerateEditButton="false" 
                    EnableModelValidation="True" onrowcancelingedit="gv_items_RowCancelingEdit" 
                    onrowediting="gv_items_RowEditing" onrowupdating="gv_items_RowUpdating" 
                    onselectedindexchanged="gv_items_SelectedIndexChanged">
                    <Columns>
                    <asp:HyperLinkField  DataTextField="ID" Text="EDIT"
                     HeaderText="Edit Item" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="items.aspx?acttype=edit&itmid={0}" />

                    </Columns>
                </asp:GridView>
              
                    </div>
    
            </section>
        </div>
</div>
</asp:Content>
