using Electricity_Demand_Management_Sys;

class Program
{
    // Bubble Sort (For Small Datasets)
    static void BubbleSort(PowerPlant[] arr, int count)
    {
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count - i - 1; j++)
            {
                if ((arr[j].IsBaseload && arr[j + 1].IsBaseload && arr[j].UnitCost > arr[j + 1].UnitCost) ||
                    (!arr[j].IsBaseload && !arr[j + 1].IsBaseload && arr[j].UnitCost > arr[j + 1].UnitCost) ||
                    (!arr[j].IsBaseload && arr[j + 1].IsBaseload))
                {
                    PowerPlant tempPlant = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = tempPlant;
                }
            }
        }
    }

    // Merge Sort (For Large Datasets)
    static void MergeSort(PowerPlant[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(PowerPlant[] arr, int left, int mid, int right)
    {
        int leftSize = mid - left + 1;
        int rightSize = right - mid;

        PowerPlant[] leftArr = new PowerPlant[leftSize];
        PowerPlant[] rightArr = new PowerPlant[rightSize];

        for (int i = 0; i < leftSize; i++)
            leftArr[i] = arr[left + i];
        for (int j = 0; j < rightSize; j++)
            rightArr[j] = arr[mid + 1 + j];

        int iLeft = 0, iRight = 0, k = left;

        while (iLeft < leftSize && iRight < rightSize)
        {
            bool shouldSwap = (leftArr[iLeft].IsBaseload && rightArr[iRight].IsBaseload && leftArr[iLeft].UnitCost > rightArr[iRight].UnitCost) ||
                              (!leftArr[iLeft].IsBaseload && !rightArr[iRight].IsBaseload && leftArr[iLeft].UnitCost > rightArr[iRight].UnitCost) ||
                              (!leftArr[iLeft].IsBaseload && rightArr[iRight].IsBaseload);

            if (!shouldSwap)
                arr[k++] = leftArr[iLeft++];
            else
                arr[k++] = rightArr[iRight++];
        }

        while (iLeft < leftSize)
            arr[k++] = leftArr[iLeft++];
        while (iRight < rightSize)
            arr[k++] = rightArr[iRight++];
    }

    // Function to Decide Sorting Method and Store in Stack
    static void SortAndStore(DoublyLinkedList plantList, Stack sortedStack)
    {
        int count = 0;
        PowerPlant temp = plantList.Head;
        while (temp != null) { count++; temp = temp.Next; }

        if (count == 0) return; // No plants to sort

        PowerPlant[] arr = new PowerPlant[count];
        temp = plantList.Head;
        for (int i = 0; i < count; i++)
        {
            arr[i] = temp;
            temp = temp.Next;
        }

        // Use Bubble Sort for small datasets, Merge Sort for large ones
        if (count <= 10)
        {
            Console.WriteLine("Using Bubble Sort...");
            BubbleSort(arr, count);
        }
        else
        {
            Console.WriteLine("Using Merge Sort...");
            MergeSort(arr, 0, count - 1);
        }

        for (int i = count - 1; i >= 0; i--)
        {
            sortedStack.Push(arr[i]);
        }
    }

    static void OptimizeEnergyMix(Stack sortedStack, double demand)
    {
        double remainingDemand = demand;
        Console.WriteLine("\nOptimized Energy Mix:");

        while (!sortedStack.IsEmpty() && remainingDemand > 0)
        {
            PowerPlant plant = sortedStack.Pop();
            double usedCapacity = Math.Min(plant.Capacity, remainingDemand);
            remainingDemand -= usedCapacity;

            Console.WriteLine($"{plant.Name} supplies {usedCapacity}MW (Unit Cost: {plant.UnitCost}$, Baseload: {plant.IsBaseload})");
        }

        if (remainingDemand > 0)
        {
            Console.WriteLine("Warning: Demand exceeds available capacity!");
        }
    }

    static void Main()
    {
        DoublyLinkedList plantList = new DoublyLinkedList();
        Stack sortedStack = new Stack(100);
        Menu menu = new Menu();

        bool running = true;
        while (running)
        {
            menu.DisplayMenu();
            int choice = menu.GetUserChoice();

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Plant Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Capacity (MW): ");
                    double capacity = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter Unit Cost (LKR): ");
                    double unitCost = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Is this a baseload plant? (yes/no): ");
                    bool isBaseload = Console.ReadLine().ToLower() == "yes";

                    plantList.AddPlant(name, capacity, unitCost, isBaseload);
                    break;

                case 2:
                    Console.Write("Enter the name of the plant to remove: ");
                    string removeName = Console.ReadLine();
                    plantList.RemovePlant(removeName);
                    break;

                case 3:
                    plantList.DisplayPlants();
                    break;

                case 4:
                    SortAndStore(plantList, sortedStack);
                    Console.Write("Enter power demand (MW): ");
                    double demand = Convert.ToDouble(Console.ReadLine());
                    OptimizeEnergyMix(sortedStack, demand);
                    break;

                case 5:
                    running = false;
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("          ...Exiting program...");
                    Console.WriteLine("--------------------------------------------");
                    break;
            }
        }
    }
}
