using M = GlobalBlue.Tax.Model;

namespace GlobalBlue.Tax.BusinessLayer;

public interface ITaxService
{
    void GetPurchaseData(M.Tax purchase);
}
