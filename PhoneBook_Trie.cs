/*
Testing:
      var pb = new PhoneBook();
      pb.InsertRecord("abc dce", "2290012312");
      pb.InsertRecord("test dce", "6634452345");
      pb.InsertRecord("wa rwr", "1233456788");
      pb.InsertRecord("Kja TEser", "7765443333");
      pb.InsertRecord("Waht dfd", "2341234567");
      pb.InsertRecord("test dce", "8887776666");
      pb.InsertRecord("sdf aadf", "2290012312");
      pb.InsertRecord("Wagsd Test", "8909898989");
      pb.InsertRecord("Ijhi O'Cince", "6690012312");
      pb.InsertRecord("test Ddce", "2990012312");

      Console.WriteLine(string.Join(";", pb.GetPhones("test dce")));
      Console.WriteLine(pb.FindName("8909898989")); 
*/

public class PhoneBook
{
    private TrieNode nameRoot;
    private NumNode phoneRoot;

    public PhoneBook()
    {
        nameRoot = new TrieNode();
        phoneRoot = new NumNode();
    }

    public void InsertRecord(string name, string phone)
    {
        TrieNode nameNode = nameRoot;

        for (int i = 0; i < name.Length; i++)
        {
            nameNode.Children.TryAdd(name[i], new TrieNode());
            nameNode = nameNode.Children[name[i]];
        }

        if (nameNode.Phones == null)
            nameNode.Phones = new List<string> { phone };
        else
            nameNode.Phones.Add(phone);


        NumNode phoneNode = phoneRoot;

        for (int i = 0; i < phone.Length; i++)
        {
            var n = phone[i];

            if (phoneNode.Children[n-'0'] == null)
                phoneNode.Children[n-'0'] = new NumNode();

            phoneNode = phoneNode.Children[n-'0'];
        }

        phoneNode.Name = name;
    }

    public List<string> GetPhones(string name)
    {
        TrieNode nr = nameRoot;

        for (int i = 0; i < name.Length; i++)
        {
            var c = name[i];
            nr = nr.Children[c];
        }

        if (nr.IsEnd)
            return nr.Phones;
        else
            return null;
    }

    public string FindName(string phone)
    {
        NumNode pr = phoneRoot;

        for (int i = 0; i < phone.Length; i++)
        {
            var n = phone[i];
            pr = pr.Children[n-'0'];
        }

        if (pr.IsEnd)
            return pr.Name;
        else
            return null;
    }
}

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; set; }
    public List<string> Phones { get; set; }
    public bool IsEnd => Phones != null && Phones.Count > 0;

    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
    }
}

public class NumNode
{
    public NumNode[] Children { get; set; }
    public string Name { get; set; }
    public bool IsEnd => !string.IsNullOrEmpty(Name);

    public NumNode()
    {
        Children = new NumNode[10];
    }
}
