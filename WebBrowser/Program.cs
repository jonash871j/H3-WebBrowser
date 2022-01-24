using HtmlAgilityPack;

namespace WebBrowser
{
    class Program
    {
        public static async Task Main()
        {
            string url = "https://www.york.ac.uk/teaching/cws/wws/webpage1.html";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Web browser\n");
                Console.WriteLine("a. Show raw html");
                Console.WriteLine("b. Show html in simplified format\n");
                Console.Write("Choice: ");
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case 'a':
                        string rawHtml = await WebBrowserHandler.GetRawHtml(url);
                        Console.WriteLine(rawHtml);
                        break;
                    case 'b':
                        HtmlDocument htmlDocument = await WebBrowserHandler.GetHtmlDocument(url);
                        PrintHtmlInSimplifiedFormat(htmlDocument.DocumentNode.ChildNodes);
                        break;
                    default:
                        Console.WriteLine("Not a valid choice");
                        break;
                }
                
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public static void PrintHtmlInSimplifiedFormat(HtmlNodeCollection childNodes)
        {
            // Goes though each html node and prints selected tags
            foreach (HtmlNode node in childNodes)
            {
                if (node.HasChildNodes)
                {
                    PrintHtmlInSimplifiedFormat(node.ChildNodes);
                }
                PrintTagContent(node.OriginalName.ToLower(), node.InnerText);
            }
        }

        public static void PrintTagContent(string tag, string text)
        {
            switch (tag)
            {
                case "h1":
                    WriteColorLine(ConsoleColor.Red, text);
                    break;
                case "h2":
                    WriteColorLine(ConsoleColor.Yellow, text);
                    break;
                case "h3":
                    WriteColorLine(ConsoleColor.Green, text);
                    break;
                case "h4":
                    WriteColorLine(ConsoleColor.Cyan, text);
                    break;
                case "h5":
                    WriteColorLine(ConsoleColor.Blue, text);
                    break;
                case "h6":
                    WriteColorLine(ConsoleColor.Magenta, text);
                    break;
                case "p":
                    WriteColorLine(ConsoleColor.White, text);
                    break;
                case "li":
                    WriteColorLine(ConsoleColor.White, $"- {text}");
                    break;
                case "a":
                    WriteColorLine(ConsoleColor.DarkBlue, text);
                    break;
                default:
                    break;
            }
        }

        public static void WriteColorLine(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}