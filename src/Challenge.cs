// DESAFIO: Gerador de Relatórios Complexos
// PROBLEMA: Sistema precisa gerar diferentes tipos de relatórios (PDF, Excel, HTML)
// com múltiplas configurações opcionais (cabeçalho, rodapé, gráficos, tabelas, filtros)
// O código atual usa construtores enormes ou muitos setters, tornando difícil criar relatórios

using System;
using System.Collections.Generic;

namespace DesignPatternChallenge
{
    // Contexto: Sistema de BI que gera relatórios customizados para diferentes departamentos
    // Cada relatório pode ter dezenas de configurações opcionais
    
    public class SalesReport
    {
        public string Title { get; set; }
        public string Format { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IncludeHeader { get; set; }
        public bool IncludeFooter { get; set; }
        public string HeaderText { get; set; }
        public string FooterText { get; set; }
        public bool IncludeCharts { get; set; }
        public string ChartType { get; set; }
        public bool IncludeSummary { get; set; }
        public List<string> Columns { get; set; }
        public List<string> Filters { get; set; }
        public string SortBy { get; set; }
        public string GroupBy { get; set; }
        public bool IncludeTotals { get; set; }
        public string Orientation { get; set; }
        public string PageSize { get; set; }
        public bool IncludePageNumbers { get; set; }
        public string CompanyLogo { get; set; }
        public string WaterMark { get; set; }

        // Problema: Construtor telescópico (muitos parâmetros)
        public SalesReport(
            string title,
            string format,
            DateTime startDate,
            DateTime endDate,
            bool includeHeader,
            bool includeFooter,
            string headerText,
            string footerText,
            bool includeCharts,
            string chartType,
            bool includeSummary,
            List<string> columns,
            List<string> filters,
            string sortBy,
            string groupBy,
            bool includeTotals,
            string orientation,
            string pageSize,
            bool includePageNumbers,
            string companyLogo,
            string waterMark)
        {
            Title = title;
            Format = format;
            StartDate = startDate;
            EndDate = endDate;
            IncludeHeader = includeHeader;
            IncludeFooter = includeFooter;
            HeaderText = headerText;
            FooterText = footerText;
            IncludeCharts = includeCharts;
            ChartType = chartType;
            IncludeSummary = includeSummary;
            Columns = columns;
            Filters = filters;
            SortBy = sortBy;
            GroupBy = groupBy;
            IncludeTotals = includeTotals;
            Orientation = orientation;
            PageSize = pageSize;
            IncludePageNumbers = includePageNumbers;
            CompanyLogo = companyLogo;
            WaterMark = waterMark;
        }

        // Alternativa problemática: Construtor vazio + setters
        public SalesReport()
        {
            Columns = new List<string>();
            Filters = new List<string>();
        }

        public void Generate()
        {
            Console.WriteLine($"\n=== Gerando Relatório: {Title} ===");
            Console.WriteLine($"Formato: {Format}");
            Console.WriteLine($"Período: {StartDate:dd/MM/yyyy} a {EndDate:dd/MM/yyyy}");
            
            if (IncludeHeader)
                Console.WriteLine($"Cabeçalho: {HeaderText}");
            
            if (IncludeCharts)
                Console.WriteLine($"Gráfico: {ChartType}");
            
            Console.WriteLine($"Colunas: {string.Join(", ", Columns)}");
            
            if (Filters.Count > 0)
                Console.WriteLine($"Filtros: {string.Join(", ", Filters)}");
            
            if (!string.IsNullOrEmpty(GroupBy))
                Console.WriteLine($"Agrupado por: {GroupBy}");
            
            if (IncludeFooter)
                Console.WriteLine($"Rodapé: {FooterText}");
            
            Console.WriteLine("Relatório gerado com sucesso!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Relatórios (Com Builder) ===");

            // Solução 1: Criação fluente e legível
            var report1 = new SalesReportBuilder()
                .WithTitle("Vendas Mensais")
                .WithFormat("PDF")
                .WithDateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 31))
                .IncludeHeader("Relatório de Vendas")
                .IncludeFooter("Confidencial")
                .IncludeCharts("Bar")
                .IncludeSummary()
                .AddColumns("Produto", "Quantidade", "Valor")
                .AddFilter("Status=Ativo")
                .SortBy("Valor")
                .GroupBy("Categoria")
                .IncludeTotals()
                .SetOrientation("Portrait")
                .SetPageSize("A4")
                .IncludePageNumbers()
                .SetCompanyLogo("logo.png")
                .SetWaterMark("Confidencial")
                .Build();

            report1.Generate();

            // Solução 2: Previne esquecimento de configurações (se validado no Build)
            var report2 = new SalesReportBuilder()
                .WithTitle("Relatório Trimestral")
                .WithFormat("Excel")
                .WithDateRange(new DateTime(2024, 1, 1), new DateTime(2024, 3, 31))
                .AddColumns("Vendedor", "Região", "Total")
                .IncludeCharts("Line")
                .IncludeHeader("Relatório Trimestral") // Agora explícito
                .GroupBy("Região")
                .IncludeTotals()
                .Build();

            report2.Generate();

            // Solução 3: Reuso de configurações (Pattern Prototype ou apenas reutilizando o builder)
            // Aqui podemos criar um método que retorna um builder pré-configurado
            var builderPadrao = new SalesReportBuilder()
                .WithFormat("PDF")
                .IncludeHeader("Relatório de Vendas")
                .IncludeFooter("Confidencial")
                .SetOrientation("Landscape")
                .SetPageSize("A4");

            var report3 = builderPadrao
                .WithTitle("Vendas Anuais")
                .WithDateRange(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31))
                .AddColumns("Produto", "Quantidade", "Valor")
                .IncludeCharts("Pie")
                .IncludeTotals()
                .Build();

            report3.Generate();

             Console.WriteLine("\nRelatórios gerados com o padrão Builder!");
        }
    }
}
