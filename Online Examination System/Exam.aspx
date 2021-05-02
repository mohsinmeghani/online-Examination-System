<%@ Page Title="Exam" Language="C#" MasterPageFile="~/Exam.Master" AutoEventWireup="true" CodeBehind="Exam.aspx.cs" Inherits="Online_Examination_System.Exam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style>
        #question {
            margin-top: 50px;
            min-height: 100%;
            font-stretch: inherit;
            font-size: large;
            border: 1px solid #777777;
        }

        .radio
        {
            margin-top:20px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    




 
    


    <div class="row">
        <div class="col-md-5">
            <label>Time:</label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                       <%-- <label id="demo">00:00:00</label>--%>
                      <asp:Label ID="lbl_time" runat="server" Text="00:00:00"></asp:Label>
                        <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="1000"></asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
            
            
             

        </div>
    </div>

    <div id="question" class="row">
        <div class="col-md-12">
            <section id="registrationForm">
                <div class="form-horizontal">

                    <span id="lbl_qno" runat="server"></span><asp:Label ID="lbl_question" runat="server" CssClass="control-label" >What is the Capital of Pakistan</asp:Label>

                    <div id="div_options" runat="server">
                        <asp:Panel ID="panel" runat="server">


                        </asp:Panel>

                        

                    </div>

                </div>
            </section>
        </div>
    </div>

    <div class="row" style="margin-top:25px;text-align:right">
        <div class="col-md-12">
            <asp:Button ID="btn_first" name="btn_prev" OnClick="btn_first_Click" runat="server" Text="First" CssClass="btn btn-primary"   />
             <asp:Button ID="btn_prev" name="btn_prev" OnClick="btn_prev_Click" runat="server" Text="Previous" CssClass="btn btn-primary"   />
             <asp:Button ID="btn_next" name="btn_next" OnClick="btn_next_Click"  runat="server" Text="Next" CssClass="btn btn-primary"   />
             <asp:Button ID="btn_last" name="btn_last" OnClick="btn_last_Click"  runat="server" Text="Last" CssClass="btn btn-primary"   />
             
        </div>
    </div>

    <div class="row" style="margin-top: 25px; text-align: right">
        <div class="col-md-12">
             <asp:Button ID="btn_submit" name="btn_submit" OnClick="btn_submit_Click" runat="server" Text="Submit" CssClass="btn btn-success"   />

        </div>
    </div>
   
</asp:Content>
