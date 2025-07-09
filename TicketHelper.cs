using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LosPatosSystem
{
    class TicketHelper
    {
        public static void ImprimirTicket(string texto)
        {
            string impresora = ConfiguracionGlobal.ImpresoraTickets;

            if (string.IsNullOrEmpty(impresora))
            {
                MessageBox.Show("No hay impresora de tickets configurada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintDocument doc = new PrintDocument();
            doc.PrinterSettings.PrinterName = impresora;

            doc.PrintPage += (sender, e) =>
            {
                Font fuente = new Font("Arial", 10);
                float y = 10;

                // Soporta varias líneas
                foreach (string linea in texto.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None))
                {
                    e.Graphics.DrawString(linea, fuente, Brushes.Black, new PointF(10, y));
                    y += fuente.GetHeight(e.Graphics);
                }
            };

            try
            {
                doc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message, "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
