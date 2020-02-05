namespace SelfishMeme
{
    public class BreedingSeason{
        private readonly IConfrontationResolver confrontationResolver;

        public BreedingSeason(IConfrontationResolver confrontationResolver){
            this.confrontationResolver = confrontationResolver;
        }
    }
}