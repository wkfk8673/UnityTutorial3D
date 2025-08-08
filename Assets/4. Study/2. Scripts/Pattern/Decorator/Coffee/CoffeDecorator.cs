using UnityEngine;

public class CoffeDecorator : ICoffee
{
    protected ICoffee coffee;
    public CoffeDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }
    public virtual string Description()
    {
        return coffee.Description();
    }

    public virtual int Cost()
    {
        return coffee.Cost();
    }
}
