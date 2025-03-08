<%@ Page Language="C#" MasterPageFile="~/MenuUtama.Master" AutoEventWireup="true" CodeBehind="MenuGuru.aspx.cs" Inherits="Latihan.MenuGuru" Title="Data Guru" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- Button trigger modal -->
<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
  Tambah Data Guru
</button>
<asp:Label ID="label1" runat="server"></asp:Label>
<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Input Guru</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <label for="nip">NIP Guru</label>
        <asp:TextBox ID="nipguru" runat="server" CssClass="form-control"></asp:TextBox>
        <label for="namaguru">Nama Guru</label>
        <asp:TextBox ID="textnamaguru" runat="server" CssClass="form-control"></asp:TextBox>
        <label for="mapel">Mata Pelajaran</label>
        <asp:DropDownList ID="dropdownmapel" runat="server" CssClass="form-control">
        </asp:DropDownList>
        <label for="password">Password</label>
        <asp:TextBox ID="textpassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary" onclick="SimpanDataGuru()">Simpan</button>
      </div>
    </div>
  </div>
</div>
<cc1:ToolkitScriptManager ID="toolkitscriptmanager1" runat="server"></cc1:ToolkitScriptManager>
<asp:GridView ID="tabelguru" runat="server" AutoGenerateColumns="false" CssClass="table table-active table-primary" OnRowDeleting="EventHapusGuru" DataKeyNames="nip">
    <Columns>
        <asp:BoundField HeaderText="NIP" DataField="nip"/>
        <asp:BoundField HeaderText="Nama Guru" DataField="namaguru" />
        <asp:BoundField HeaderText="Mata Pelajaran" DataField="nama_mapel" />
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button CommandName="EditRow" ID="btn_editdataguru" Text="Edit" runat="server" CssClass="btn btn-warning" OnClick="EditDataGuru" />
                <asp:Button CommandName="Delete" Text="Hapus" OnClientClick="return confirm('Anda Yakin Ingin Menghapus Data Guru?')" runat="server" CssClass="btn btn-danger" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:Button ID="BtnShowModal" runat="server" style="display:none" />
<cc1:ModalPopupExtender ID="PopupEdit" runat="server" TargetControlID="BtnShowModal" PopupControlID="PanelPopup" CancelControlID="btnCancel"></cc1:ModalPopupExtender>
<asp:Panel ID="PanelPopup" runat="server" BackColor="White" Height="269px" Width="400px" style="display:none">
<table width="100%" style="border:Solid 3px #D55500; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#D55500">
    <td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">Detail Guru</td>
        <tr>
            <td align="right">
            NIP Guru:
            </td>
            <td>
            <asp:TextBox ID="editnipguru" runat="server" CssClass="form-control" />
            </td>
        </tr>
        <tr>
            <td align="right">
            Nama Guru:
            </td>
            <td>
            <asp:TextBox ID="editnamaguru" runat="server" CssClass="form-control" />
            </td>
        </tr>
        <tr>
            <td align="right">
            Mata Pelajaran:
            </td>
            <td>
            <asp:DropDownList ID="dropdowneditmapel" runat="server" CssClass="form-control">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
            Password:
            </td>        
            <td>
            <asp:TextBox ID="editpassword" runat="server" CssClass="form-control" />
            </td>       
        </tr>
        <tr>
            <td>
            </td>
            <td>
            <asp:Button ID="btnUpdate" CommandName="update" CssClass="btn btn-warning" runat="server" Text="Update" OnClick="UpdateDataGuru" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" />
            </td>
        </tr>
</tr>
</table>
</asp:Panel>
    <script type="text/javascript">
        function SimpanDataGuru()
        {
            var param={nip:$('#<%= nipguru.ClientID %>').val(),nama:$('#<%= textnamaguru.ClientID %>').val(),md5password:$('#<%= textpassword.ClientID %>').val(),idmapel:$('#<%= dropdownmapel.ClientID %>').val()};
            $.ajax({
                type:'POST',
                url:'MenuGuru.aspx/SaveDataGuru',
                data:JSON.stringify(param),
                contentType:'application/Json;charset:utf-8',
                dataType:'Json',
                success:function(data){
                    window.location.href="MenuGuru.aspx";
                }
            });
        }
    </script>
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
</asp:Content>
