using ContactManager.Data.EF;

namespace ContactManager.Data
{
    public abstract class RepoBase
    {
        readonly ContactManagerEntities _contextProvider = new ContactManagerEntities();

        public ContactManagerEntities Context {
            get { return _contextProvider; }
        }
    }
}
