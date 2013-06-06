<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SMS.SMS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 136px;
        }
        .style4
        {
            width: 244px;
        }
        .style5
        {
            width: 102px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <br />
    <br />
    <table class="style1" border="1">
        <tr>
            <td class="style2" align="right">
                <asp:Label ID="lbReceiver" runat="server" Text="收件人手機"></asp:Label>
                ：<br />
                群發請以逗號隔開</td>
            <td>
                <asp:TextBox ID="tbPhone" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">
                <asp:Label ID="lbSubject" runat="server" Text="主旨"></asp:Label>
                ：</td>
            <td>
                <asp:TextBox ID="tbSubject" runat="server" Height="20px" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">
                <asp:Label ID="lbContent" runat="server" Text="內容"></asp:Label>
                ：</td>
            <td>
                <asp:TextBox ID="tbContent" runat="server" Height="123px" TextMode="MultiLine" 
                    Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">
                <asp:Label ID="Label6" runat="server" Text="預約傳送"></asp:Label>
                時間：<br />
                不填則立即傳送</td>
            <td>
                <asp:TextBox ID="tbYear" runat="server" Width="71px"></asp:TextBox>
                年/<asp:TextBox ID="tbMonth" runat="server" Width="71px"></asp:TextBox>
                月/<asp:TextBox ID="tbDay" runat="server" Width="71px"></asp:TextBox>
                日/&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbHour" runat="server" Width="71px"></asp:TextBox>
                時:<asp:TextBox ID="tbMinute" runat="server" Width="71px"></asp:TextBox>
                分:<asp:TextBox ID="tbSec" runat="server" Width="71px"></asp:TextBox>
                秒&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btSubmit" runat="server" Text="送出" onclick="btSubmit_Click" />
                <asp:Label ID="lbMsgID" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <br/>
    <table class="style1"  border="1">
        <tr>
            <td class="style5">
                查詢簡訊狀態</td>
            <td class="style4">
                簡訊代碼(MsgID)：<asp:TextBox ID="tbMsgIDq" runat="server" Width="93px"></asp:TextBox>
                </td>
            <td>
                電話：<asp:TextBox ID="tbPhoneq" runat="server" Height="20px" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                <asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" Text="查詢簡訊" />
                <asp:Label ID="lbMsgQuery" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5" >
                取消簡訊</td>
            <td class="style4">
                簡訊代碼(MsgID)：<asp:TextBox ID="tbMsgIDc" runat="server" Width="93px"></asp:TextBox>
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                    Text="取消簡訊" />
                <asp:Label ID="lbMsgCancel" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
