<%@ Page Language="C#" MasterPageFile="~/MenuUtama.Master" AutoEventWireup="true" CodeBehind="EditDataSiswa.aspx.cs" Inherits="Latihan.EditDataSiswa" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img src="Bootstrap/img/Definisi pendidikan.jpg" class="float-right" alt="pendidikan" />
  <div class="form-group">
    <label for="nis" class="ml-2">NIS</label>
    <asp:TextBox CssClass="form-control col-md-3 ml-2" ID="editnis" runat="server" placeholder="Masukan NIS"></asp:TextBox>
  </div>
  <div class="form-group">
    <label for="namasiswa" class="ml-2">Nama Siswa</label>
    <asp:TextBox CssClass="form-control col-md-3 ml-2" ID="editnamasiswa" runat="server" placeholder="Masukan Nama Lengkap Siswa"></asp:TextBox>
  </div>
  <div class="form-group">
    <label for="alamat" class="ml-2">Alamat Siswa</label>
    <asp:TextBox CssClass="form-control col-md-3 ml-2" ID="editalamat" runat="server" placeholder="Masukan Alamat Lengkap Siswa" TextMode="MultiLine"></asp:TextBox>
  </div>
  <div class="form-group">
    <label for="jeniskelamin" class="ml-2">Jenis Kelamin</label>
    <asp:DropDownList CssClass="form-control col-md-3 ml-2" ID="editjeniskelamin" runat="server">
      <asp:ListItem Text="pria"></asp:ListItem>
      <asp:ListItem Text="wanita"></asp:ListItem>
   </asp:DropDownList>
  </div>
  <div class="form-group">
    <label for="kota" class="ml-2">Kota</label>
    <asp:DropDownList CssClass="form-control col-md-3 ml-2" ID="editkodekota" runat="server">
   </asp:DropDownList>
  </div>
  <div class="form-group">
    <label for="sekolahasal" class="ml-2">Asal Sekolah</label>
    <asp:TextBox CssClass="form-control col-md-3 ml-2" ID="editasalsekolah" runat="server" placeholder="Masukan Nama Sekolah Sebelumnya"></asp:TextBox>
  </div>
  <asp:Button ID="button_edit" runat="server" CssClass="btn btn-primary" Text="Update Data" OnClick="Event_Update" />
</asp:Content>
