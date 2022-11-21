using DemoApiNet6.Data;

namespace DemoApiNet6.Domain
{
    public interface IBillOfLadingRepository
    {
        Task<IEnumerable<DmBillOfLading>> GetAll();
    }
}
