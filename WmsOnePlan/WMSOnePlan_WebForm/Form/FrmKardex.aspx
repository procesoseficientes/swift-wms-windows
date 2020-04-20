<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FrmKardex.aspx.vb" Inherits="WMSOnePlan_WebForm.FrmKardex" %>

<%@ Register Assembly="DevExpress.Web.v19.2, Version=19.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>






<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Kardex</title>
    <style type="text/css">
        .DisplayNone {
            display: none;
        }

        .auto-style1 {
            height: 28px;
        }
    </style>
    <script type="text/javascript">
        function AdjustSize() {
            var height = Math.max(0, document.documentElement.clientHeight - 80);
            GridKardexCertificate.SetHeight(height);
            GridKardexCons.SetHeight(height);
            GridKardexTxns.SetHeight(height);
        }
        function ValidateRangeDateConskardex(s, e) {
            var fechaInicio = dtFechaInicio.date;
            var fechaFinal = s.date;
            
            if (fechaInicio.getFullYear() > fechaFinal.getFullYear() && fechaInicio.getMonth() > fechaFinal.getMonth() && fechaInicio.getDay() > fechaFinal.getDay()) {
                e.isValid = false;
            }

        }
    </script>
    <link rel="stylesheet" href="CSS/Main.css" type="text/css" />
</head>
<body onload="AdjustSize();">
    <form id="form1" runat="server">
        <table width="100%">
            <tr>
                <td align="right">
                    <dx:ASPxButton ID="btnSalir" runat="server" Height="32px" Width="32px" ToolTip="Cerrar Sesion">
                        <BackgroundImage ImageUrl="~/Images/door_out.png" />
                    </dx:ASPxButton>

                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="lblError" runat="server" ForeColor="Red"></dx:ASPxLabel>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxPageControl ID="pcKardex" runat="server" ActiveTabIndex="2" TabPosition="Left" Width="100%" Height="100%">
                        <TabPages>
                            <dx:TabPage Text="Inventario en Certificado">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:ASPxMenu ID="menInvCertificado" runat="server">
                                            <Items>
                                                <dx:MenuItem Text="" Name="btnExExel" ToolTip="Exportar a Exel">
                                                    <Image Url="~/Images/page_white_excel.png">
                                                    </Image>
                                                </dx:MenuItem>
                                                <dx:MenuItem Text="" Name="btnExPdf" ToolTip="Exportar a Pdf">
                                                    <Image Url="~/Images/file_extension_pdf.png">
                                                    </Image>
                                                </dx:MenuItem>
                                            </Items>
                                        </dx:ASPxMenu>
                                        <dx:ASPxGridViewExporter ID="gridExportInvCertificate" runat="server" GridViewID="GridKardexCertificate"></dx:ASPxGridViewExporter>
                                        <dx:ASPxGridView ID="GridKardexCertificate" runat="server" AutoGenerateColumns="False" Style="margin-left: 0px" Width="100%"
                                            ClientInstanceName="GridKardexCertificate">
                                            <TotalSummary>
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="QTY" ShowInColumn="Cantidad" ShowInGroupFooterColumn="Cantidad" SummaryType="Sum" />
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="COST" ShowInColumn="Costo" ShowInGroupFooterColumn="Costo" SummaryType="Sum" />
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="CostTotal" ShowInColumn="Costo Total" ShowInGroupFooterColumn="Costo Total" SummaryType="Sum" />
                                            </TotalSummary>
                                            <Columns>
                                                <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowInCustomizationForm="True" VisibleIndex="0" Width="20px">
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn Caption="Codigo Sku" FieldName="CODE" ShowInCustomizationForm="True" VisibleIndex="1" Width="150px">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Description Sku" FieldName="DESCRIPTION" ShowInCustomizationForm="True" VisibleIndex="2">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Costo Total" FieldName="CostTotal" ShowInCustomizationForm="True" VisibleIndex="5" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Inventario" FieldName="QTY" ShowInCustomizationForm="True" VisibleIndex="3" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Costo" FieldName="COST" ShowInCustomizationForm="True" VisibleIndex="4" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                            </Columns>
                                            <Settings ShowFilterRow="True" ShowFooter="True" ShowTitlePanel="True"
                                                ShowFilterBar="Visible" ShowFilterRowMenu="True" />
                                            <SettingsPager Position="Bottom">
                                                <PageSizeItemSettings Items="10, 20, 50" Visible="True" />
                                            </SettingsPager>
                                            <Templates>
                                                <TitlePanel>
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: *">
                                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Inventario en Certificado" Font-Size="Large" Font-Bold="True"></dx:ASPxLabel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </TitlePanel>
                                            </Templates>
                                        </dx:ASPxGridView>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Text="Operación de Kardex">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    <dx:ASPxMenu ID="menOpciones" runat="server">
                                                        <Items>
                                                            <dx:MenuItem Text="" Name="btnExExel" ToolTip="Exportar a Exel">
                                                                <Image Url="~/Images/page_white_excel.png">
                                                                </Image>
                                                            </dx:MenuItem>
                                                            <dx:MenuItem Text="" Name="btnExPdf" ToolTip="Exportar a Pdf">
                                                                <Image Url="~/Images/file_extension_pdf.png">
                                                                </Image>
                                                            </dx:MenuItem>
                                                            <dx:MenuItem Name="btnSave" Text="" ToolTip="Grabar">
                                                                <Image Url="~/Images/save_as.png">
                                                                </Image>
                                                            </dx:MenuItem>
                                                        </Items>
                                                    </dx:ASPxMenu>
                                                    <dx:ASPxGridViewExporter ID="gridExportKardexOperation" runat="server" GridViewID="GridKardexCons"></dx:ASPxGridViewExporter>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <dx:ASPxDateEdit ID="dtFecha" runat="server" Caption="Fecha:" Width="150px"></dx:ASPxDateEdit>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <dx:ASPxLabel ID="lblErrorKardexCon" runat="server" ForeColor="Red"></dx:ASPxLabel>
                                                    <dx:ASPxLabel ID="lblInformation" runat="server"></dx:ASPxLabel>
                                                </td>
                                            </tr>
                                        </table>
                                        <dx:ASPxGridView ID="GridKardexCons" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="KardexId;CurrentBalace"
                                            ClientInstanceName="GridKardexCons">

                                            <TotalSummary>
                                                <dx:ASPxSummaryItem FieldName="Receipts" ShowInColumn="Ingresos" ShowInGroupFooterColumn="Ingresos" SummaryType="Sum" DisplayFormat="Total: {0:#,###,##0.00}" />
                                                <dx:ASPxSummaryItem FieldName="Dispactil" ShowInColumn="Egresos" ShowInGroupFooterColumn="Egresos" SummaryType="Sum" DisplayFormat="Total: {0:#,###,##0.00}" />
                                                <dx:ASPxSummaryItem FieldName="NewCurrentBalace" ShowInColumn="Saldo" ShowInGroupFooterColumn="Saldo" SummaryType="Sum" DisplayFormat="Total: {0:#,###,##0.00}" />
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="Cost" ShowInColumn="Costo Unitario" ShowInGroupFooterColumn="Costo Unitario" SummaryType="Sum" />
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="CostTotal" ShowInColumn="Valorización" ShowInGroupFooterColumn="Valorización" SummaryType="Sum" />
                                            </TotalSummary>
                                            <Columns>
                                                <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowInCustomizationForm="True" VisibleIndex="0" Width="20px">
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn Caption="Codigo" FieldName="KardexId" ShowInCustomizationForm="True" VisibleIndex="1">
                                                    <PropertiesTextEdit NullText="0">
                                                        <Style CssClass="DisplayNone"></Style>
                                                    </PropertiesTextEdit>
                                                    <FilterCellStyle CssClass="DisplayNone">
                                                    </FilterCellStyle>
                                                    <EditFormCaptionStyle CssClass="DisplayNone">
                                                    </EditFormCaptionStyle>
                                                    <HeaderStyle CssClass="DisplayNone" />
                                                    <CellStyle CssClass="DisplayNone">
                                                    </CellStyle>
                                                    <FooterCellStyle CssClass="DisplayNone"></FooterCellStyle>
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Codigo Certificado" FieldName="CertificadoId" ShowInCustomizationForm="True" VisibleIndex="2">
                                                    <PropertiesTextEdit NullText="0">
                                                        <Style CssClass="DisplayNone">
                                                </Style>
                                                    </PropertiesTextEdit>
                                                    <FilterCellStyle CssClass="DisplayNone">
                                                    </FilterCellStyle>
                                                    <EditFormCaptionStyle CssClass="DisplayNone">
                                                    </EditFormCaptionStyle>
                                                    <HeaderStyle CssClass="DisplayNone" />
                                                    <CellStyle CssClass="DisplayNone">
                                                    </CellStyle>
                                                    <FooterCellStyle CssClass="DisplayNone"></FooterCellStyle>
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Codigo SKU" FieldName="Sku" ShowInCustomizationForm="True" VisibleIndex="3" Width="150px">
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Descripción SKU" FieldName="SkuDescription" ShowInCustomizationForm="True" VisibleIndex="4">
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Inventario Actual" FieldName="CurrentBalace" ShowInCustomizationForm="True" VisibleIndex="5" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom"></PropertiesSpinEdit>

                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Ingresos" FieldName="Receipts" ShowInCustomizationForm="True" VisibleIndex="6" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Egresos" FieldName="Dispactil" ShowInCustomizationForm="True" VisibleIndex="7" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Nuevo Inventario" FieldName="NewCurrentBalace" ShowInCustomizationForm="True" VisibleIndex="8" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom"></PropertiesSpinEdit>

                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Valorización" ShowInCustomizationForm="True" VisibleIndex="10" FieldName="CostTotal" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Costo Unitario" ShowInCustomizationForm="True" VisibleIndex="9" FieldName="Cost" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataSpinEditColumn>
                                            </Columns>
                                            <Settings ShowFooter="True" ShowFilterRow="True" ShowTitlePanel="True"
                                                ShowFilterBar="Visible" ShowFilterRowMenu="True" />
                                            <SettingsEditing Mode="Batch" EditFormColumnCount="1"></SettingsEditing>
                                            <SettingsPager Position="Bottom">
                                                <PageSizeItemSettings Items="10, 20, 50" Visible="False" />
                                            </SettingsPager>
                                            <Templates>
                                                <TitlePanel>
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: *">
                                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Operación de Kardex" Font-Size="Large" Font-Bold="True"></dx:ASPxLabel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </TitlePanel>
                                            </Templates>
                                        </dx:ASPxGridView>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Text="Consulta de Kardex">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:ASPxMenu ID="menKardexTxns" runat="server">
                                            <Items>
                                                <dx:MenuItem Text="" Name="btnExExel" ToolTip="Exportar a Exel">
                                                    <Image Url="~/Images/page_white_excel.png">
                                                    </Image>
                                                </dx:MenuItem>
                                                <dx:MenuItem Text="" Name="btnExPdf" ToolTip="Exportar a Pdf">
                                                    <Image Url="~/Images/file_extension_pdf.png">
                                                    </Image>
                                                </dx:MenuItem>
                                            </Items>
                                        </dx:ASPxMenu>
                                        <table>
                                            <tr>
                                                <td colspan="2" class="auto-style1">
                                                    <dx:ASPxDateEdit ID="dtFechaInicio" runat="server" Caption="Fecha Inicio" ClientInstanceName="dtFechaInicio">
                                                        <%--<ValidationSettings ValidationGroup="ConsKardex" ErrorDisplayMode="ImageWithTooltip">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>--%>
                                                    </dx:ASPxDateEdit>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <dx:ASPxDateEdit ID="dtFechaFinal" runat="server" Caption="Fecha Final " ClientInstanceName="dtFechaFinal">
                                                        <%--<ValidationSettings ValidationGroup="ConsKardex" ErrorDisplayMode="ImageWithTooltip" ErrorText="Ingreso la fecha o La fecha no puede ser menor a la fecha de inicio.">
                                                            <RequiredField  ErrorText="Ingreso la fecha o La fecha no puede ser menor a la fecha de inicio." IsRequired="True"/></ValidationSettings>
                                                        <ClientSideEvents Validation="ValidateRangeDateConskardex" />--%>
                                                    </dx:ASPxDateEdit>
                                                </td>
                                                <td>
                                                    <dx:ASPxButton ID="btnBuscarKardexTxns" runat="server" Height="16px" Width="33px" >
                                                        <Image Height="17px" Url="~/Images/magnifier.png">
                                                        </Image>
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <dx:ASPxLabel ID="lblErrorKardexTxns" runat="server" ForeColor="Red"></dx:ASPxLabel>
                                                </td>
                                            </tr>
                                        </table>
                                        <dx:ASPxGridViewExporter ID="gridExportKardexTxns" runat="server" GridViewID="GridKardexTxns"></dx:ASPxGridViewExporter>
                                        <dx:ASPxGridView ID="GridKardexTxns" runat="server" KeyFieldName="TXNS_ID;CERTIFICATE_ID" AutoGenerateColumns="False" Width="100%"
                                            ClientInstanceName="GridKardexTxns">
                                            <TotalSummary>
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="TX_RECEIPTS" ShowInColumn="Ingreso" SummaryType="Sum" />
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="TX_DISPACTIL" ShowInColumn="Egreso" SummaryType="Sum" />
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="TX_LAST_BALACE" ShowInColumn="Inventario Anterior" SummaryType="Sum" />
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="TX_CURRENT_BALANCE" ShowInColumn="Nuevo Inventario" SummaryType="Sum" />
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="COST" ShowInColumn="Costo Unitario" SummaryType="Sum" />
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="Valorization" ShowInColumn="Valorización" SummaryType="Sum" />
                                            </TotalSummary>
                                            <GroupSummary>
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="TX_RECEIPTS" ShowInGroupFooterColumn="Ingreso" SummaryType="Sum" />
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="TX_DISPACTIL" ShowInGroupFooterColumn="Egreso" SummaryType="Sum" />
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="TX_LAST_BALACE" ShowInGroupFooterColumn="Inventario Anterior" SummaryType="Sum" />
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="TX_CURRENT_BALANCE" ShowInGroupFooterColumn="Nuevo Inventario" SummaryType="Sum" />
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="COST" ShowInGroupFooterColumn="Costo Unitario" SummaryType="Sum" />
                                                <dx:ASPxSummaryItem DisplayFormat="Total: {0:#,###,##0.00}" FieldName="Valorization" ShowInGroupFooterColumn="Valorización" SummaryType="Sum" />
                                            </GroupSummary>
                                            <Columns>
                                                <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowInCustomizationForm="True" VisibleIndex="0" Width="20px">
                                                </dx:GridViewCommandColumn>
                                                <%--<dx:GridViewDataTextColumn Caption="Codigo" FieldName="TXNS_ID" ShowInCustomizationForm="True" VisibleIndex="1">
                                                    <PropertiesTextEdit NullText="0">
                                                        <Style CssClass="DisplayNone"></Style>
                                                    </PropertiesTextEdit>
                                                    <FilterCellStyle CssClass="DisplayNone">
                                                    </FilterCellStyle>
                                                    <EditFormCaptionStyle CssClass="DisplayNone">
                                                    </EditFormCaptionStyle>
                                                    <HeaderStyle CssClass="DisplayNone" />
                                                    <CellStyle CssClass="DisplayNone">
                                                    </CellStyle>
                                                    <FooterCellStyle CssClass="DisplayNone"></FooterCellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Codigo Certificado" FieldName="CERTIFICATE_ID" ShowInCustomizationForm="True" VisibleIndex="2">
                                                    <PropertiesTextEdit NullText="0">
                                                        <Style CssClass="DisplayNone"></Style>
                                                    </PropertiesTextEdit>
                                                    <FilterCellStyle CssClass="DisplayNone">
                                                    </FilterCellStyle>
                                                    <EditFormCaptionStyle CssClass="DisplayNone">
                                                    </EditFormCaptionStyle>
                                                    <HeaderStyle CssClass="DisplayNone" />
                                                    <CellStyle CssClass="DisplayNone">
                                                    </CellStyle>
                                                    <FooterCellStyle CssClass="DisplayNone"></FooterCellStyle>
                                                </dx:GridViewDataTextColumn>--%>
                                                <dx:GridViewDataDateColumn Caption="Fecha de Operación" FieldName="TX_DATE" ShowInCustomizationForm="True" VisibleIndex="5" Width="75px">
                                                    <PropertiesDateEdit DisplayFormatString="g">
                                                    </PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataDateColumn Caption="Fecha de Transacción" FieldName="TX_CREATED" ShowInCustomizationForm="True" VisibleIndex="6" Width="150px">
                                                    <PropertiesDateEdit DisplayFormatString="g"></PropertiesDateEdit>
                                                </dx:GridViewDataDateColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Ingreso" FieldName="TX_RECEIPTS" ShowInCustomizationForm="True" VisibleIndex="7" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Egreso" FieldName="TX_DISPACTIL" ShowInCustomizationForm="True" VisibleIndex="8" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Inventario Anterior" FieldName="TX_LAST_BALACE" ShowInCustomizationForm="True" VisibleIndex="9" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Nuevo Inventario" FieldName="TX_CURRENT_BALANCE" ShowInCustomizationForm="True" VisibleIndex="10" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataTextColumn Caption="Codigo Sku" FieldName="SKU" ShowInCustomizationForm="True" VisibleIndex="3" Width="150px">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Descripción Sku" FieldName="SKU_DESCRIPTION" ShowInCustomizationForm="True" VisibleIndex="4">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Valorización" ShowInCustomizationForm="True" VisibleIndex="12" FieldName="Valorization" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Costo Unitario" ShowInCustomizationForm="True" VisibleIndex="11" FieldName="COST" Width="150px">
                                                    <PropertiesSpinEdit DisplayFormatString="#,###,##0.00" NumberFormat="Custom">
                                                    </PropertiesSpinEdit>
                                                </dx:GridViewDataSpinEditColumn>
                                            </Columns>
                                            <Settings ShowFooter="True" ShowFilterRow="True" ShowGroupPanel="True" ShowTitlePanel="True"
                                                ShowFilterBar="Visible" ShowFilterRowMenu="True" ShowGroupFooter="VisibleIfExpanded" />
                                            <SettingsPager Position="Bottom">
                                                <PageSizeItemSettings Items="10, 20, 50" Visible="True" />
                                            </SettingsPager>
                                            <Templates>
                                                <TitlePanel>
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: *">
                                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Consulta Kardex" Font-Size="Large" Font-Bold="True"></dx:ASPxLabel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </TitlePanel>
                                            </Templates>
                                        </dx:ASPxGridView>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                        </TabPages>
                    </dx:ASPxPageControl>
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
