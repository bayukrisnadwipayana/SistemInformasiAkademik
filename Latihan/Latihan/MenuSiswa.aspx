<%@ Page Language="C#" MasterPageFile="~/MenuUtama.Master" AutoEventWireup="true" CodeBehind="MenuSiswa.aspx.cs" Inherits="Latihan.MenuSiswa" Title="Daftar Siswa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>
                  <asp:TextBox name="keyword" ID="text_search" runat="server" CssClass="form-control col-md-2 ml-2" type="search" placeholder="Cari Siswa/Akademik/Event" />
                  <asp:Button ID="search" runat="server" CssClass="btn btn-success col-md-2 ml-2" Text="Search" OnClick="SearchDataSiswa" />
                  
                <br /><br />

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
              <td><asp:LinkButton CssClass="btn btn-primary" ID="link_edit" runat="server" Text="Edit" OnClick="GetValueByNis"></asp:LinkButton> | <asp:LinkButton CssClass="btn btn-danger" ID="link_hapus" runat="server" Text="Hapus" OnClick="DeleteValueByNis"></asp:LinkButton></td>
            </tr>
          </tbody>
          </ItemTemplate>
          <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>
<input id="hidden_value" runat="server" type="hidden" value="0" />
<div id="tampil">
</div>
<script type="text/javascript">
function kata()
{
    var textbox_value=document.getElementById("<%= text_search.ClientID %>").value;
    console.log(textbox_value);
    }
</script>
</asp:Content>
