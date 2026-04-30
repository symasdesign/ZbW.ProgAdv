namespace GenericsRepetitionHandsOn {
    internal class Program {
        private static void Main(string[] args) {
            // UseCase: Pipeline-basierte Datenverarbeitung

            Console.WriteLine("=== Aufgabe 1: Object-Pipeline reparieren ===");

            IProcessorObject step1 = new ParseIntObjectStep();
            IProcessorObject step2 = new FormatObjectStep();
            IProcessorObject step3 = new DoubleObjectStep();

            // TODO 1:
            // Dieser Code kompiliert, crasht aber zur Laufzeit.
            // Warum?
            // Repariere die Reihenfolge oder baue sie generisch um.
            object result = step3.Process(step2.Process(step1.Process("42")));
            Console.WriteLine(result);


            Console.WriteLine("=== Aufgabe 2: Generische Steps verwenden ===");

            // TODO 2:
            // Erstelle hier die korrekte generische Verarbeitung:
            //     string -> int -> int -> string
            // Definiere dazu ein passendes generisches Interface, welches die Möglichkeit bietet, den Eingabetyp und den Ausgabetyp vorzugeben.
            // Dieses Interface soll dann für jeden Step verwendet werden.
            //
            // Erwartete Ausgabe:
            // Value: 84


            Console.WriteLine("=== Aufgabe 3: SortStep ===");

            // TODO 3:
            // Behebe den Fehler mit einem geeigneten Constraint

            var persons = new List<Person> { new Person { Id = 2, Name = "Ben" }, new Person { Id = 1, Name = "Thomas" } };

            var sortStep = new SortStep<Person>();
            sortStep.Sort(persons);

            Console.WriteLine(string.Join(", ", persons));



            Console.WriteLine("=== Aufgabe 4: Eigener Step ===");

            // TODO 4:
            // Implementiere einen neuen generischen Step:
            //
            // class IsEvenStep 
            //
            // Danach soll gelten:
            // Input: 42
            // Output: true
        }
    }

    public class Person {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString() {
            return $"{Name} ({Id})";
        }
    }

    // =====================================================
    // Aufgabe 1: Object-basierte Variante
    // =====================================================

    public interface IProcessorObject {
        object Process(object input);
    }

    public class ParseIntObjectStep : IProcessorObject {
        public object Process(object input) {
            return int.Parse((string)input);
        }
    }

    public class DoubleObjectStep : IProcessorObject {
        public object Process(object input) {
            return (int)input * 2;
        }
    }

    public class FormatObjectStep : IProcessorObject {
        public object Process(object input) {
            return $"Value: {input}";
        }
    }


    // =====================================================
    // Aufgabe 2: Generische Variante
    // =====================================================



    // =====================================================
    // Aufgabe 3: SortStep
    // =====================================================
    public class SortStep<T> {
        public void Sort(List<T> list) {
            list.Sort();
        }
    }
}