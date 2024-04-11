<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Latihan.Login" Title="Halaman Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="form-group">
        <label for="exampleInputEmail1" class="h2 text-white bg-secondary ml-4">ID Panitia</label>
        <asp:TextBox ID="email" autocomplete="off" runat="server" CssClass="form-control ml-4 col-3" aria-describedby="emailHelp"></asp:TextBox>
        <asp:Label ID="labelresult" runat="server"></asp:Label>
        <asp:RequiredFieldValidator CssClass="ml-4 col-3" ID="validate_user" runat="server" ControlToValidate="email" ErrorMessage="{wajib diisi}"></asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" ID="range_username" MaximumValue="6" Type="String" Text="Username Lebih Dari 6 Karakter" ControlToValidate="email"></asp:RangeValidator>       
        <small id="emailHelp" ><marquee class="form-text text-warning ml-4 col-3 bg-secondary">We'll never share your email with anyone else.</marquee></small>
      </div>
      <div class="form-group">
        <label for="exampleInputPassword1" class="h2 text-white bg-secondary ml-4">Password</label>
        <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control ml-4 col-3" aria-describedby="emailHelp"></asp:TextBox>
        <asp:RequiredFieldValidator CssClass="ml-4 col-3" ID="validate_password" runat="server" ControlToValidate="password" ErrorMessage="{wajib diisi}"></asp:RequiredFieldValidator>
      </div>
      <div class="form-group form-check ml-4 col-3">
        <asp:CheckBox CssClass="form-check-input" ID="checkbox" runat="server" />
        <label class="form-check-label" for="exampleCheck1">Check me out</label>
      </div>
      <asp:Button CssClass="btn btn-primary ml-4" ID="button_login" runat="server" Text="Sign In" OnClick="login_click"/>
</asp:Content>