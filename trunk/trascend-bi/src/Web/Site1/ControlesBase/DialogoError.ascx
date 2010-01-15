<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DialogoError.ascx.cs" Inherits="ControlesBase_DialogoError" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/javascript">
    function OnAceptar() {

    window.location = "../../Inicio.aspx"
    
    }
</script>
<div>
    <asp:Label ID="lb_oculto" runat="server"></asp:Label>
    <br />
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopupError" Style="display: none">
        <asp:Label ID="labelCodigo" runat="server" CssClass="texto_error_bold" Width="400px"></asp:Label>
        <br />
        <asp:Label ID="labelMensaje" runat="server" CssClass="texto_error" Width="400px"></asp:Label>
        <br />
        <hr />
        <asp:Panel ID="panelTitulo" HorizontalAlign="right" runat="server" CssClass="collapsePanelHeader"
            Style="cursor: pointer" Width="400px">
            <asp:Label ID="labelDetalle" runat="server" CssClass="texto_error" Style="text-decoration: underline"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="panelDetalles" runat="server" CssClass="texto_error">
            <asp:Label ID="labelActor" runat="server" Text="Label"></asp:Label><br />
            <asp:TextBox ID="detalles" ReadOnly="true" TextMode="MultiLine" runat="server" Height="80px"
                Width="393px">
            </asp:TextBox>
        </asp:Panel>
        <br />
        <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="panelDetalles"
            ExpandControlID="panelTitulo" CollapseControlID="panelTitulo" Collapsed="true"
            TextLabelID="labelDetalle" CollapsedText="Mostrar Detalles" ExpandedText="Ocultar Detalles"
            SuppressPostBack="true">
        </cc1:CollapsiblePanelExtender>
        <asp:Button ID="bot_aceptar" runat="server" Text="Aceptar" SkinID="botonModalError" />
        <br />
    </asp:Panel>
    <cc1:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="lb_oculto"
        SkinID="modalError" PopupControlID="Panel1" BackgroundCssClass="modalBackgroundError"
        DropShadow="false" OkControlID="bot_aceptar" OnOkScript="OnAceptar()">
    </cc1:ModalPopupExtender>
    <cc1:DropShadowExtender ID="DropShadowExtender1" runat="server" BehaviorID="DropShadowBehavior1"
        TargetControlID="Panel1" Width="5" Rounded="false" Opacity=".9" TrackPosition="true">
    </cc1:DropShadowExtender>
</div>