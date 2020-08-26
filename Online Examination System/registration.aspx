<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="Online_Examination_System.registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-8">
            <section id="registrationForm">
                <div class="form-horizontal">
                    
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_username" CssClass="col-md-2 control-label">Username</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_username" runat="server" ID="txt_username" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_username"
                                CssClass="text-danger" ErrorMessage="The username field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_firstname" CssClass="col-md-2 control-label">First Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_firstname" runat="server" ID="txt_firstname" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_firstname"
                                CssClass="text-danger" ErrorMessage="The First Name field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="txt_lastname" CssClass="col-md-2 control-label">Last Name</asp:Label>                       
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_username" runat="server" ID="txt_lastname" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_lastname"
                                CssClass="text-danger" ErrorMessage="The Last Name field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="txt_contact" CssClass="col-md-2 control-label">Contact</asp:Label>                       
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_contact" runat="server" ID="txt_contact" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_contact"
                                CssClass="text-danger" ErrorMessage="The Contact field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="txt_email" CssClass="col-md-2 control-label">Email</asp:Label>                       
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_email" runat="server" ID="txt_email" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_email"
                                CssClass="text-danger" ErrorMessage="The Last Email is required." />
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="ddl_gender" CssClass="col-md-2 control-label">Gender</asp:Label>                       
                        <div class="col-md-5">
                         <asp:DropDownList runat="server" ID ="ddl_gender" runat="server" CssClass="form-control" >
                             <asp:ListItem>Male</asp:ListItem>
                             <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddl_gender"
                                CssClass="text-danger" ErrorMessage="The Last gender is required." />
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txt_password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox name="txt_password" runat="server" ID="txt_password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                        </div>
                    <div class="form-group">
                   
                         <asp:Label runat="server" AssociatedControlID="txt_confirmpassword" CssClass="col-md-2 control-label"> Confirm Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox name="txt_confirmpassword" runat="server" ID="txt_confirmpassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_confirmpassword" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                        
                    </div>

               </section>
        </div>
</div>
</asp:Content>
