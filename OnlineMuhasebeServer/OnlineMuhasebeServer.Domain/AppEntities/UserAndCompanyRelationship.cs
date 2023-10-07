using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMuhasebeServer.Domain.AppEntities
{
    public  class UserAndCompanyRelationship:Entity
    {
        public UserAndCompanyRelationship()
        {
                
        }
        public UserAndCompanyRelationship(string id,string appUserıd,string companyId):base(id)
        {
            AppUserID = appUserıd;
            CompanyId = companyId;
        }
        [ForeignKey("AppUser")]
        public string AppUserID { get; set; }
        public AppUser AppUser{ get; set; }

        [ForeignKey("Company")]
        public string CompanyId{ get; set; }
        public Company Company { get; set; }
    }
}
