namespace lab03;

public class Order
{
    private List<OrderItem> _items = new();

    public decimal TotalPrice
    {
        get
        {
            decimal totalPrice = 0;
            foreach (var item in _items)
            {
                totalPrice += item.Quantity * item.Item.Price;
            }
            return totalPrice;
        }
    }

    public void AddItems(MenuItem item, int quantity)
    {
        OrderItem orderItem = new OrderItem()
        {
            Item = item,
            Quantity = quantity
        };
    }

    public void DeleteItem(MenuItem item)
    {
        var index = _items.FindIndex(x => x.Item == item);
        if (index != -1)
        {
            var orderItem = _items[index];
            if (orderItem.Quantity > 1)
            {
                orderItem.Quantity--;
            }
            else
            {
                _items.RemoveAt(index);
            }
        }
    }
}