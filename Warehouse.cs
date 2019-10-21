using System.Collections.Generic;
using System;

public class Warehouse{
    private List<Stock> _stockItems = new List<Stock>();

    private List<Transaction> _transactions = new List<Transaction>();

    public void AddStockItem(Stock stock){
        _stockItems.Add(stock);
    }

    public  Stock GetStockItem(string code){
        foreach(Stock item in _stockItems){
            if(item.Code == code){
                return item;
            }
        }
        return null;
    }

    public void ExecuteTransaction(Transaction transaction){
        _transactions.Add(transaction);
        transaction.Execute();
    }

    public void PrintTransactionHistory(){
        if(_transactions.Count == 0)
            Console.WriteLine("No transactions!");
        else{
            foreach(Transaction transaction in _transactions){
                transaction.PrintSummary();
            }
        }
    }
    
}