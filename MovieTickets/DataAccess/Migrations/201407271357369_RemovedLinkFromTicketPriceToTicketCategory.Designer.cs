// <auto-generated />

using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Infrastructure;
using System.Resources;

namespace DataAccess.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.1.1-30610")]
    public sealed partial class RemovedLinkFromTicketPriceToTicketCategory : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(RemovedLinkFromTicketPriceToTicketCategory));
        
        string IMigrationMetadata.Id
        {
            get { return "201407271357369_RemovedLinkFromTicketPriceToTicketCategory"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
