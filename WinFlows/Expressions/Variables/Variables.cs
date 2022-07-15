namespace WinFlows.Expressions.Variables
{
    public static class Variables
    {
        private static SortedDictionary<string, Variable> _variables = new SortedDictionary<string, Variable>();

        public static List<string> Names => _variables.Keys.ToList();
        public static string[] NamesArray => Names.ToArray();

        public static Variable Get(string name)
        {
            if (!_variables.ContainsKey(name))
            {
                var err = $"A variable named {name} does not exist. Using a temporary string variable.";
                MessageBox.Show(err);
                throw new ArgumentOutOfRangeException(err);
            }

            return _variables[name];
        }

        public static bool Exists(string name)
        {
            return _variables.ContainsKey(name);
        }

        public static void Create(string name, ExpressionTypes type)
        {
            if (Exists(name))
            {
                MessageBox.Show($"A variable named {name} already exists.");
                return;
            }

            _variables.Add(name, Variable.Create(type, name));
        }

        public static void Clear()
        {
            _variables.Clear();
        }

        public static void Create(string name, string type)
        {
            if (Exists(name))
            {
                MessageBox.Show($"A variable named {name} already exists.");
                return;
            }

            if (Enum.TryParse(type, out ExpressionTypes exprType))
                _variables.Add(name, Variable.Create(exprType, name));
            else
                MessageBox.Show($"Enum could not parse variable type {type}");
        }
    }
}
