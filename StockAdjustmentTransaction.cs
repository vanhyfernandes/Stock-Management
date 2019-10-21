using System;

public class StockAdjustmentTransaction : Transaction{
   public StockAdjustmentTransaction(Stock stock, int quantity, decimal price) : base(stock, quantity, price){}

    override
    public void Execute(){
        base.Execute();
    }

    override
    public void PrintSummary(){
        Console.WriteLine(base.SummaryLine);
    }

}