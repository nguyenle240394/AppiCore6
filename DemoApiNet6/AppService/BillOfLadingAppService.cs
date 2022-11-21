using DemoApiNet6.Data;
using DemoApiNet6.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoApiNet6.AppService
{
    public class BillOfLadingAppService : IBillOfLadingRepository
    {
        private readonly WmsClpDnTestContext _context;
        public BillOfLadingAppService(WmsClpDnTestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DmBillOfLading>> GetAll()
        {
            return await _context.DmBillOfLadings.ToListAsync();
        }
    }
}
