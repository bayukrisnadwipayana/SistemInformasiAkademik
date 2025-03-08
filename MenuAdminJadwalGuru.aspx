<%@ Page Title="" Language="C#" MasterPageFile="~/MenuUtama.Master" AutoEventWireup="true" CodeBehind="MenuAdminJadwalGuru.aspx.cs" Inherits="SistemAkademik.MenuAdminJadwalGuru" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
      Tambah Jadwal Guru
    </button>

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Tambah Jadwal Guru</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
          <div class="form-group">
            <label for="namamapel">Nama Mapel</label>
            <asp:DropDownList ID="namamapel" runat="server" CssClass="form-control">
            </asp:DropDownList>
          </div>
          <div class="form-group">
            <label for="namaguru">Nama Guru</label>
            <asp:DropDownList ID="namaguru" runat="server" CssClass="form-control">
            </asp:DropDownList>
          </div>
          <div class="form-group">
            <label for="kelas">Kelas</label>
            <asp:DropDownList ID="kelas" runat="server" CssClass="form-control">
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
            </asp:DropDownList>
          </div>
          <div class="form-group">
            <label for="kelas">Hari</label>
            <asp:DropDownList ID="hari" runat="server" CssClass="form-control">
                <asp:ListItem Value="senin">Senin</asp:ListItem>
                <asp:ListItem Value="selasa">Selasa</asp:ListItem>
                <asp:ListItem Value="rabu">Rabu</asp:ListItem>
                <asp:ListItem Value="kamis">Kamis</asp:ListItem>
                <asp:ListItem Value="jumat">Jumat</asp:ListItem>
                <asp:ListItem Value="sabtu">Sabtu</asp:ListItem>
            </asp:DropDownList>
          </div>
          <button type="submit" class="btn btn-primary">Submit</button>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <asp:Button ID="btn_savejadwal" runat="server" CssClass="btn btn-primary" Text="Simpan" OnClick="EventSimpanJadwalGuru" />
      </div>
    </div>
  </div>
</div>
<br /><br />
<cc1:ToolkitScriptManager ID="toolscriptmanager2" runat="server"></cc1:ToolkitScriptManager>
<asp:GridView ID="tabeljadwalguru" runat="server" AutoGenerateColumns="false" CssClass="table table-active table-primary">
    <Columns>
        <asp:BoundField HeaderText="Nama Guru" DataField="namaguru" />
        <asp:BoundField HeaderText="Nama Mapel" DataField="nama_mapel" />
        <asp:BoundField HeaderText="Kelas" DataField="kelas" />
        <asp:BoundField HeaderText="Hari" DataField="hari" />
        <asp:TemplateField HeaderText="Konfirmasi">
            <ItemTemplate>
                <asp:Button ID="btn_editlistjadwal" runat="server" CommandName="EditRow" OnClick="EventEditListJadwalGuru" Text="Edit" CssClass="btn btn-warning" />
                <asp:Button ID="btn_deletelistjadwal" runat="server" CommandName="DeleteRow" OnClick="EventDeleteListJadwalGuru" Text="Hapus" CssClass="btn btn-danger" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:Button ID="btn_showmodaleditlistjadwal" runat="server" style="display:none" />
<cc1:ModalPopupExtender ID="popupeditjadwalguru" runat="server" TargetControlID="btn_showmodaleditlistjadwal" PopupControlID="panelpopupjadwalguru"></cc1:ModalPopupExtender>
<asp:Panel ID="panelpopupjadwalguru" runat="server" BackColor="White" Height="269px" Width="400px" style="display:none">
<table width="100%" style="border:Solid 3px #D55500; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#D55500">
    <td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">Detail Guru</td>
        <tr>
            <td align="right">
            Nama Mapel
            </td>
            <td>
            <asp:DropDownList ID="editnamamapel" runat="server" CssClass="form-control" Enabled="false">

            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
            NIP Guru:
            </td>
            <td>
            <asp:TextBox ID="editnipguru" runat="server" CssClass="form-control" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td align="right">
            Kelas
            </td>
            <td>
            <asp:TextBox ID="editkelas" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
            Hari
            </td>        
            <td>
            <asp:DropDownList ID="editnamahari" runat="server" CssClass="form-control">
                <asp:ListItem Value="senin">Senin</asp:ListItem>
                <asp:ListItem Value="selasa">Selasa</asp:ListItem>
                <asp:ListItem Value="rabu">Rabu</asp:ListItem>
                <asp:ListItem Value="kamis">Kamis</asp:ListItem>
                <asp:ListItem Value="jumat">Jumat</asp:ListItem>
                <asp:ListItem Value="sabtu">Sabtu</asp:ListItem>
            </asp:DropDownList>
            </td>       
        </tr>
        <tr>
            <td>
            </td>
            <td>
            <asp:Button ID="btnUpdate" CommandName="update" CssClass="btn btn-warning" runat="server" Text="Update" OnClick="UpdateDataJadwalKelas" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" />
            </td>
        </tr>
</tr>
</table>
</asp:Panel>
</asp:Content>
