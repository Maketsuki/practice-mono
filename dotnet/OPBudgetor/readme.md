# OPBudgetor 🏦

OPBudgetor is a sleek, client-side Blazor WebAssembly application designed to help you analyze your OP Bank (Osuuspankki) statements. It processes your PDF statements directly in your browser, ensuring your financial data never leaves your device.

## Features ✨

- **Privacy First**: All PDF parsing and analysis happen locally in your browser. No data is uploaded to any server.
- **Smart Parsing**: Automatically identifies transactions, dates, and amounts from OP Bank PDF statements.
- **Visual Analytics**: Interactive charts showing your expense distribution.
- **Financial Summary**: Quick insights into your total income, expenses, and net balance.
- **Multi-page Support**: Processes entire statement documents, no matter how many pages.

## How to Use 🚀

1.  **Download your statement**: Log in to your OP bank account and download your transaction statement as a PDF file.
2.  **Open OPBudgetor**: Run the application locally (or host it as a static site).
3.  **Upload**: Click on the upload area and select your PDF statement.
4.  **Analyze**: View your financial breakdown, charts, and transaction list instantly.

## Tech Stack 🛠️

- **Frontend**: [Blazor WebAssembly](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) (.NET 8)
- **PDF Processing**: [PdfPig](https://github.com/UglyToad/PdfPig)
- **Charts**: [ChartJs.Blazor.Fork](https://github.com/mmanela/ChartJs.Blazor)
- **Icons**: [Bootstrap Icons](https://icons.getbootstrap.com/)
- **Styling**: [Bootstrap 5](https://getbootstrap.com/) & Custom CSS

## Development 💻

To run the project locally:

```bash
cd dotnet/OPBudgetor
dotnet watch
```

## Troubleshooting 🔍

- **No transactions found**: Ensure the PDF is a standard transaction statement from OP. Compressed or password-protected PDFs might not be readable.
- **Incorrect amounts**: If the parsing misses certain transactions, check if your statement format has changed. The parser is optimized for standard Finnish OP statements.

---
*Disclaimer: This tool is not affiliated with Osuuspankki (OP Financial Group).*
