
using FastReport;
using FastReport.Preview;
using LosPatosSystem.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LosPatosSystem.Forms.ReportesForms
{
    public partial class ReportesVista: Form
    {
        private ReporteDAO reporteDAO = new ReporteDAO();

        public ReportesVista()
        {
            InitializeComponent();
        }

        private void ReportesVista_Load(object sender, EventArgs e)
        {

            
        }

        private void ExportarAExcel(DataGridView dgv)
        {
            try
            {
                ExcelPackage.License.SetNonCommercialPersonal("Citlalli");

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                    saveFileDialog.Title = "Guardar como archivo Excel";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        using (ExcelPackage package = new ExcelPackage())
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Datos");

                            // Escribir encabezados
                            for (int col = 0; col < dgv.Columns.Count; col++)
                            {
                                worksheet.Cells[1, col + 1].Value = dgv.Columns[col].HeaderText;
                                worksheet.Cells[1, col + 1].Style.Font.Bold = true;
                            }

                            // Escribir los datos
                            for (int row = 0; row < dgv.Rows.Count; row++)
                            {
                                for (int col = 0; col < dgv.Columns.Count; col++)
                                {
                                    var value = dgv.Rows[row].Cells[col].Value;
                                    worksheet.Cells[row + 2, col + 1].Value = value != null ? value.ToString() : "";
                                }
                            }

                            // Ajustar el ancho de las columnas
                            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                            // Guardar archivo
                            FileInfo file = new FileInfo(saveFileDialog.FileName);
                            package.SaveAs(file);

                            MessageBox.Show("Archivo Excel generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReporteVentas_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFechaInicio.Value > dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaInicio.Value == dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser igual a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaInicio.Value != null && dtpFechaFin.Value != null)
                {
                    DataSet ds = reporteDAO.ObtenerReporteVentas(dtpFechaInicio.Value, dtpFechaFin.Value);
                    dgvReporte.DataSource = ds.Tables["VentasDTO"];
                    dgvReporte.Columns["IdVenta"].Visible = false;
                    dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvReporte.Columns["Precio"].DefaultCellStyle.Format = "C2";
                    dgvReporte.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                    dgvReporte.Columns["Total"].DefaultCellStyle.Format = "C2";
                }
                else
                {
                    MessageBox.Show("Por favor seleccione las fechas de inicio y fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProductosMasVendidos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFechaInicio.Value > dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaInicio.Value == dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser igual a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaInicio.Value != null && dtpFechaFin.Value != null)
                {
                    DataSet ds = reporteDAO.ObtenerProductosMasVendidos(dtpFechaInicio.Value, dtpFechaFin.Value);
                    dgvReporte.DataSource = ds.Tables["ProductosDTO"];
                    dgvReporte.Columns["IdProducto"].Visible = false;
                }
                else
                {
                    MessageBox.Show("Por favor seleccione las fechas de inicio y fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de productos más vendidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVentasPromociones_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFechaInicio.Value > dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaInicio.Value == dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser igual a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaInicio.Value != null && dtpFechaFin.Value != null)
                {
                    DataSet ds = reporteDAO.ObtenerReporteVentasPromociones(dtpFechaInicio.Value, dtpFechaFin.Value);
                    dgvReporte.DataSource = ds.Tables["VentasPromocionesDTO"];
                    dgvReporte.Columns["IdVenta"].Visible = false;
                    dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvReporte.Columns["Total"].DefaultCellStyle.Format = "C2";
                }
                else
                {
                    MessageBox.Show("Por favor seleccione las fechas de inicio y fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de ventas con promociones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReporteCompras_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFechaInicio.Value > dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaInicio.Value == dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser igual a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaInicio.Value != null && dtpFechaFin.Value != null)
                {
                    DataSet ds = reporteDAO.ObtenerReporteComprasFecha(dtpFechaInicio.Value, dtpFechaFin.Value);
                    dgvReporte.DataSource = ds.Tables["ComprasDTO"];
                    dgvReporte.Columns["IdCompra"].Visible = false;
                    dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvReporte.Columns["Precio"].DefaultCellStyle.Format = "C2";
                    dgvReporte.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                    dgvReporte.Columns["Total"].DefaultCellStyle.Format = "C2";
                }
                else
                {
                    MessageBox.Show("Por favor seleccione las fechas de inicio y fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de compras: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnBalanceDiario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFechaInicio.Value > dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaInicio.Value == dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser igual a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaInicio.Value != null && dtpFechaFin.Value != null)
                {
                    DataSet ds = reporteDAO.ObtenerReporteBalanceDiario(dtpFechaInicio.Value, dtpFechaFin.Value);
                    dgvReporte.DataSource = ds.Tables["BalanceDiarioDTO"];
                    dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvReporte.Columns["Ingresos"].DefaultCellStyle.Format = "C2";
                    dgvReporte.Columns["Egresos"].DefaultCellStyle.Format = "C2";
                    dgvReporte.Columns["Balance"].DefaultCellStyle.Format = "C2";
                }
                else
                {
                    MessageBox.Show("Por favor seleccione las fechas de inicio y fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de balance diario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFechaInicio.Value > dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaInicio.Value == dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser igual a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaInicio.Value != null && dtpFechaFin.Value != null)
                {
                    DataSet ds = reporteDAO.ObtenerReporteDevoluciones(dtpFechaInicio.Value, dtpFechaFin.Value);
                    dgvReporte.DataSource = ds.Tables["DevolucionesDTO"];
                    dgvReporte.Columns["IdDevolucion"].Visible = false;
                    dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvReporte.Columns["Precio"].DefaultCellStyle.Format = "C2";
                    dgvReporte.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                    dgvReporte.Columns["Total"].DefaultCellStyle.Format = "C2";
                }
                else
                {
                    MessageBox.Show("Por favor seleccione las fechas de inicio y fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de devoluciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportarAExcel(dgvReporte);
        }

        private void btnRetornos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFechaInicio.Value > dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaInicio.Value == dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser igual a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaInicio.Value != null && dtpFechaFin.Value != null)
                {
                    DataSet ds = reporteDAO.ObtenerReporteEnvases(dtpFechaInicio.Value, dtpFechaFin.Value);
                    dgvReporte.DataSource = ds.Tables["EnvasesDTO"];
                    dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvReporte.Columns["Monto"].DefaultCellStyle.Format = "C2";
                    dgvReporte.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                    dgvReporte.Columns["Total"].DefaultCellStyle.Format = "C2";
                }
                else
                {
                    MessageBox.Show("Por favor seleccione las fechas de inicio y fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de los envases: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
