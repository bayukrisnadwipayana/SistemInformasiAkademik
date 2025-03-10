﻿<%@ Page Language="C#" MasterPageFile="~/MenuUtama.Master" AutoEventWireup="true" CodeBehind="Akademik.aspx.cs" Inherits="Latihan.Akademik" Title="Halaman Akademik" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .fancy-green .ajax__tab_header
        {
        background: url('Bootstrap/img/image.jpg') repeat-x;
        cursor:pointer;
        }
        .fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer
        {
        background: url('Bootstrap/img/image.jpg') no-repeat left top;
        }
        .fancy-green .ajax__tab_hover .ajax__tab_inner, .fancy-green .ajax__tab_active .ajax__tab_inner
        {
        background: url('Bootstrap/img/image.jpg') no-repeat right top;
        }
        .fancy .ajax__tab_header
        {
        font-size: 13px;
        font-weight: bold;
        color: #000;
        font-family: sans-serif;
        }
        .fancy .ajax__tab_active .ajax__tab_outer, .fancy .ajax__tab_header .ajax__tab_outer, .fancy .ajax__tab_hover .ajax__tab_outer
        {
        height: 46px;
        }
        .fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner
        {
        height: 46px;
        margin-left: 16px; /* offset the width of the left image */
        }
        .fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab
        {
        margin: 16px 16px 0px 0px;
        }
        .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab
        {
        color: #fff;
        }
        .fancy .ajax__tab_body
        {
        font-family: Arial;
        font-size: 10pt;
        border-top: 0;
        border:1px solid #999999;
        padding: 8px;
        background-color: #ffffff;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
      Input Nilai
    </button>

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Input Nilai Siswa</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
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
                <asp:DropDownList ID="dropdownlistpelajaran" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <label for="tugas" class="col-form-label">Tugas</label>
                <asp:TextBox ID="texttugas" runat="server" CssClass="form-control"></asp:TextBox>
                <label for="kuis" class="col-form-label">Kuis</label>
                <asp:TextBox ID="textkuis" runat="server" CssClass="form-control"></asp:TextBox>
                <label for="ujian" class="col-form-label">Ujian</label>
                <asp:TextBox ID="textujian" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <asp:Button ID="btn_saveraport" runat="server" Text="Simpan" CssClass="btn btn-primary" OnClientClick="return confirm('Anda Yakin Menyimpan Data')" OnClick="SimpanRaportSiswa" />
          </div>
        </div>
      </div>
    </div>
    <br /><br />
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="fancy fancy-green">
        <cc1:TabPanel runat="server" HeaderText="Nilai Raport" ID="tabpanel1" Height="100px">
            <ContentTemplate>
                <h3 class="text-capitalize">Semester 1</h3>
                <asp:Repeater ID="tabelkelas1semester1" runat="server">
                    <HeaderTemplate>
                        <table class="table table-bordered">
                            <tr>
                                <th scope="col">Kelas</th>
                                <th scope="col">Semester</th>
                                <th scope="col">NIS</th>
                                <th scope="col">Nama</th>
                                <th scope="col">Pelajaran</th>
                                <th scope="col">Nilai Tugas</th>
                                <th scope="col">Nilai Kuis</th>
                                <th scope="col">Nilai Ujian</th>
                                <th scope="col">Nilai Rata-Rata</th>
                                <th scope="col">Action</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><asp:Label ID="labelkelas" runat="server" Text='<%# Eval("kelas") %>'></asp:Label></td>
                            <td><asp:Label ID="labelsemester" runat="server" Text='<%# Eval("semester") %>'></asp:Label></td>
                            <td><asp:Label ID="labelnis" runat="server" Text='<%# Eval("nis") %>'></asp:Label></td>
                            <td><asp:Label ID="labelnama" runat="server" Text='<%# Eval("namasiswa") %>'></asp:Label></td>
                            <td><asp:Label ID="labelpelajaran" runat="server" Text='<%# Eval("nama_mapel") %>'></asp:Label></td>
                            <td><asp:Label ID="labeltugas" runat="server" Text='<%# Eval("tugas") %>'></asp:Label></td>
                            <td><asp:Label ID="labelkuis" runat="server" Text='<%# Eval("kuis")%>'></asp:Label></td>
                            <td><asp:Label ID="labelujian" runat="server" Text='<%# Eval("ujian") %>'></asp:Label></td>
                            <td><asp:Label ID="labelratarata" runat="server" Text='<%# Eval("rata_rata") %>'></asp:Label></td>
                            <td>
                                <asp:LinkButton ID="linkbuttonupdate" runat="server" Text="Update" CssClass="btn btn-warning" ToolTip="Update" OnClick="EventModalUpdateRaportKelas1Semester1"><ion-icon src="Bootstrap/img/create-sharp.svg"></ion-icon></asp:LinkButton> | 
                                <asp:LinkButton ID="linkbuttonmodaldelete" runat="server" Text="Hapus" CssClass="btn btn-danger" OnClick="EventModalHapusRaportKelas1Semester1" ToolTip="Delete"><ion-icon src="Bootstrap/img/trash-sharp.svg"></ion-icon></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Button ID="btn_modalpopuphapus" runat="server" style="display:none" />
                <asp:Button ID="btn_modalpopupupdate" runat="server" style="display:none" />
                <cc1:ModalPopupExtender ID="modalpopuphapus" runat="server" PopupControlID="panel1" X="500" Y="150" TargetControlID="btn_modalpopuphapus" CancelControlID="btnCancel"></cc1:ModalPopupExtender>
                <cc1:ModalPopupExtender ID="modalpopupupdate" runat="server" PopupControlID="panel2" X="500" Y="150" TargetControlID="btn_modalpopupupdate" CancelControlID="btn_cancelupdate"></cc1:ModalPopupExtender>
                <asp:Panel ID="panel1" runat="server" BackColor="White" Height="269px" Width="400px" style="display:none">
                <table width="100%" style="border:Solid 3px #D55500; width:100%; height:100%" cellpadding="0" cellspacing="0">
                    <tr style="background-color:#D55500">
                        <td colspan="2" style="height:10%; color:White; font-weight:bold; font-size:larger" align="center">Detail Nilai</td>
                            <tr>
                                <td align="right">
                                Kelas:
                                </td>
                                <td>
                                <asp:TextBox ID="texthapuskelas1" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                Semester:
                                </td>
                                <td>
                                <asp:TextBox ID="texthapussemester1" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                Nis:
                                </td>
                                <td>
                                <asp:TextBox ID="texthapusnis" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                Pelajaran:
                                </td>        
                                <td>
                                <asp:TextBox ID="texthapuspelajaran1" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>       
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                <asp:Button ID="btnHapus" runat="server" Text="Delete" CssClass="btn btn-warning" OnClick="EventHapusRaportKelas1Semester1" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" />
                                </td>
                            </tr>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="panel2" runat="server" BackColor="White" Height="500px" Width="400px" style="display:none">
                <table width="100%" style="border:Solid 3px #D55500; width:100%; height:100%" cellpadding="0" cellspacing="0">
                    <tr style="background-color:#D55500">
                        <td colspan="2" style="height:10%; color:White; font-weight:bold; font-size:larger" align="center">Detail Raport</td>
                            <tr>
                                <td align="right">
                                Kelas:
                                </td>
                                <td>
                                <asp:TextBox ID="textupdatekelas" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                Semester:
                                </td>
                                <td>
                                <asp:TextBox ID="textupdatesemester" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                Nis:
                                </td>
                                <td>
                                <asp:TextBox ID="textupdatenis" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                Pelajaran:
                                </td>        
                                <td>
                                <asp:TextBox ID="textupdatepelajaran" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </td>       
                            </tr>
                            <tr>
                                <td align="right">
                                Nilai Tugas:
                                </td>        
                                <td>
                                <asp:TextBox ID="textupdatetugas" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>       
                            </tr>
                            <tr>
                                <td align="right">
                                Nilai Kuis:
                                </td>        
                                <td>
                                <asp:TextBox ID="textupdatekuis" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>       
                            </tr>
                            <tr>
                                <td align="right">
                                Nilai Ujian:
                                </td>        
                                <td>
                                <asp:TextBox ID="textupdateujian" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>       
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                <asp:Button ID="btn_updateraport11" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="EventUpdateRaportKelas1Semester1" />
                                <asp:Button ID="btn_cancelupdate" runat="server" Text="Cancel" CssClass="btn btn-danger" />
                                </td>
                            </tr>
                    </tr>
                </table>
                </asp:Panel>
                <h3 class="text-capitalize">Semester 2</h3>
                <asp:GridView ID="tabelkelas1semester2" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive-md" DataKeyNames="kelas,semester,nis,nama_mapel">
                    <Columns>
                        <asp:BoundField HeaderText="Kelas" DataField="kelas" />
                        <asp:BoundField HeaderText="Semester" DataField="semester" />
                        <asp:BoundField HeaderText="Nis" DataField="nis" />
                        <asp:BoundField HeaderText="Nama" DataField="namasiswa" />
                        <asp:BoundField HeaderText="Pelajaran" DataField="nama_mapel" />
                        <asp:BoundField HeaderText="Nilai Tugas" DataField="tugas" />
                        <asp:BoundField HeaderText="Nilai Kuis" DataField="kuis" />
                        <asp:BoundField HeaderText="Nilai Ujian" DataField="ujian" />
                        <asp:BoundField HeaderText="Nilai Rata-Rata" DataField="rata_rata" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="btn_update" runat="server" CssClass="btn btn-warning" OnClick="OpenModalPopupUpdate12"><ion-icon src="Bootstrap/img/create-sharp.svg"></asp:LinkButton>
                                <asp:LinkButton ID="btn_delete" runat="server" CssClass="btn btn-danger" OnClientClick="return confirm('Anda Yakin Menghapus ?')" OnClick="EventDelete22"><ion-icon src="Bootstrap/img/trash-sharp.svg"></ion-icon></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
               <asp:Button ID="btn_openmodalgridviewupdate" runat="server" style="display:none" />
               <cc1:ModalPopupExtender ID="modalgridviewupdate12" runat="server" TargetControlID="btn_openmodalgridviewupdate" PopupControlID="panel3" CancelControlID="btn_cancelupdate12" X="500" Y="150"></cc1:ModalPopupExtender>
               <asp:Panel ID="panel3" runat="server" BackColor="White" Height="500px" Width="400px" style="display:none">
                <table width="100%" style="border:Solid 3px #D55500; width:100%; height:100%" cellpadding="0" cellspacing="0">
                    <tr style="background-color:#D55500">
                        <td colspan="2" style="height:10%; color:White; font-weight:bold; font-size:larger" align="center">Detail Guru</td>
                            <tr>
                                <td align="right">
                                Kelas:
                                </td>
                                <td>
                                <asp:TextBox ID="textkelas12" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                Semester:
                                </td>
                                <td>
                                <asp:TextBox ID="textsemester12" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                Nis:
                                </td>
                                <td>
                                <asp:TextBox ID="textnis12" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                Pelajaran:
                                </td>        
                                <td>
                                <asp:TextBox ID="textpelajaran12" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </td>       
                            </tr>
                            <tr>
                                <td align="right">
                                Nilai Tugas:
                                </td>        
                                <td>
                                <asp:TextBox ID="texttugas12" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>       
                            </tr>
                            <tr>
                                <td align="right">
                                Nilai Kuis:
                                </td>        
                                <td>
                                <asp:TextBox ID="textkuis12" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>       
                            </tr>
                            <tr>
                                <td align="right">
                                Nilai Ujian:
                                </td>        
                                <td>
                                <asp:TextBox ID="textujian12" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>       
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                <asp:Button ID="btn_updateraport12" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="EventUpdateRaportKelas1Semester2" />
                                <asp:Button ID="btn_cancelupdate12" runat="server" Text="Cancel" CssClass="btn btn-danger" />
                                </td>
                            </tr>
                    </tr>
                </table>
                </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>
