    <%@ Page Title="Program Registeration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProgramRegisteration.aspx.cs" Inherits="Online_Examination_System.ProgramRegisteration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h4>Program Registeration Form</h4>
        <hr />
    </div>

    <div class="row">
        <div class="col-md-8">
            <section id="registrationForm">
                <div class="form-horizontal">



                    <%
                        if (IsSuccess)
                        {
                    %>
                    <div class="alert alert-success">
                        <strong>Success!</strong> <%= SuccessMessage %>
                    </div>
                    <% }     
                    %>

                    <% if (IsError)
                       { %>
                    <div id="lbl_error" class="alert alert-danger">
                        <strong>Error!</strong> <%=ErrorMessage %>
                    </div>
                    <%} %>



                  

                     <div class="form-group">

                        <asp:Label runat="server" AssociatedControlID="dd_students" CssClass="col-md-2 control-label">Student Name</asp:Label>
                        <div class="col-md-5">
                           <asp:DropDownList runat="server" ID ="dd_students"  CssClass="form-control" AutoPostBack="True">
                            
                            </asp:DropDownList>
                        </div>

                    </div>

                   

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ddl_program" CssClass="col-md-2 control-label">Program</asp:Label>
                        <div class="col-md-5">


                            <asp:DropDownList runat="server" ID="ddl_program" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddl_program"
                                CssClass="text-danger" ErrorMessage="The Program is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="btn_save" name="btn_save" runat="server" OnClick="btn_save_Click" Text="Save" CssClass="btn btn-default" />
                            
                        </div>
                    </div>

                </div>
            </section>
        </div>

        <div class="col-md-4">
            <section id="reg_form_gv">
               
                <div> 

                    <asp:GridView ID="gv_regProgram" CssClass="table table-striped" runat="server" 
                    AllowPaging="True" BorderStyle="None"
                    AllowSorting="True" 
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
