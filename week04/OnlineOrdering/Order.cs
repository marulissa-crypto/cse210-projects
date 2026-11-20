using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order()
    {
        _products = new List<Product>();
        _customer = new Customer();
    }

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products ?? new List<Product>();
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

    public void SetProducts(List<Product> products)
    {
        _products = products ?? new List<Product>();
    }

    public void AddProduct(Product product)
    {
        if (product != null)
        {
            _products.Add(product);
        }
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }

    public double GetTotalCost()
    {
        double productsTotal = 0.0;
        foreach (Product product in _products)
        {
            productsTotal += product.GetTotalCost();
        }

        double shippingCost = (_customer != null && _customer.LivesInUsa()) ? 5.0 : 35.0;
        return productsTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (Product product in _products)
        {
            sb.AppendLine($"- {product.GetName()} (ID: {product.GetProductId()})");
        }
        return sb.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Shipping Label:");
        if (_customer != null)
        {
            sb.AppendLine(_customer.GetName());
            if (_customer.GetAddress() != null)
            {
                sb.AppendLine(_customer.GetAddress().GetFullAddressString());
            }
        }
        return sb.ToString().TrimEnd();
    }
}