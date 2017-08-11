<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project2MineSweeper.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID='BtnStartGame' runat='server' Text='Start Game' OnClick="BtnStartGame_Click" />
    <br />
    <asp:Label CssClass="LabelRemainingMoves" ID="LabelRemainingMoves" runat="server" Text=""></asp:Label>
    <br/>
    <asp:Label CssClass="LabelRemainingMoves" ID="LabelMoveCounter" runat="server" Text=""></asp:Label>

    <table>
        <asp:Literal ID="LiteralBoard" runat="server"></asp:Literal>
    </table>
    <div id="GIF">
        <img src="https://media2.giphy.com/media/3jGewqNYjuPhm/giphy.gif" />
    </div>
    </asp:Content>
