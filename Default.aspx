<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASP.NET_CURD_Application.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.NET_CURD_Application</title>

  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-4bw+/aepP/YC94hEpVNVgiZdgIC5+VKNBQNGCHeKRQN+PtmoHDEXuppvnDJzQIu9" crossorigin="anonymous"/> 
</head>
<body>
    <form id="form1" runat="server">
        
         <div class="container">
        
                        <div class="form-group">
                          <div  class="col-sm-12">
                               <h2 style="text-align: center; color: blue">Employee Crud Asp.Net</h2>
                           </div>
                        </div>    
 
                        <hr/>
                        <div class="row">
                        <div class="form-group col-md-6">
                           <label>Employee No</label>
                            <asp:DropDownList ID="DropDownList1" class="form-control" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        
                       <div class="form-group col-md-6">
                           <label>Name</label>
                           <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Address"></asp:TextBox>
                 
                           </div>
                        
                           <div class="form-group col-md-6">
                           <label>Address</label>
                               <asp:TextBox ID="txtaddress" runat="server" class="form-control" placeholder="Address"></asp:TextBox>
           
                           </div>
 
                          <div class="form-group col-md-6">
                           <label>Title</label>
               
                               <asp:TextBox ID="txtposition" runat="server" class="form-control" placeholder="Title"></asp:TextBox>
                          </div>
                        
                          <div class="form-group col-md-6" align="center">
                                 <asp:Button ID="add" runat="server" class="btn btn-success" Text="Add" OnClick="add_Click"></asp:Button>
                                <asp:Button ID="update" runat="server" class="btn btn-warning" Text="Update" OnClick="update_Click"></asp:Button>
                                <asp:Button ID="delete" runat="server" class="btn btn-danger" Text="Delete" OnClick="delete_Click"></asp:Button>
                               <asp:Button ID="Button1" runat="server" class="btn btn-danger" Text="Clear" OnClick="clear_Click"></asp:Button>
                          
                         </div>
            </div>
            </div>
    </form>
</body>
</html>