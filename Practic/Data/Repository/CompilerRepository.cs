using Practic.Data.Interfaces;
using Practic.Data.Models;

namespace Practic.Data.Repository
{
    public class CompilerRepository : IAllCompilers
    {
        private readonly AppDBContent appDBContent;
        private readonly AimMaker aimMaker;
        public CompilerRepository(AppDBContent appDBContent, AimMaker aimMaker)
        {
            this.appDBContent = appDBContent;
            this.aimMaker = aimMaker;
        }
        public void createCompiler(Compiler compiler)
        {
            appDBContent.Compilers.Add(compiler);
            var items = aimMaker.ListAimItems;
            foreach ( var element in items )
            {
                var compilerDetail = new CompilerDetail()
                {
                    AimId = element.aim.Id,
                    compilerId = compiler.Id
                };
                appDBContent.CompilerDetails.Add(compilerDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
