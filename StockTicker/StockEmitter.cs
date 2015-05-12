using Emmit;

namespace StockTicker
{
    public class StockEmitter:Emitter,IStockEmitter
    {
        public StockEmitter(EmitterModel model) : base(model)
        {
            
        }
        public StockEmitter(IEmitterContext emitterContext, EmitterModel model) : base(emitterContext, model)
        {
            
        }

        public void OnStockOpen()
        {
            EmitterContext.Clients.All.onStockOpen();
        }

        public void OnStockClosed()
        {
            EmitterContext.Clients.All.onStockClosed();
        }

        public void OnStockUpdated(StockUpdate stockUpdate)
        {
            EmitterContext.Clients.All.onStockUpdated(stockUpdate);
        }
    }
}