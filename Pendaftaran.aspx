<%@ Page Language="C#" MasterPageFile="~/MenuUtama.Master" AutoEventWireup="true" CodeBehind="Pendaftaran.aspx.cs" Inherits="Latihan.Pendaftaran" Title="Pendaftaran" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <img src="Bootstrap/img/Definisi pendidikan.jpg" class="float-right" alt="pendidikan" />
  <div class="form-group">
    <label for="nis" class="ml-2">NIS</label>
    <asp:TextBox CssClass="form-control col-md-3 ml-2" ID="nis" runat="server" placeholder="Masukan NIS"></asp:TextBox>
  </div>
  <div class="form-group">
    <label for="namasiswa" class="ml-2">Nama Siswa</label>
    <asp:TextBox CssClass="form-control col-md-3 ml-2" ID="namasiswa" runat="server" placeholder="Masukan Nama Lengkap Siswa"></asp:TextBox>
  </div>
  <div class="form-group">
    <label for="alamat" class="ml-2">Alamat Siswa</label>
    <asp:TextBox CssClass="form-control col-md-3 ml-2" ID="alamat" runat="server" placeholder="Masukan Alamat Lengkap Siswa" TextMode="MultiLine"></asp:TextBox>
  </div>
  <div class="form-group">
    <label for="jeniskelamin" class="ml-2">Jenis Kelamin</label>
    <asp:DropDownList CssClass="form-control col-md-3 ml-2" ID="jeniskelamin" runat="server">
      <asp:ListItem Text="pria"></asp:ListItem>
      <asp:ListItem Text="wanita"></asp:ListItem>
   </asp:DropDownList>
  </div>
  <div class="form-group">
    <label for="kota" class="ml-2">Kota</label>
    <asp:DropDownList CssClass="form-control col-md-3 ml-2" ID="kodekota" runat="server">
   </asp:DropDownList>
  </div>
  <div class="form-group">
    <label for="sekolahasal" class="ml-2">Asal Sekolah</label>
    <asp:TextBox CssClass="form-control col-md-3 ml-2" ID="asalsekolah" runat="server" placeholder="Masukan Nama Sekolah Sebelumnya"></asp:TextBox>
  </div>
  <asp:Button ID="button_daftar" runat="server" CssClass="btn btn-primary" Text="Daftar" OnClick="Event_Daftar" />
</asp:Content>