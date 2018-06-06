
namespace SubjectEngine.Core
{
    public enum UserDomains
    {
        // Must match with core.tblDomain
        // select * from core.tblDomain

        //  1	SysAdmin
        //  2	Anonymous
        //  3   Member
        //  4	Employee
        //  5	Customer
        //  6	Supplier
        //  7	SupplierAdmin
        //  8	Agent

        SuperAdmin = 99,        // system defined
        SysAdmin = 1,
        Anonymous = 2,
        Member = 3,
        Employee = 4,
        Customer = 5,
        Supplier = 6,
        SupplierAdmin = 7,
        Agent = 8,
    }
}
