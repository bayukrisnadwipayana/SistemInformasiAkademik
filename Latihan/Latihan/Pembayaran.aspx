<%@ Page Language="C#" MasterPageFile="~/MenuUtama.Master" AutoEventWireup="true" CodeBehind="Pembayaran.aspx.cs" Inherits="Latihan.Pembayaran" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="datapembayaran" runat="server">
        <HeaderTemplate>
        <table class="table">
          <thead class="thead-dark">
            <tr>
              <th scope="col">NIS</th>
              <th scope="col">NAMA</th>
              <th scope="col">ALAMAT</th>
              <th scope="col">JENIS KELAMIN</th>
              <th scope="col">STATUS</th>
              <th scope="col">LUNAS/TUNGGAKAN</th>
            </tr>
          </thead>
          </HeaderTemplate>
          <ItemTemplate>
          <tbody>
            <tr>
              <td><asp:Label ID="nissiswa" runat="server" ></asp:Label></td>
              <td><asp:Label ID="namasiswa" runat="server"></asp:Label></td>
              <td><asp:Label ID="alamat" runat="server"></asp:Label></td>
              <td><asp:Label ID="jeniskelamin" runat="server"></asp:Label></td>
              <td><asp:CheckBox ID="checkbox_status" runat="server" /></td>
              <td><asp:Label ID="statusbayar" runat="server"></asp:Label></td>
            </tr>
          </tbody>
          </ItemTemplate>
          <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
</asp:Content>
