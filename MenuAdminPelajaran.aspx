<%@ Page Title="" Language="C#" MasterPageFile="~/MenuUtama.Master" AutoEventWireup="true" CodeBehind="MenuAdminPelajaran.aspx.cs" Inherits="SistemAkademik.MenuAdminPelajaran" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Button trigger modal -->
<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#inputmapel">
  Tambah Mata Pelajaran
</button>
<br /><br />
<!-- Modal -->
<div class="modal fade" id="inputmapel" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <label for="id mapel">ID Mata Pelajaran</label>
        <asp:TextBox ID="id_mapel" runat="server" CssClass="form-control"  Enabled="false"></asp:TextBox>
        <label for="nama mapel">Nama Mata Pelajaran</label>
        <asp:TextBox ID="namamapel" runat="server" CssClass="form-control"></asp:TextBox>
      </div>
      <div class="modal-footer">
        <asp:Button ID="btn_simpan_mapel" runat="server" Text="Simpan" CssClass="btn btn-info" OnClick="EventSimpanMataPelajaran" />
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>

<asp:GridView ID="datamatapelajaran" runat="server" AutoGenerateColumns="false" CssClass="table table-active table-primary" DataKeyNames="id_mapel" AllowPaging="true" OnPageIndexChanging="EventPenomeranHalaman" PageSize="5" PagerSettings-NextPageText="Next" PagerSettings-PreviousPageText="Preview" OnRowDeleting="EventHapusMataPelajaran">
    <Columns>
        <asp:BoundField HeaderText="ID Mata Pelajaran" DataField="id_mapel" />
        <asp:BoundField HeaderText="Mata Pelajaran" DataField="nama_mapel" />
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button ID="hapusmapel" CommandName="Delete" runat="server" Text="Hapus" CssClass="btn btn-danger" OnClientClick="return confirm('Anda Yakin Ingin Menghapus ?')" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
