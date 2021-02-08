<%@ Page Title="Exam Center" Language="C#" MasterPageFile="~/Exam.Master" AutoEventWireup="true" CodeBehind="ExamCenter.aspx.cs" Inherits="Online_Examination_System.ExamCenter" %>

<asp:Content ID="head1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language="javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    
   
    
    <div class="row">

        <h4>Exam Center</h4>

        <div class="col-md-4" style="border:1px double grey">

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="lbl_user" CssClass="col-md-2 control-label">Name:</asp:Label>
                <asp:Label ID="lbl_user" runat="server" Text="Label"></asp:Label>
            </div>

             <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="lbl_username" CssClass="col-md-3 control-label">UserName:</asp:Label>
                <asp:Label ID="lbl_username" runat="server" Text="Label"></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="lbl_email" CssClass="col-md-2 control-label">Email:</asp:Label>
                <asp:Label ID="lbl_email" runat="server" Text="Label"></asp:Label>
            </div>
        </div>

        <div class="col-md-8">
            <section id="registrationForm">
                <div class="form-horizontal">

                    


                     <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="dd_exam" CssClass="col-md-2 control-label">Exam List</asp:Label>                       
                        <div class="col-md-6">
                           <asp:DropDownList ID="dd_exam" runat="server" CssClass="form-control"></asp:DropDownList>
                         
                        </div>
                           <asp:Button name="btn_start" runat="server" Text="Start" CssClass="btn btn-success" />
                    </div>
                </div>
            </section>
        </div>
    </div>

    
 

        
       

</asp:Content>
