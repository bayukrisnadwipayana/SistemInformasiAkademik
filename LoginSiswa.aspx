<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginSiswa.aspx.cs" Inherits="Latihan.LoginSiswa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
	<meta charset="utf-8" />
	<meta name="author" content="Kodinger" />
	<meta name="viewport" content="width=device-width,initial-scale=1" />
	<title>My Login Page</title>
	<link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css" />
</head>

<body class="my-login-page">
	<section class="h-100">
		<div class="container h-100">
			<div class="row justify-content-md-center h-100">
				<div class="card-wrapper">
					<div class="brand">
						<img src="Bootstrap/img/buku.jpeg" width="300px" height="300px" alt="logo" />
					</div>
					<div class="card fat">
						<div class="card-body">
							<h4 class="card-title">Login</h4>
							<form id="formloginsiswa" runat="server" class="my-login-validation" novalidate="">
								<div class="form-group">
									<label for="email">E-Mail Address</label>
									<input id="usernamesiswa" runat="server" type="text" class="form-control" required autofocus />
								</div>

								<div class="form-group">
									<input id="passwordsiswa" runat="server" type="password" class="form-control" required data-eye />
								    <div class="invalid-feedback">
								    	Password is required
							    	</div>
								</div>
								<div class="form-group m-0">
									<asp:Button ID="btnloginsiswa" runat="server" CssClass="btn btn-primary btn-block" OnClick="EventLoginAkunSiswa" Text="Login" />
								</div>
								<div class="mt-4 text-center">
									Don't have an account? <asp:LinkButton ID="nolink" runat="server" Text="Create One" OnClick="EventHubungiAdmin"></asp:LinkButton>
								</div>
							</form>
						</div>
					</div>
					<div class="footer">
						Copyright &copy; 2017 &mdash; Your Company 
					</div>
				</div>
			</div>
		</div>
	</section>

	<script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
	<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
	<script type="text/javascript" src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</body>
</html>