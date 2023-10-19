using ClosedXML.Excel;
using Newtonsoft.Json;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Dtos;
using OnlineMuhasebeServer.Persistance.Context;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace OnlineMuhasebeServer.RabbitMQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://ytudmobq:Qn8kAlEK0p0Y-omldVZw0ZXzoYY0SR7a@sparrow.rmq.cloudamqp.com/ytudmobq");

            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare("Reports", true, false, false);

            var consumer = new EventingBasicConsumer(channel);

            channel.BasicConsume("Reports", true, consumer);

            consumer.Received += Consumer_Recieved;
            Console.ReadLine();
        }

        static void ReadQueue()
        {

        }

        private static void Consumer_Recieved(object? sender, BasicDeliverEventArgs e)
        {
            string reportString = Encoding.UTF8.GetString(e.Body.ToArray());
            ReportDto reportDto = JsonConvert.DeserializeObject<ReportDto>(reportString);

            if (reportDto.Name == "Hesap planı")
            {
                CreateUCAFExcel(reportDto);
            }
        }
        public static void CreateUCAFExcel(ReportDto reportDto)
        {
            Context.AppDbContext appDbContext = new();

            Company company = appDbContext.Set<Company>().Find(reportDto.CompanyId);

            CompanyDbContext companyDbContext = new(company);

            IList<UniformChartOfAccount> ucaf = companyDbContext.Set<UniformChartOfAccount>().OrderBy(p => p.Code).ToList();

            string fileName;
            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("HesapPlanı");
                ws.Range("A1").Value = company.Name + "Hesap planı";
                ws.Range("A1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Range("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Range("A1").Style.Font.FontSize = 20;

                ws.Range("A3").Value = "Kod";

                ws.Range("A1:C1").Merge();

                ws.Range("B3").Value = "Tip";
                ws.Range("C3").Value = "Adı";

                int rowCount = 4;
                for (int i = 0; i < ucaf.Count(); i++)
                {
                    ws.Range("A" + rowCount).Value = ucaf[i].Code;
                    ws.Range("B" + rowCount).Value = ucaf[i].Type.ToString();
                    ws.Range("C" + rowCount).Value = ucaf[i].Name;

                    if (ucaf[i].Type.ToString()=="A")
                        ws.Range($"A{rowCount}:C{rowCount}").Style.Font.FontColor=XLColor.Red;
                    else if(ucaf[i].Type.ToString() == "G")
                        ws.Range($"A{rowCount}:C{rowCount}").Style.Font.FontColor = XLColor.Blue;

                    rowCount++;
                }

                ws.Range("A:C").Style.Font.Bold = true;
                ws.Columns("A:C").AdjustToContents();

                int lastrow = ws.LastRowUsed().RowNumber();

                ws.Range($"A3:C{lastrow}").Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range($"A3:C{lastrow}").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Range($"A3:C{lastrow}").Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range($"A3:C{lastrow}").Style.Border.LeftBorder = XLBorderStyleValues.Thin;

                fileName = ($"HesapPlani.{company.Id}.{DateTime.Now}.xlsx").Replace(":", ".");
                string filepath = $"C:/Users/Administrator/source/repos/FAArik/OnlineMuhasebe/OnlineMuhasebeClient/src/assets/reports/{fileName}";
                workbook.SaveAs(filepath);
            }
            Report report = companyDbContext.Set<Report>().Find(reportDto.Id);
            report.FileUrl = fileName;
            report.Status = true;
            report.UpdatedDate = DateTime.Now;

            companyDbContext.Update(report);
            companyDbContext.SaveChanges();
            Console.Write("Excel başarıyla oluşturuldu!");
        }
    }
}