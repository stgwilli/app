namespace nothinbutdotnetstore.web.core
{
    public class LinkBuilder<Request> : IBuildLinks
    {
        RequestNameStrategy request_name_strategy;

        public LinkBuilder(RequestNameStrategy request_name_strategy)
        {
            this.request_name_strategy = request_name_strategy;
        }

        public override string ToString()
        {
            return request_name_strategy(typeof(Request));
        }
    }
}