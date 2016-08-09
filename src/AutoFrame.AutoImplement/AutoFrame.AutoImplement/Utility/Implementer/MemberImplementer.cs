namespace AutoFrame.AutoImplement.Utility.Implementer
{
    internal class MemberImplementer
    {
        public MemberImplementer()
        {
            EventImplementationStrategy = new EventImplementationStrategy();
            PropertyImplementationStrategy = new PropertyImplementationStrategy();
            MethodImplementationStrategy = new MethodImplementationStrategy();
        }

        public EventImplementationStrategy EventImplementationStrategy { get; }

        public PropertyImplementationStrategy PropertyImplementationStrategy { get; }

        public MethodImplementationStrategy MethodImplementationStrategy { get; }
    }
}
