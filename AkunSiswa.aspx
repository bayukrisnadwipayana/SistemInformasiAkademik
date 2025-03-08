<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AkunSiswa.aspx.cs" Inherits="Latihan.AkunSiswa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link rel="Stylesheet" href="Bootstrap/css/bootstrap.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/popper.js@1.14.3/dist/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <title>Akun Siswa</title>
</head>
<body>
    <p class="text-center font-weight-bold text-black-50 text-lg-center">Selamat Datang Siswa SMP Negeri 2 Selemadeg Timur</p>
    <form id="form1" runat="server">
    <nav>
      <div class="nav nav-tabs" id="nav-tab" role="tablist">
        <a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">Profil</a>
        <a class="nav-item nav-link" id="nav-contact-tab" data-toggle="tab" href="#nav-contact" role="tab" aria-controls="nav-contact" aria-selected="false">Akademik</a>
        <a class="nav-item nav-link" id="nav-upload-tab" data-toggle="tab" href="#nav-upload" role="tab" aria-controls="nav-upload" aria-selected="false">Upload Surat</a>
        <asp:LinkButton CssClass="nav-item nav-link" ID="linkbuttonlogout" runat="server" Text="Logout" OnClick="EventLogout"></asp:LinkButton>
      </div>
    </nav>
    <div class="tab-content" id="nav-tabContent">
      <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
        <section style="background-color: #eee;">
          <div class="container py-5">
            <div class="row">
              <div class="col-lg-4">
                <div class="card mb-4">
                  <div class="card-body text-center">
                    <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava3.webp" alt="avatar"
                      class="rounded-circle img-fluid" style="width: 150px;">                    
                  </div>
                  <h5 class="my-3"><asp:Label ID="labelnama" runat="server"></asp:Label></h5>
                </div>
              </div>
              <div class="col-lg-8">
                <div class="card mb-4">
                  <div class="card-body">
                  <div class="row">
                      <div class="col-sm-3">
                        <p class="mb-0">NIS</p>
                      </div>
                      <div class="col-sm-9">
                        <asp:Label ID="labelnis" runat="server" CssClass="text-muted mb-0"></asp:Label>
                      </div>
                    </div>
                    <hr />
                    <div class="row">
                      <div class="col-sm-3">
                        <p class="mb-0">Nama</p>
                      </div>
                      <div class="col-sm-9">
                        <asp:Label ID="labelnamasiswa" runat="server" CssClass="text-muted mb-0"></asp:Label>
                      </div>
                    </div>
                    <hr>
                    <div class="row">
                      <div class="col-sm-3">
                        <p class="mb-0">Alamat</p>
                      </div>
                      <div class="col-sm-9">
                        <asp:Label ID="labelalamat" runat="server" CssClass="text-muted mb-0"></asp:Label>
                      </div>
                    </div>
                    <hr>
                    <div class="row">
                      <div class="col-sm-3">
                        <p class="mb-0">Jenis Kelamin</p>
                      </div>
                      <div class="col-sm-9">
                        <asp:Label ID="labeljeniskelamin" runat="server" CssClass="text-muted mb-0"></asp:Label>
                      </div>
                    </div>
                    <hr>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </section>
      </div>
      <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
        
      </div>
      <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">
        <asp:Repeater ID="daftar_transkip" runat="server">
        <HeaderTemplate>
            <table class="table table-active table-bordered">
            <tr>
            <th colspan="col">Kelas</th>
            <th>Semester</th>
            <th>NIS</th>
            <th>Pelajaran</th>
            <th>Tugas</th>
            <th>Kuis</th>
            <th>Ujian</th>
            <th>Rata-Rata</th>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
        <td><asp:Label ID="kelassiswa" runat="server" Text='<%# Eval("kelas") %>'></asp:Label></td>
        <td><asp:Label ID="semestersiswa" runat="server" Text='<%# Eval("semester") %>'></asp:Label></td>
        <td><asp:Label ID="nissiswa" runat="server" Text='<%# Eval("nis") %>'></asp:Label></td>
        <td><asp:Label ID="mapelsiswa" runat="server" Text='<%# Eval("nama_mapel") %>'></asp:Label></td>
        <td><asp:Label ID="tugassiswa" runat="server" Text='<%# Eval("tugas") %>'></asp:Label></td>
        <td><asp:Label ID="kuissiswa" runat="server" Text='<%# Eval("kuis") %>'></asp:Label></td>
        <td><asp:Label ID="ujiansiswa" runat="server" Text='<%# Eval("ujian") %>'></asp:Label></td>
        <td><asp:Label ID="rataratasiswa" runat="server" Text='<%# Eval("rata_rata") %>'></asp:Label></td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
        <button title="Print" id="btn_print" class="btn btn-info" onclick="print()"><ion-icon name="print-outline" src="Bootstrap/img/print-outline.svg"></ion-icon></button>
      </div>
      <div class="tab-pane fade" id="nav-upload" role="tabpanel" aria-labelledby="nav-upload-tab">
        <!-- Button trigger modal -->
        <br />
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#uploadsurat">
          Upload Surat
        </button>

        <!-- Modal -->
        <div class="modal fade" id="uploadsurat" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Upload Surat Keterangan</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <div class="form-group row">
                <label for="inputnis" class="col-sm-2 col-form-label">NIS</label>
                <div class="col-sm-10">
                  <asp:TextBox ID="inputnis" runat="server" CssClass="form-control" placeholder="NIS"></asp:TextBox>
                </div>
              </div>
              <div class="form-group row">
                <label for="inputnama" class="col-sm-2 col-form-label">Nama</label>
                <div class="col-sm-10">
                  <asp:TextBox ID="inputnama" runat="server" CssClass="form-control" placeholder="Nama">Nama</asp:TextBox>
                </div>
              </div>
              <div class="form-group row">
                <label for="inputalamat" class="col-sm-2 col-form-label">Alamat</label>
                <div class="col-sm-10">
                  <asp:TextBox ID="inputalamat" runat="server" CssClass="form-control" placeholder="Alamat">Alamat</asp:TextBox>
                </div>
              </div>
              <div class="form-group row">
                  <label for="uploadsurat" class="col-sm-2 col-form-label">Upload Surat</label>
                  <div class="col-sm-10">
                    <asp:FileUpload ID="uploadfilesurat" runat="server" CssClass="form-control-file" />
                  </div>
               </div>
               <div class="form-group row">
                  <label for="exampletanggalupload" class="col-sm-2 col-form-label">Tanggal Upload</label>
                  <div class="col-sm-10">
                    <input type="date" name="tanggalupload" class="form-control" />
                  </div>
               </div>
               <div class="form-group row">
                  <label for="keterangan" class="col-sm-2 col-form-label">Keterangan</label>
                  <div class="col-sm-10">
                    <asp:DropDownList ID="keterangansurat" runat="server" CssClass="form-control">
                        <asp:ListItem>SAKIT</asp:ListItem>
                        <asp:ListItem>IJIN</asp:ListItem>
                        <asp:ListItem>LAIN-LAIN</asp:ListItem>
                    </asp:DropDownList>
                  </div>
               </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                <asp:Button ID="btn_upload" runat="server" CssClass="btn btn-primary" OnClick="KirimSurat" Text="Kirim" />
              </div>
            </div>
          </div>
        </div>
        <br /><br />
        <asp:GridView ID="gridviewsurat" runat="server" AutoGenerateColumns="false" DataKeyNames="nis,tgl_upload,keterangan" CssClass="table table-active table-bordered" HeaderStyle-BackColor="Aqua">
            <Columns>
                <asp:BoundField DataField="nis" HeaderText="NIS" />
                <asp:BoundField DataField="namasiswa" HeaderText="Nama" />
                <asp:BoundField DataField="alamat" HeaderText="Alamat" />
                <asp:BoundField DataField="keterangan" HeaderText="Keterangan" />
                <asp:BoundField DataField="tgl_upload" HeaderText="Tanggal Upload" />
                <asp:TemplateField HeaderText="Keterangan">
                    <ItemTemplate>
                        <asp:LinkButton ID="tombolhapussurat" ToolTip="Hapus" runat="server" CssClass="btn btn-danger" OnClick="EventHapusSurat" OnClientClick="return confirm('Anda Yakin Ingin Menghapus?')"><ion-icon src="Bootstrap/img/trash-outline.svg"></ion-icon></asp:LinkButton>
                        <asp:LinkButton ID="tomboldownload" ToolTip="Download" runat="server" CssClass="btn btn-info" OnClick="EventDownloadSurat"><ion-icon name="cloud-download-outline" src="Bootstrap/img/cloud-download-outline.svg"></ion-icon></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
      </div>
    </div>
    </form>
    <script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
    <script nomodule src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
</body>
</html>
