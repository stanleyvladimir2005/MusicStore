
namespace MusicStore.Entities
{
     public class EntityBase
    {
        //[Key] solo cuando tenga otro nombre diferente a Id
        public int Id { get; set; }

        public bool Status { get; set; }  

        protected EntityBase() {
            Status = true;
        }
    }
}
