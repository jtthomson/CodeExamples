namespace Stack
{
    public interface IStack
    {
        string Name { get; }
        List<string> Sets { get; set; }
        List<int?> Vals { get; set; }
        public string run();
        public void push(int val);
        public void pop();
        public int top();
    }
}
