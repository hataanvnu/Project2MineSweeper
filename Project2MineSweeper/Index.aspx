<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project2MineSweeper.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID='BtnStartGame' runat='server' Text='Start Game' OnClick="BtnStartGame_Click" />


    <table>
        <asp:Literal ID="LiteralBoard" runat="server"></asp:Literal>
    </table>
    </asp:Content>
