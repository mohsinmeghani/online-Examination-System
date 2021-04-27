    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report_Simple.aspx.cs" Inherits="Online_Examination_System.Report_Simple" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="row">

            <div class="col-sm-12">


                <div class="col-sm-3" style="text-align:center">
                    <img src="img/logo2.png" style="width:15%;height:15%" />
                </div>
                <div class="col-sm-9" style="text-align:center">
                    <h2>Newports Institute of Communication & Economics</h2>
                    <h4><%= Title %></h4>
                </div>
            </div>


        </div>


        <div class="row" style="top:25px">
            <div class="col-sm-6" style="top:50px">

                <table id="table_master" runat="server" class="table table-condensed table-bordered">

                </table>

            </div>
        </div>


        
        <div class="row" style="top:25px">
            <div class="col-sm-12" style="top:50px">

                <table id="table_detail" runat="server" class="table table-condensed table-bordered">

                </table>

            </div>
        </div>

        <div>
            
        </div>
    </form>
</body>
</html>
