<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="HighScorePage.aspx.cs" Inherits="Project2MineSweeper.HighScorePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;" class="table table-striped">
        <thead>
            <tr>
                <td>Rank</td>
                <td>Name</td>
                <td>Score</td>
            </tr>
        </thead>
        <tbody id="HighScoreBody">
            <asp:Literal ID="LiteralHighScore" runat="server"></asp:Literal>
        </tbody>
    </table>

    <a href="Index.aspx">Back to game</a>
</asp:Content>
