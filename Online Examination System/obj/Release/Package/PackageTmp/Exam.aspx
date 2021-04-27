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
    




    <script>

       // alert(decodeURIComponent(document.cookie));


        function setCookie(cname, cvalue, hours) {
            var d = new Date(); 
            d.setTime(d.getTime() + (hours * 60 * 60 * 1000));
            var expires = "expires=" + d.toGMTString();
            document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
        }

        function getCookie(cname) {
            var name = cname + "=";
            var decodedCookie = decodeURIComponent(document.cookie);
            var ca = decodedCookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') {
                    c = c.substring(1);
                }
                if (c.indexOf(name) == 0) {
                    return c.substring(name.length, c.length);
                }
            }
            return "";
        }

        function checkCookie() {
            var val = getCookie("deadline");
            if (val != "") {
                return val;
            } else {
                var d = new Date().getTime();
                var deadline = new Date();
                deadline.setHours(deadline.getHours() + 1.5);
                if (deadline != "" && deadline != null) {
                    setCookie("deadline", deadline, 1);
                    return deadline;
                }
            }
        }


        var deadline = Date.parse( checkCookie());

            var x = setInterval(function () {

                var now = new Date().getTime();

                var diff = deadline - now;
                var hours = Math.floor((diff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                var minutes = Math.floor((diff % (1000 * 60 * 60)) / (1000 * 60));
                var seconds = Math.floor((diff % (1000 * 60)) / 1000);
                document.getElementById("demo").innerHTML = hours + ":" + minutes + ":" + seconds;

                if (diff < 0) {
                    clearInterval(x);
                    document.getElementById("demo").innerHTML = "EXPIRED";
                    document.getElementById("<%= btn_submit.ClientID %>").click();
                }


            }, 1000);
            
            //document.getElementById("demo1").innerHTML = deadline.toLocaleTimeString();
        
    </script>
   


    <div class="row">
        <div class="col-md-5">
            <label>Time:</label>
            <label id="demo">00:00:00</label>
            
             

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
             <asp:Button ID="btn_prev" name="btn_prev" OnClick="btn_prev_Click" runat="server" Text="Previous" CssClass="btn btn-primary"   />
             <asp:Button ID="btn_next" name="btn_next" OnClick="btn_next_Click"  runat="server" Text="Next" CssClass="btn btn-primary"   />
             
        </div>
    </div>

    <div class="row" style="margin-top: 25px; text-align: right">
        <div class="col-md-12">
             <asp:Button ID="btn_submit" name="btn_submit" OnClick="btn_submit_Click" runat="server" Text="Submit" CssClass="btn btn-success"   />

        </div>
    </div>
   
</asp:Content>
