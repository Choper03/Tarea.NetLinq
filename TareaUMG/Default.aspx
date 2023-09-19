﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TareaUMG._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding:15px">

        <table class="w-70" style="height: 287px; width: 1208px">
            <tr>
                <td colspan="2" style="font-size: xx-large; background-color: #333333; color: #FFFFFF; height: 46px;">CRUD PROVEEDORES&nbsp;</td>
            </tr>
            <tr>
                <td class="text-end" style="height: 29px; width: 604px">&nbsp;</td>
                <td class="text-start" style="height: 29px; text-align: justify; width: 604px">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-end" style="height: 30px; width: 604px">
                    <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Codigo:"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; text-align: justify; width: 604px">
                    <asp:TextBox ID="TxtCodigo" runat="server" Font-Size="Medium" TextMode="Number" Width="200px"></asp:TextBox>
                &nbsp;
                    <asp:Button ID="BtnBuscar1" runat="server" BackColor="#666666" Font-Bold="True" Font-Size="Large" ForeColor="White" Text="Buscar" OnClick="BtnBuscar1_Click" />
                </td>
            </tr>
            <tr>
                <td class="text-end" style="width: 604px; height: 30px">
                    <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Nombres:"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:TextBox ID="TxtNombre" runat="server" Font-Size="Medium" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-end" style="width: 604px; height: 30px">
                    <asp:Label ID="Label3" runat="server" Font-Size="Medium" Text="Apellidos:"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:TextBox ID="TxtApellido" runat="server" Font-Size="Medium" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-end" style="width: 604px; height: 30px">
                    <asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="Direccion:"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:TextBox ID="TxtDireccion" runat="server" Font-Size="Medium" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-end" style="width: 604px; height: 30px">
                    <asp:Label ID="Label5" runat="server" Font-Size="Medium" Text="Saldo:"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:TextBox ID="TxtSueldo" runat="server" Font-Size="Medium" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-end" style="width: 604px; height: 30px">
                    <asp:Label ID="Label6" runat="server" Font-Size="Medium" Text="Estado:"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:TextBox ID="TxtEstado" runat="server" Font-Size="Medium" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 604px; height: 30px">&nbsp;</td>
                <td style="height: 30px; width: 604px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 604px; height: 30px">&nbsp;</td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:Button ID="BtnGuardar1" runat="server" BackColor="#666666" Font-Bold="True" Font-Size="Large" ForeColor="White" Text="Guardar" OnClick="BtnGuardar1_Click" />
                    <asp:Button ID="BtnActualizar1" runat="server" BackColor="#666666" Font-Bold="True" Font-Size="Large" ForeColor="White" Text="Actualizar" OnClick="BtnActualizar1_Click" />
                    <asp:Button ID="BtnEliminar1" runat="server" BackColor="#666666" Font-Bold="True" Font-Size="Large" ForeColor="White" Text="Eliminar" OnClick="BtnEliminar1_Click" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="VistaProveedor" runat="server" BackColor="#666666" Font-Bold="True" ForeColor="White" Width="1208px">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chk1" runat="server" AutoPostBack="True" OnCheckedChanged="chk1_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
