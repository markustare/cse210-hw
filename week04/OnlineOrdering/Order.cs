public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product) => _products.Add(product);

    public double CalculateTotalCost()
    {
        double total = _products.Sum(p => p.CalculateProductTotalCost());
        total += _customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel() => string.Join("\n", _products.Select(p => $"{p.GetName()} ({p.GetProductId()})"));
    public string GetShippingLabel() => $"{_customer.GetName()}\n{_customer.GetAddress().GetAddressString()}";
}