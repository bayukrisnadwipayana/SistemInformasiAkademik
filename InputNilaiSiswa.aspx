<%@ Page Title="" Language="C#" MasterPageFile="~/MasterpageGuru.Master" AutoEventWireup="true" CodeBehind="InputNilaiSiswa.aspx.cs" Inherits="SistemAkademik.InputNilaiSiswa1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Button trigger modal -->
<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#inputnilai">
  Input Nilai
</button>

<!-- Modal -->
<div class="modal fade" id="inputnilai" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Input Nilai</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
         <div class="modal-body">
            <div class="form-group">
                <label for="kelas" class="col-form-label">Kelas</label>
                <asp:DropDownList ID="dropdownkelas" runat="server" CssClass="form-control">
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                </asp:DropDownList>
                <label for="semester" class="col-form-label">Semester</label>
                <asp:DropDownList ID="dropdownsemester" runat="server" CssClass="form-control">
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                </asp:DropDownList>
                <label for="nis" class="col-form-label">NIS</label>
                <asp:TextBox ID="textnis" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                <label for="pelajaran" class="col-form-label">Pelajaran</label>
                <asp:TextBox ID="textpelajaran" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                <asp:HiddenField ID="hiddenidpelajaran" runat="server" />
                <label for="tugas" class="col-form-label">Tugas</label>
                <asp:TextBox ID="texttugas" runat="server" CssClass="form-control"></asp:TextBox>
                <label for="kuis" class="col-form-label">Kuis</label>
                <asp:TextBox ID="textkuis" runat="server" CssClass="form-control"></asp:TextBox>
                <label for="ujian" class="col-form-label">Ujian</label>
                <asp:TextBox ID="textujian" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
          </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <asp:Button ID="btn_simpannilai" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="EventSimpanNilaiSiswa" />
      </div>
    </div>
  </div>
</div>
    <asp:GridView ID="tabelnilaisiswa" runat="server" CssClass="table table-primary table-active" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Kelas" DataField="kelas" />
            <asp:BoundField HeaderText="Semester" DataField="semester" />
            <asp:BoundField HeaderText="Pelajaran" DataField="nama_mapel" />
            <asp:BoundField HeaderText="Tugas" DataField="tugas" />
            <asp:BoundField HeaderText="Kuis" DataField="kuis" />
            <asp:BoundField HeaderText="Ujian" DataField="ujian" />
            <asp:BoundField HeaderText="Rata-Rata" DataField="rata_rata" />
            <asp:TemplateField HeaderText="Konfirmasi">
                <ItemTemplate>
                    <asp:Button ID="hapusnilaisiswa" runat="server" CssClass="btn btn-danger" Text="Hapus" OnClick="EventDeleteNilaiSiswa" OnClientClick="return confirm('Anda Yakin Ingin Menghapus Nilai Siswa?')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>