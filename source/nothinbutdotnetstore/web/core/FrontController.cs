namespace nothinbutdotnetstore.web.core
{
    public class FrontController :IProcessRequests
    {
        IFindCommands command_finder;

        public FrontController(IFindCommands command_finder)
        {
            this.command_finder = command_finder;
        }

        public void process(IContainRequestInformation request)
        {
            command_finder.get_the_command_that_can_process(request).process(request);
        }
    }
}