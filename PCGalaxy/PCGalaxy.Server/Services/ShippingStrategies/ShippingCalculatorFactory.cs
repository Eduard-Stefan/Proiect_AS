namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class ShippingCalculatorFactory
    {
        private readonly Dictionary<string, IShippingCalculator> _calculators;
        private readonly IShippingCalculator _fallbackCalculator;

        public ShippingCalculatorFactory()
        {
            _fallbackCalculator = new DefaultShippingCalculator();

            _calculators = new Dictionary<string, IShippingCalculator>(StringComparer.OrdinalIgnoreCase)
            {
                { "Motherboard", new MotherboardShippingCalculator() },
                { "CPU", new CpuShippingCalculator() },
                { "GPU", new GpuShippingCalculator() },
                { "RAM", new RamShippingCalculator() },
                { "Storage", new StorageShippingCalculator() },
                { "Power Supply", new PowerSupplyShippingCalculator() },
                { "PC Case", new PcCaseShippingCalculator() },
                { "Cooler", new CoolerShippingCalculator() },
                { "Fan", new FanShippingCalculator() },
                { "Monitor", new MonitorShippingCalculator() },
                { "Keyboard", new KeyboardShippingCalculator() },
                { "Mouse", new MouseShippingCalculator() },
                { "Mouse Pad", new MousePadShippingCalculator() },
                { "Headset", new HeadsetShippingCalculator() }
            };
        }

        public IShippingCalculator GetCalculator(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
                return _fallbackCalculator;

            if (_calculators.TryGetValue(categoryName, out var calculator))
            {
                return calculator;
            }

            return _fallbackCalculator;
        }
    }
}
