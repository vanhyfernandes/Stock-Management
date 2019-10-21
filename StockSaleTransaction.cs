using System;

public class StockSaleTransaction : Transaction{

    public StockSaleTransaction(Stock stock, int quantity, decimal price) : base(stock, quantity, price){}

    override
    public void Execute(){
        base.Execute();
    }

    override
    public void PrintSummary(){
        Console.WriteLine(base.SummaryLine);
    }

}