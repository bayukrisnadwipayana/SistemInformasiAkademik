<%@ Page Language="C#" MasterPageFile="~/MenuUtama.Master" AutoEventWireup="true" CodeBehind="MenuSiswa.aspx.cs" Inherits="Latihan.MenuSiswa" Title="Daftar Siswa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(document).ready(function(){
        $('.form-control').keyup(function(){
        var text=$(this).val();
        if(text!='') $('td').parent().hide();
        else $('td').parent().show();
        $('td').filter(function(){
            return $(this).text().indexOf(text)!==-1;
        }).parent().show();
    });
   });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                  <asp:TextBox name="keyword" ID="text_search" runat="server" CssClass="form-control col-md-2 ml-2" placeholder="Cari Siswa/Akademik/Event" />
                  <asp:Button ID="search" runat="server" CssClass="btn btn-success col-md-2 ml-2" Text="Search" OnClick="SearchDataSiswa" />                 
                    <br /><br />
        <asp:ScriptManager ID="scriptmanager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
        <asp:Repeater ID="datapendaftaran" runat="server">
        <HeaderTemplate>
        <table class="table">
          <thead class="thead-dark">
            <tr>
              <th scope="col">NIS</th>
              <th scope="col">NAMA</th>
              <th scope="col">ALAMAT</th>
              <th scope="col">JENIS KELAMIN</th>
              <th scope="col">ASAL SEKOLAH</th>
              <th scope="col">KOTA</th>
              <th scope="col">PANITIA</th>
              <th scope="col">AKADEMIK</th>
              <th scope="col">KONFIRMASI</th>
            </tr>
          </thead>
          </HeaderTemplate>
          <ItemTemplate>
          <tbody>
            <tr>
              <td><asp:Label ID="nissiswa" runat="server" Text='<%# Eval("nis") %>'></asp:Label></td>
              <td><asp:Label ID="namasiswa" runat="server" Text='<%# Eval("namasiswa") %>'></asp:Label></td>
              <td><asp:Label ID="alamat" runat="server" Text='<%# Eval("alamat") %>'></asp:Label></td>
              <td><asp:Label ID="jeniskelamin" runat="server" Text='<%# Eval("jeniskelamin") %>'></asp:Label></td>
              <td><asp:Label ID="sekolah" runat="server" Text='<%# Eval("asalsekolah") %>'></asp:Label></td>
              <td><asp:Label ID="kota" runat="server" Text='<%# Eval("namakota") %>'></asp:Label></td>
              <td><asp:Label ID="panitia" runat="server" Text='<%# Eval("nama_panitia") %>'></asp:Label></td>
              <td><asp:LinkButton ID="akademiksiswa" runat="server" CssClass="btn btn-secondary" Text="Nilai Raport" OnClick="RedirectToAkademik"></asp:LinkButton></td>
              <td></ion-icon><asp:LinkButton CssClass="btn btn-primary" ID="link_edit" runat="server" OnClick="GetValueByNis" ToolTip="Edit Siswa"><ion-icon src="Bootstrap/img/create-sharp.svg"></ion-icon></asp:LinkButton> | <asp:LinkButton CssClass="btn btn-danger" ID="link_hapus" runat="server" OnClick="DeleteValueByNis" ToolTip="Delete Siswa"><ion-icon src="Bootstrap/img/trash-sharp.svg"></ion-icon></asp:LinkButton></td>
            </tr>
          </tbody>
          </ItemTemplate>
          <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>