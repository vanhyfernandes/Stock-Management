using System;

public abstract class Transaction{
    protected Stock _stock { get; }
    protected decimal _price { get; }
    protected int _quantity { get; }
    protected DateTime _dateStamp { get; set; }
    private bool _hasExecuted = false;
    private bool _success = false;

    public bool Success{
        get { return _success; }
    }

    public bool HasExecuted{
        get { return _hasExecuted; }
    }

    protected string SummaryLine{
        get{ 
            if(!HasExecuted){
                return $"FAILED - {_stock.Name} x {_quantity} @ ${_price}";
            }

            return $"PROPOSED - {_stock.Name} x {_quantity} @ ${_price}";            
        }
    }

    public Transaction(Stock stock, int quantity, decimal price){
        _stock = stock;
        _quantity = quantity;
        _price = price;
    }

    public virtual void Execute(){
        _dateStamp = DateTime.Now;
        if(HasExecuted){
            throw new InvalidOperationException("Exception - Invalid Operation!");
        }
        _hasExecuted = true;
        _success = _stock.RemoveStock(_quantity);
    }

    public abstract void PrintSummary();

}