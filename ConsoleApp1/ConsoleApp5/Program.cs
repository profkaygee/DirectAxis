using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var certifcatePAth = "C:\\CoreVasionProjects\\Nuddle\\Nuddle\\Nuddle.Shop\\Templates\\SupplierCertificationTemplates\\Certificate II.pdf";
            var destination = $"C:\\CoreVasionProjects\\Nuddle\\Nuddle\\Nuddle.Shop\\Templates\\SupplierCertificationTemplates\\Certificate_CoreVaison_3.pdf";

            PdfDocument pdfDoc = new PdfDocument(new PdfReader(certifcatePAth), new PdfWriter(destination));
            // add content

            var page = pdfDoc.GetFirstPage();
            String text = "Nuddle PTY LTD";
            var paragraph = new Paragraph(text).
                  SetMargin(0).
                  SetMultipliedLeading(1).
                  SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ITALIC));
            float fontSize = 40;
            paragraph.SetFontSize(fontSize);
            float allowedWidth = 300;
            Canvas canvas = new Canvas(new PdfCanvas(page), page.GetMediaBox());
            paragraph.SetWidth(allowedWidth);
            canvas.ShowTextAligned(paragraph, 400, 270, iText.Layout.Properties.TextAlignment.CENTER);
            canvas.Close();

            String text1 = "Company Registration: 2015/2541215/07";
            var paragraph1 = new Paragraph(text1).
                  SetMargin(0).
                  SetMultipliedLeading(1).
                  SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ITALIC));
            float fontSize1 = 11;
            paragraph1.SetFontSize(fontSize1);
            float allowedWidth1 = 300;
            Canvas canvas1 = new Canvas(new PdfCanvas(page), page.GetMediaBox());
            paragraph1.SetWidth(allowedWidth1);
            canvas1.ShowTextAligned(paragraph1, 400, 250, iText.Layout.Properties.TextAlignment.CENTER);
            canvas1.Close();

            String text2 = "Supplier Code: CTPS-P-16608";
            var paragraph2 = new Paragraph(text2).
                  SetMargin(0).
                  SetMultipliedLeading(1).
                  SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ITALIC));
            float fontSize2 = 11;
            paragraph2.SetFontSize(fontSize2);
            float allowedWidth2 = 300;
            Canvas canvas2 = new Canvas(new PdfCanvas(page), page.GetMediaBox());
            paragraph2.SetWidth(allowedWidth2);
            canvas2.ShowTextAligned(paragraph2, 400, 235, iText.Layout.Properties.TextAlignment.CENTER);
            canvas2.Close();

            String text3 = "Date Of Award: 24 May 2021";
            var paragraph3 = new Paragraph(text3).
                  SetMargin(0).
                  SetMultipliedLeading(1).
                  SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ITALIC));
            float fontSize3 = 11;
            paragraph3.SetFontSize(fontSize3);
            float allowedWidth3 = 300;
            Canvas canvas3 = new Canvas(new PdfCanvas(page), page.GetMediaBox());
            paragraph3.SetWidth(allowedWidth3);
            canvas3.ShowTextAligned(paragraph3, 400, 220, iText.Layout.Properties.TextAlignment.CENTER);
            canvas3.Close();

            String text4 = "Expiration Date: 24 May 2022";
            var paragraph4 = new Paragraph(text4).
                  SetMargin(0).
                  SetMultipliedLeading(1).
                  SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ITALIC));
            float fontSize4 = 11;
            paragraph4.SetFontSize(fontSize4);
            float allowedWidth4 = 300;
            Canvas canvas4 = new Canvas(new PdfCanvas(page), page.GetMediaBox());
            paragraph4.SetWidth(allowedWidth4);
            canvas4.ShowTextAligned(paragraph4, 400, 205, iText.Layout.Properties.TextAlignment.CENTER);
            canvas4.Close();

            pdfDoc.Close();
        }
    }
}