﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmpTimeWPUserControl.ascx.cs" Inherits="EmpTimeMgmnt.WebParts.EmpTimeWP.EmpTimeWPUserControl" %>
<script src="../../../../_layouts/15/EmpTimeMgmnt/Scripts/jquery-3.3.1.js"></script>
<script src="../../../../_layouts/15/EmpTimeMgmnt/Scripts/jquery-ui.min.js"></script>
<link href="../../../../_layouts/15/EmpTimeMgmnt/Css/bootstrap.min.css" rel="stylesheet" />
<script src="../../../../_layouts/15/EmpTimeMgmnt/Scripts/loadingoverlay.min.js"></script>
<link href="../../../../_layouts/15/EmpTimeMgmnt/Css/cygent.css" rel="stylesheet" />

<div class="register">
    <div class="row">
        <div class="col-md-2 register-left">
            <a target="_parent" href="http://lufotechnologies.com/">
                <img src="../../../../_layouts/15/EmpTimeMgmnt/Images/logo.png" />
            </a>
            <h3>Welcome</h3>
            <p><%= Microsoft.SharePoint.SPContext.Current.Web.CurrentUser.Name.ToString() %> , <a href="http://infomoss.blogspot.com/2014/10/sharepoint-20102013-spgridview-example.html">when you submit this form, the owner will be able to see your name and email address.! </a></p>
        </div>
        <div class="col-md-10 register-right">
            <!-- Main Section -->
            
            <div class="row register-form">
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="text-secondary col-md-3" for="txtUserTitle">Cretaed By </label>
                        <asp:TextBox ID="txtcreatedBy" CssClass="form-control col-md-6" runat="server"></asp:TextBox>                       
                    </div>
                    <div class="form-group">
                        <label class="text-secondary" for="txtDate">Cretaed Date </label>
                         <asp:TextBox ID="txtDate" CssClass="form-control col-md-6" runat="server"></asp:TextBox> 
                    </div>
                    <div class="form-group">
                        <label class="text-secondary" for="txtTitle">Title</label>
                        <asp:TextBox  id="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="txtTitle" errormessage=" Title is required!" />
                    </div>
                    <div class="form-group">
                        <label class="text-secondary" for="txtDescription">Description <span style="color: orangered">*</span></label>
                         <asp:TextBox  id="txtDescription" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>  
                        <asp:RequiredFieldValidator runat="server" id="reqdesc" controltovalidate="txtDescription" errormessage=" Title is required!" />
                    </div>
                    <div class="form-group">
                        <label class="text-secondary" for="ddlcategory">Category </label>
                        <asp:DropDownList ID="ddlcategory" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="text-secondary" for="ddlTime">Time </label>
                        <asp:DropDownList ID="ddlTime" class="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group right">                      
                        <asp:Button ID="btnSubmit" CssClass="btn btn-primary" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnDeleteListItem" runat="server" Text="Delete" OnClick="btnDeleteListItem_Click" />
                    </div>
                </div>
                 <!-- Bind Section -->
                <div style="padding-top:40px;" class="col-md-12">
                     <asp:Label runat="server" class="text-secondary" ID="lblResult"> </asp:Label>
                <asp:GridView ID="gvListData" CssClass="table table-striped" runat="server"></asp:GridView>  </div>            
            </div>
        </div>
       
    </div>

</div>
