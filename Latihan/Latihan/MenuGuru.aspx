<%@ Page Language="C#" MasterPageFile="~/MenuUtama.Master" AutoEventWireup="true" CodeBehind="MenuGuru.aspx.cs" Inherits="Latihan.MenuGuru" Title="Untitled Page" %>

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
<asp:GridView ID="tabelguru" runat="server" AutoGenerateColumns="false" CssClass="table table-active table-primary" OnRowDeleting="EventHapusGuru" DataKeyNames="nip">
    <Columns>
        <asp:BoundField HeaderText="NIP" DataField="nip"/>
        <asp:BoundField HeaderText="Nama Guru" DataField="namaguru" />
        <asp:BoundField HeaderText="Mata Pelajaran" DataField="nama_mapel" />
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button CommandName="Delete" Text="Hapus" OnClientClick="return confirm('Anda Yakin Ingin Menghapus Data Guru?')" runat="server" CssClass="btn btn-danger" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
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
                    swal.fire(
                              'Success',
                              'Data Guru Sukses Disimpan',
                              'success'
                            ),
                    window.location.href="MenuGuru.aspx"
                }
            });
        }
    </script>
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</asp:Content>
