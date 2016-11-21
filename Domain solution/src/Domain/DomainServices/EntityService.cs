namespace Domain.DomainServices {
    public class EntityService
    {
        private readonly IRepository _repository;

        public EntityService(IRepository repository)
        {
            _repository = repository;
        }

        public void CreateEntity() 
        {
            // Persist entity using _repository

            // (optional) throw event
        }
    }

}
