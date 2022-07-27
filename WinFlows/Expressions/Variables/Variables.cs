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

        public static bool Create(string name, ExpressionTypes type)
        {
            if (Exists(name))
            {
                MessageBox.Show($"A variable named {name} already exists.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(name) || !IsValidVariableName(name))
            {
                MessageBox.Show($"\"{name}\" is not a valid variable name.");
                return false;
            }

            _variables.Add(name, Variable.Create(type, name));
            return true;
        }

        private static bool IsValidVariableName(string name)
        {
            if (!(name.StartsWith("_") || (char.IsLetter(name[0]) && char.IsAscii(name[0]))))
                return false;

            foreach (char c in name)
                if (!(char.IsAscii(c) && (char.IsLetterOrDigit(c) || c.Equals('_'))))
                    return false;

            return true;
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
