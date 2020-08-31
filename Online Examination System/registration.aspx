﻿<%@ Page Title="User Registeration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="Online_Examination_System.registration" %>

<asp:Content ID="content2" ContentPlaceHolderID="HeadContent" runat="server">
    
    
<script type = "text/javascript">
    function checkUsername() {
      
        $.ajax({
            type: "POST",
            url: "registration.aspx/GetUserName",
            data: '{u: "' + $("#<%=txt_username.ClientID%>")[0].value + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        }
    });
}
function OnSuccess(response) {
    //alert(response.d);
    $("#lbl_error").text("UserName Already Exist");
}
</script>

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-8">
            <section id="registrationForm">
                <div class="form-horizontal">
           
                    <h4>User Registration Form</h4>
                    
                   
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

                        <asp:Label runat="server" AssociatedControlID="txt_id" CssClass="col-md-2 control-label">ID</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_ID" Enabled="false"  runat="server" ID="txt_ID" CssClass="form-control" />
                        </div>

                    </div>

                    <div class="form-group">
                      
                        <asp:Label runat="server" AssociatedControlID="txt_username" CssClass="col-md-2 control-label">Username</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_username" AutoPostBack="true" runat="server" ID="txt_username" CssClass="form-control" OnTextChanged="txt_username_TextChanged" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_username"
                                CssClass="text-danger" ErrorMessage="The User Name field is required." />
                            <asp:CustomValidator ID="validator_username" runat="server" ValidateEmptyText="false" ControlToValidate="txt_username" CssClass="text-danger" OnServerValidate="validator_username_ServerValidate" ErrorMessage="User Name Already Exist"></asp:CustomValidator>
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
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="txt_contact" CssClass="col-md-2 control-label">Contact</asp:Label>                       
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txt_contact" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_contact"
                                CssClass="text-danger" ErrorMessage="The Contact field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="txt_address" CssClass="col-md-2 control-label">Address</asp:Label>                       
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txt_address" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_address"
                                CssClass="text-danger" ErrorMessage="The Contact field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="txt_email" CssClass="col-md-2 control-label">Email</asp:Label>                       
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_email" runat="server" ID="txt_email" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_email"
                                CssClass="text-danger" ErrorMessage="The Email is required." />
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="ddl_gender" CssClass="col-md-2 control-label">Gender</asp:Label>                       
                        <div class="col-md-5">
                         <asp:DropDownList runat="server" ID ="ddl_gender" runat="server" CssClass="form-control" >
                             <asp:ListItem Value="">Please Select</asp:ListItem>  
                             <asp:ListItem>Male</asp:ListItem>
                             <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddl_gender"
                                CssClass="text-danger" ErrorMessage="The Gender is required." />
                        </div>
                    </div>
              
                    
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txt_password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txt_password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_password"
                                CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txt_confirmpassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
                        <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txt_confirmpassword" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_confirmpassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                <asp:CompareValidator runat="server" ControlToCompare="txt_password" ControlToValidate="txt_confirmpassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="btn_register" name="btn_register" runat="server" OnClick="Register" Text="Register" CssClass="btn btn-default" />
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
