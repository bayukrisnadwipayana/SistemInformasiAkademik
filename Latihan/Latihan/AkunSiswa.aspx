<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AkunSiswa.aspx.cs" Inherits="Latihan.AkunSiswa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link rel="Stylesheet" href="Bootstrap/css/bootstrap.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/popper.js@1.14.3/dist/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <title>Untitled Page</title>
</head>
<body>
    <p class="text-center font-weight-bold text-black-50 text-lg-center">Selamat Datang Siswa SMAN 1 ABCDE</p>
    <form id="form1" runat="server">
    <nav>
      <div class="nav nav-tabs" id="nav-tab" role="tablist">
        <a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">Profil</a>
        <a class="nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">Pembayaran</a>
        <a class="nav-item nav-link" id="nav-contact-tab" data-toggle="tab" href="#nav-contact" role="tab" aria-controls="nav-contact" aria-selected="false">Akademik</a>
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
        <td><%# Eval("kelas") %></td>
        <td><%# Eval("semester") %></td>
        <td><%# Eval("nis") %></td>
        <td><%# Eval("id_mapel") %></td>
        <td><%# Eval("tugas") %></td>
        <td><%# Eval("kuis") %></td>
        <td><%# Eval("ujian") %></td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
      </div>
    </div>
    </form>
</body>
</html>
