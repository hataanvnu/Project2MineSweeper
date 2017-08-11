<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project2MineSweeper.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="HighScoreInput" ContentPlaceHolderID="CPHHeader" runat="server">


    <asp:Label CssClass="LabelRemainingMoves" ID="LabelPlayerName" runat="server" Text="Name: "></asp:Label>

    <asp:TextBox ID="TextBoxPlayerName" runat="server"></asp:TextBox>
    
    <asp:RequiredFieldValidator ID="RFVPlayerName" runat="server" ErrorMessage="Enter Name" ControlToValidate="TextBoxPlayerName" EnableClientScript="False"></asp:RequiredFieldValidator>
   
    <asp:RegularExpressionValidator ID="FEVPlayerName" runat="server" ErrorMessage="Name must be shorter than 20 characters" ControlToValidate="TextBoxPlayerName" ValidationExpression="^[a-zA-Z0-9]{2,20}$" EnableClientScript="False"></asp:RegularExpressionValidator><br />


    <asp:Button ID='BtnStartGame' runat='server' Text='Start Game' OnClick="BtnStartGame_Click" />
    

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label CssClass="LabelRemainingMoves" ID="LabelRemainingMoves" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label CssClass="LabelRemainingMoves" ID="LabelMoveCounter" runat="server" Text=""></asp:Label>

    <%--<asp:Literal ID="LiteralHighScoreInput" runat="server"></asp:Literal>--%>





    <table oncontextmenu="return false;">
        <asp:Literal ID="LiteralBoard" runat="server"></asp:Literal>
    </table>
    <div id="GIF">
        <img src="https://media2.giphy.com/media/3jGewqNYjuPhm/giphy.gif" />
    </div>
</asp:Content>
