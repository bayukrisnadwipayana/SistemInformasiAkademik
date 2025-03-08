<%@ Page Title="" Language="C#" MasterPageFile="~/MasterpageGuru.Master" AutoEventWireup="true" CodeBehind="JadwalGuru.aspx.cs" Inherits="SistemAkademik.JadwalGuru" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#inputjadwal">
  Tambah Jadwal
</button>
<br /><br />
<!-- Modal -->
<div class="modal fade" id="inputjadwal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Input Jadwal</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">       
        <label for="namamapel">Nama Mata Pelajaran</label>
        <asp:TextBox ID="namamapel" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        <asp:HiddenField ID="idmapel" runat="server" />
        <label for="kelas">Kelas</label>
        <asp:DropDownList ID="inputkelas" runat="server" CssClass="form-control">
            <asp:ListItem Value="1">1</asp:ListItem>
            <asp:ListItem Value="2">2</asp:ListItem>
            <asp:ListItem Value="3">3</asp:ListItem>
        </asp:DropDownList>
          <label for="hari">Hari</label>
        <asp:DropDownList ID="inputhari" runat="server" CssClass="form-control">
                <asp:ListItem Value="senin">Senin</asp:ListItem>
                <asp:ListItem Value="selasa">Selasa</asp:ListItem>
                <asp:ListItem Value="rabu">Rabu</asp:ListItem>
                <asp:ListItem Value="kamis">Kamis</asp:ListItem>
                <asp:ListItem Value="jumat">Jumat</asp:ListItem>
                <asp:ListItem Value="sabtu">Sabtu</asp:ListItem>
            </asp:DropDownList>
      </div>
      <div class="modal-footer">
        <asp:Button ID="btn_simpan_mapel" runat="server" Text="Simpan" CssClass="btn btn-info" OnClick="EventTambahJadwalGuru" />
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
<asp:GridView ID="tabeljadwalmengajar" runat="server" AutoGenerateColumns="false" CssClass="table table-active table-bordered">
    <Columns>
        <asp:BoundField HeaderText="Nama Mapel" DataField="nama_mapel" />
        <asp:BoundField HeaderText="Kelas" DataField="kelas" />
        <asp:BoundField HeaderText="Hari" DataField="hari" />
    </Columns>
</asp:GridView>
</asp:Content>