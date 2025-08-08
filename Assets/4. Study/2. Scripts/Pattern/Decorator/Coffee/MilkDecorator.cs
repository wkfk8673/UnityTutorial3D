using UnityEngine;

public class MilkDecorator : CoffeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee)
    {

    }

    public override string Description()
    {
        return coffee.Description() + "Milk";
    }

    public override int Cost()
    {
        return coffee.Cost() + 500;
    }
}
