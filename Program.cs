using System;

public enum MenuOption{
    RegisterNewStockItem,
    BuyStock,
    SellStock,
    QueryStock,
    AdjustStock,
    TransactionHistory,
    Quit,
}
public class Program
{
    public static void Main()
    {
        Warehouse warehouse = new Warehouse();

        MenuOption option;
        
        do{
            option = ReadUserOption();
            switch(option){
                case MenuOption.RegisterNewStockItem:
                    RegisterNewStockItem(warehouse);
                    break;
                case MenuOption.BuyStock:
                    PerformPurchaseStock(warehouse);
                    break;
                case MenuOption.SellStock:
                    PerformSellStock(warehouse);
                    break;
                case MenuOption.QueryStock:
                    QueryStock(warehouse);
                    break;
                case MenuOption.AdjustStock:
                    PerformAdjustStock(warehouse);
                    break;
                case MenuOption.TransactionHistory:
                    PrintTransactionHistory(warehouse);
                    break;
                default:
                    Console.WriteLine("Thanks!");
                    break;
            }
        }while(option != MenuOption.Quit);
        
    }


    private static MenuOption ReadUserOption() {

        int option;

        Console.WriteLine();
        Console.WriteLine("Menu");
        Console.WriteLine("1 - Register New Stock Item");
        Console.WriteLine("2 - Buy Stock");
        Console.WriteLine("3 - Sell Stock");
        Console.WriteLine("4 - Query Stock");
        Console.WriteLine("5 - Adjust Stock");
        Console.WriteLine("6 - Transaction History");
        Console.WriteLine("7 - Quit");

        do{
            Console.WriteLine("Choose an option: ");
            try{
                option = Convert.ToInt32(Console.ReadLine());
            }catch{
                option = -1;
            }

            if(option < 1 || option > 6){
                Console.WriteLine("Please select an option between 1 and 7!");
            }

        }while(option < 1 || option > 6);


        return (MenuOption)(option - 1);
    }

    private static void PerformPurchaseStock(Warehouse toWarehouse){
        int quantity;
        decimal price;
        Console.WriteLine("---- PURCHASE STOCK ----");

        Stock stock = FindStockItem(toWarehouse);
        if(stock == null)
            return;

        quantity = ReadInteger($"Quantity of {stock.Name}: ");
        price = ReadDecimal("Price: ");

        StockPurchaseTransaction purchase = new StockPurchaseTransaction(stock, quantity, price);
        toWarehouse.ExecuteTransaction(purchase);
        purchase.PrintSummary();
    }

    private static void PerformSellStock(Warehouse toWarehouse){
        int quantity;
        decimal price;
        Console.WriteLine("---- SELL STOCK ----");

        Stock stock = FindStockItem(toWarehouse);
        if(stock == null)
            return;

        quantity = ReadInteger($"Quantity of {stock.Name} sold: ");
        price = ReadDecimal("Price: ");

        StockSaleTransaction sale = new StockSaleTransaction(stock, quantity, price);
        toWarehouse.ExecuteTransaction(sale);
        sale.PrintSummary();
    }

    private static void PerformAdjustStock(Warehouse toWarehouse){
        int quantity=0;
        decimal price=0;
        Console.WriteLine("---- ADJUST STOCK ----");

        Stock stock = FindStockItem(toWarehouse);
        if(stock == null)
            return;

        quantity = ReadInteger($"Quantity of {stock.Name} to adjust: ");
        price = ReadDecimal("Price: ");



        StockAdjustmentTransaction adj = new StockAdjustmentTransaction(stock, quantity,price);
        toWarehouse.ExecuteTransaction(adj);
        adj.PrintSummary();
    }

    private static void QueryStock(Warehouse toWarehouse){
        Stock stock = FindStockItem(toWarehouse);
        if(stock == null)
            return;
        stock.PrintSummary();
    }


    private static void RegisterNewStockItem(Warehouse warehouse){
        Console.WriteLine("---- NEW STOCK ITEM ----");
        Stock stock = new Stock(ReadString("Name: "), ReadString("Code: "), ReadInteger("Initial level: "));
        warehouse.AddStockItem(stock);

    }

    private static Stock FindStockItem(Warehouse fromWarehouse){
        Console.WriteLine("---- FIND STOCK ITEM ----");
        string code = ReadString("Enter stock code: ");
        Stock result = fromWarehouse.GetStockItem(code);
        if(result == null)
            Console.WriteLine($"No stock found with code {code}");
        
        return result;
    }

    public static void PrintTransactionHistory(Warehouse warehouse){
        warehouse.PrintTransactionHistory();
    }

    public static int ReadInteger(string prompt){
        int number=-1;

        Console.WriteLine(prompt);
        do{
            try{
                number = Int32.Parse(Console.ReadLine());
            } catch{
                number = -1;
            }

            if(number < 0)
                Console.WriteLine("Please enter a number greater than 0");

        }while(number <= 0);
        
        return number;
    }

    public static decimal ReadDecimal(string prompt){
        Console.WriteLine(prompt);
        while(true){
            try{
                return Decimal.Parse(Console.ReadLine());
            } catch{
                Console.WriteLine("Please enter a valid number!");
            }
        }
    }

    public static string ReadString(string prompt){
        string read=null;

        Console.WriteLine(prompt);
        do{
           read = Console.ReadLine();
        }while(read == null);
        
        return read;
    }
}
