<%@ Page Language="C#" MasterPageFile="~/MenuUtama.Master" AutoEventWireup="true" CodeBehind="MenuSiswa.aspx.cs" Inherits="Latihan.MenuSiswa" Title="Daftar Siswa" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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

<script type="text/javascript" src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:TextBox name="keyword" ID="text_search" runat="server" CssClass="form-control col-md-2 ml-2" placeholder="Cari Siswa/Akademik/Event" />
        <asp:Button ID="search" runat="server" CssClass="btn btn-success col-md-2 ml-2" Text="Search" OnClick="SearchDataSiswa" />                 
        <br /><br />
        <cc1:ToolkitScriptManager ID="toolkitscriptmanager1" runat="server"></cc1:ToolkitScriptManager>
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
              <td>
                </ion-icon><asp:LinkButton CssClass="btn btn-primary" ID="link_edit" runat="server" OnClick="GetValueByNis" ToolTip="Edit Siswa"><ion-icon src="Bootstrap/img/create-sharp.svg"></ion-icon></asp:LinkButton> | <asp:LinkButton CssClass="btn btn-danger" ID="link_hapus" runat="server" OnClick="DeleteValueByNis" OnClientClick="return confirm('are you sure to delete')" ToolTip="Delete Siswa"><ion-icon src="Bootstrap/img/trash-sharp.svg"></ion-icon></asp:LinkButton> | <asp:LinkButton ID="btn_buatpasswordsiswa" runat="server" CssClass="btn btn-info" OnClick="EventModalCreatePasswordSiswa"><ion-icon src="Bootstrap/img/newspaper-outline.svg"></ion-icon></asp:LinkButton>
              </td>
            </tr>
          </tbody>
          </ItemTemplate>
          <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
        <asp:Button ID="btn_modalcreate" runat="server" style="display:none" />
        <cc1:ModalPopupExtender ID="modalcreatepasswordsiswa" runat="server" TargetControlID="btn_modalcreate" X="500" Y="150" PopupControlID="panel1" CancelControlID="btn_cancel"></cc1:ModalPopupExtender>
        <asp:Panel ID="panel1" runat="server" BackColor="White" Height="269px" Width="400px" style="display:none">
<table width="100%" style="border:Solid 3px #D55500; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#D55500">
    <td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">Detail Guru</td>
        <tr>
            <td align="right">
            Nis:
            </td>        
            <td>
            <asp:TextBox ID="textnissiswa" runat="server" CssClass="form-control-sm" Enabled="false" />
            </td>       
        </tr>
        <tr>
            <td align="right">
            Password:
            </td>        
            <td>
            <asp:TextBox ID="textpasswordsiswa" runat="server" CssClass="form-control-sm" />
            </td>       
        </tr>
        <tr>
            <td>
            </td>
            <td>
            <asp:Button ID="btn_save" CssClass="btn btn-info" runat="server" Text="Save" OnClick="EventSavePasswordSiswa" />
            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="btn btn-danger" />
            </td>
        </tr>
</tr>
</table>
</asp:Panel>
</asp:Content>