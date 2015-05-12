namespace StockTicker
{
    public interface IStockEmitter
    {
        void OnStockOpen();
        void OnStockClosed();
        void OnStockUpdated(StockUpdate stockUpdate);
    }
}