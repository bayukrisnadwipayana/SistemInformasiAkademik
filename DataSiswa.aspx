<%@ Page Title="" Language="C#" MasterPageFile="~/MasterpageGuru.Master" AutoEventWireup="true" CodeBehind="DataSiswa.aspx.cs" Inherits="SistemAkademik.InputNilaiSiswa" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="tabeldatasiswa" runat="server">
        <HeaderTemplate>
            <table class="table table-active table-primary">
                <tr">
                    <th class="table-primary">NIS</th>
                    <th class="table-primary">Nama Siswa</th>
                    <th class="table-primary">Konfirmasi</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Label ID="nissiswa" runat="server" Text='<%# Eval("nis") %>'></asp:Label></td>
                <td><asp:Label ID="namasiswa" runat="server" Text='<%# Eval("namasiswa") %>'></asp:Label></td>
                <td><asp:LinkButton ID="linkinputnilai" runat="server" CssClass="btn btn-info" Text="Input Nilai" OnClick="EventRedirectInputNilai"></asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>

        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
