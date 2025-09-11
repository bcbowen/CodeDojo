using System; 

public namespace SudokoSolver
{
    public class SudokuCell
    {
        public List<int> PossibleValues { get; private set; }

        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException();
                }
                ValueSetEventArgs args = new ValueSetEventArgs(value);
                _value = value;
                OnValueSet(this, args); 
            }
        }

        public event ValueSetEventHandler OnValueSet;

        private void OnValueSet(object sender, ValueSetEventArgs args)
        {
            OnValueSet(sender, args);
        }


        /*
            def __init__(self, value: int = 0):
            self.possible_values = [n for n in range(1, 10)]
            self._value = value
            if value > 0: 
                self.set_value(value)
            self.value_set = Event()

        def set_value(self, value: int) -> None: 
            if value > 0 and value < 10: 
                self._value = value
                self.value_set.fire(value)
                self.possible_values.clear() 
                self.possible_values.append(value)

        def exclude_value(self, value: int) -> None: 
            if value in self.possible_values: 
                self.possible_values.remove(value)
        */
    }
}

