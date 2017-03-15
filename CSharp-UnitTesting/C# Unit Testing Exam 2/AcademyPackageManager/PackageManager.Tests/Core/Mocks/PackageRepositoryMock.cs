using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Core.Mocks
{
    class PackageRepositoryMock : IRepository<IPackage>
    {
        public PackageRepositoryMock(ICollection<IPackage> packages = null)
        {
            if (packages == null)
            {
                this.Packages = new HashSet<IPackage>();
            }
            else
            {
                this.Packages = packages;
            }
        }

        public ICollection<IPackage> Packages { get; set; }

        public void Add(IPackage package)
        {
            this.Packages.Add(package);
        }

        public IPackage Delete(IPackage package)
        {
            var packageFound = this.Packages.SingleOrDefault(x => x.Equals(package));
            this.Packages.Remove(packageFound);
            return package;
        }

        public IEnumerable<IPackage> GetAll()
        {
            return this.Packages;
        }

        public bool Update(IPackage package)
        {
            return true;
        }
    }
}
