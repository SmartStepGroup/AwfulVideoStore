<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellingReport.aspx.cs" Inherits="AwfulVideoStore.SellingReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div style="font-size: 50px">
                <div><p>Рекомендация: лучше всех продается </p><asp:Label runat="server" ID="bestSellLbl" /></div>
                <asp:ListView runat="server" ID="list">
                    <LayoutTemplate>  
                        <table id="Table1" runat="server" style="font-size: 30px">  
                            <tr id="Tr1" runat="server">  
                                <td id="Td1" runat="server" style="font-size: 30px; color: gray">Title</td>  
                                <td id="Td2" runat="server" style="font-size: 30px; color: gray">Price</td>  
                                <td id="Td3" runat="server" style="font-size: 30px; color: gray">Rating</td>  
                            </tr>  
                            <tr id="ItemPlaceholder" runat="server">  
                            </tr>  
                        </table>  
                    </LayoutTemplate> 
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label   
                                    ID="Label1"  
                                    runat="server"  
                                    Text='<%# Eval("Title") %>' /> 
                            </td>
                            <td><asp:Label   
                                    ID="Label2"  
                                    runat="server"  
                                    Text='<%# Eval("Price") %>' />
                            </td><td><asp:Label  
                                         ID="Label3"  
                                         runat="server"  
                                         Text='<%# Eval("Rating") %>' />
                                 </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </form>
    </body>
</html>