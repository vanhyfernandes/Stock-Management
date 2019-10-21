using System;

public class Stock{

    private string _name;

    private string _code;
    private int _quantityOnHand;

    public string Name{
        get { return _name; }
        set { _name = value; }
    }

    public int QuantityOnHand {
        get { return _quantityOnHand; }
        private set { _quantityOnHand = value; } 
    }

    public string Code{
        get { return _code; }
    }

    public Stock(string name, string code ,int initialLevel){
        _name = name;
        _code = code;
        _quantityOnHand = initialLevel;
    }

    public bool AddStock(int quantityAdd){
        if(quantityAdd > 0){
            _quantityOnHand += quantityAdd;
            return true;
        }
        return false;
    }

    public bool RemoveStock(int quantityRemove){
        if(quantityRemove > 0 && quantityRemove <= _quantityOnHand){
            _quantityOnHand -= quantityRemove;
            return true;
        }
        return false;
    }
    
     public void PrintSummary() {
        Console.WriteLine($"{Name}: {QuantityOnHand}"); 
    }

}