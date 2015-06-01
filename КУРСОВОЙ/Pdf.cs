using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp;
using System.IO;
using iTextSharp.text.pdf;

namespace КУРСОВОЙ
{
    class Pdf
    {
        
   //     public string way_dog = @"C:\Users\Ольга\Documents\Visual Studio 2010\Projects\КУРСОВОЙ\КУРСОВОЙ\Отчёт\";
        public void PDF(string fileName = "Накладная № ")
        {
            var x = Program.db2.Zapros(0);
            int nomer = 0;
            var doc = new Document();
            foreach (Товары tov in x)
            {
                x.Last();
                nomer = tov.id_товара;
            }
            PdfWriter.GetInstance(doc, new FileStream(fileName.ToString() + "Накладная №" + nomer.ToString() + @".pdf", FileMode.Create));
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Users\Ольга\ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            //////////
            iTextSharp.text.Phrase j0 = new Phrase("НАКЛАДНАЯ ",
           new iTextSharp.text.Font(baseFont, 20,
           iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a0 = new Paragraph(j0);
            a0.Alignment = Element.ALIGN_CENTER;
            a0.SpacingAfter = 10;

            iTextSharp.text.Phrase j1 = new Phrase("Вам необходимо оплатить " + Math.Ceiling(Program.k) + " рулонов",
           new iTextSharp.text.Font(baseFont, 12,
           iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a1 = new Paragraph(j1);
            a1.SpacingAfter = 10;

            iTextSharp.text.Phrase j2 = new Phrase("стоимостью " + Program.s + "рублей",
           new iTextSharp.text.Font(baseFont, 12,
           iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a2 = new Paragraph(j2);
            a2.SpacingAfter = 10;

            iTextSharp.text.Phrase j3 = new Phrase("Клиент: " + Program.FIO,
          new iTextSharp.text.Font(baseFont, 12,
          iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a3 = new Paragraph(j3);
            a3.SpacingAfter = 10;

            iTextSharp.text.Phrase j4 = new Phrase("Подпись клиента: " ,
          new iTextSharp.text.Font(baseFont, 12,
          iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a4 = new Paragraph(j4);
            a4.SpacingAfter = 10;

            iTextSharp.text.Phrase j5 = new Phrase("Почта: " + Program.mail,
          new iTextSharp.text.Font(baseFont, 12,
          iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a5 = new Paragraph(j5);
            a5.SpacingAfter = 10;

            iTextSharp.text.Phrase j6 = new Phrase("Дата: " + DateTime.Now,
          new iTextSharp.text.Font(baseFont, 12,
          iTextSharp.text.Font.BOLD, new BaseColor(Color.Black)));
            Paragraph a6 = new Paragraph(j6);
            a6.SpacingAfter = 10;

            doc.Add(a0);
            doc.Add(a1);
            doc.Add(a2);
            doc.Add(a3);
            doc.Add(a4);
            doc.Add(a5);
            doc.Add(a6);
            MessageBox.Show("создан");
            doc.Close();
        }
    }
}
