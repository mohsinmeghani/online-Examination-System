<%@ Page Title="Question Setup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuestionSetup.aspx.cs" Inherits="Online_Examination_System.QuestionSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">
        <div class="col-md-8">
            <section id="registrationForm">
                <div class="form-horizontal">
           
                    <h4>Question Setup</h4>
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
                        <% } %>
                    
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_id" CssClass="col-md-2 control-label">ID</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_id" runat="server" Enabled="false" ID="txt_id" CssClass="form-control" />
                          

                        </div>
                    </div>

                       <div class="form-group">

                        <asp:Label runat="server" AssociatedControlID="dd_course" CssClass="col-md-2 control-label">Course</asp:Label>
                        <div class="col-md-5">
                           <asp:DropDownList runat="server" ID ="dd_course"  CssClass="form-control" AutoPostBack="True">
                            
                            </asp:DropDownList>
                        </div>

                    </div>
                                    
                    <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_questionText" CssClass="col-md-2 control-label">Question Text
                         </asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox Name="txt_questionText" runat="server" ID="txt_questionText" CssClass="form-control" />
                           
                        </div>
                    </div>
                    

                     <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_A" CssClass="col-md-2 control-label">A</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox name="txt_A" runat="server" ID="txt_A" CssClass="form-control" />
                            
               
                        </div>
                    </div>

                     <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_B" CssClass="col-md-2 control-label">B</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox name="txt_B" runat="server" ID="txt_B" CssClass="form-control" />
                            
               
                        </div>
                    </div>

                     <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_C" CssClass="col-md-2 control-label">C</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox name="txt_C" runat="server" ID="txt_C" CssClass="form-control" />
                            
               
                        </div>
                    </div>

                     <div class="form-group">
                        
                         <asp:Label runat="server" AssociatedControlID="txt_D" CssClass="col-md-2 control-label">D</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox name="txt_D" runat="server" ID="txt_D" CssClass="form-control" />
                            
               
                        </div>
                    </div>

                    <div class="form-group">
                         <asp:Label runat="server" AssociatedControlID="dd_answer" CssClass="col-md-2 control-label">Answer</asp:Label>                       
                        <div class="col-md-5"> 
                            <asp:DropDownList runat="server" ID ="dd_answer"  CssClass="form-control" AutoPostBack="True">
                                <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                <asp:ListItem Text="B" Value="B"></asp:ListItem>
                                <asp:ListItem Text="C" Value="C"></asp:ListItem>
                                <asp:ListItem Text="D" Value="D"></asp:ListItem>
                             </asp:DropDownList>
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
               
             

                    <asp:GridView ID="gv_questions" CssClass="table table-striped" runat="server" 
                    AllowPaging="True" BorderStyle="None"
                    onpageindexchanging="gv_questions_PageIndexChanging" AllowSorting="True" 
                    onsorting="gv_questions_Sorting" 
                    BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                    <Columns>
                    <asp:HyperLinkField  DataTextField="ID"   Text="EDIT"
                     HeaderText="Edit Item" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="QuestionSetup.aspx?acttype=edit&id={0}" />

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


            </section>

            <div class="form-group">

                <asp:Label runat="server" AssociatedControlID="dd_search_course" CssClass="col-md-2 control-label ">Search</asp:Label>
                <div class="col-md-7">
                    <asp:DropDownList runat="server" ID="dd_search_course" CssClass="form-control" AutoPostBack="True">
                    </asp:DropDownList>
                </div>

                <div class="col-md-2">
                     <asp:Button ID="btn_search" name="btn_search" runat="server" OnClick="btn_search_Click" Text="Search" CssClass="btn btn-default" />
                </div>

            </div>

        </div>
</div>
</asp:Content>
